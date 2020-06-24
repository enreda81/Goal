using GoalSystems.InventoryManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace GoalSystems.InventoryManager.Api.Model.Auth
{
    /// <summary>
    /// Filtro encargado de inspeccionar la llamada HTTP en busca de las cabeceras de autenticación básica
    /// </summary>
    public class BasicAuthFilter : IAuthorizationFilter
    {
        private readonly string Realm;
        private const String Authorization = "Authorization";
        private const String WWWAuthenticate = "WWW-Authenticate";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="realm"></param>
        //public BasicAuthFilter(string realm)
        public BasicAuthFilter(string realm)
        {
            Realm = realm;
            if (string.IsNullOrWhiteSpace(Realm))
            {
                throw new ArgumentNullException(nameof(realm), @"Realm vacío.");
            }
        }

        /// <summary>
        /// Sobreescribimos este método para inspeccionar las cabeceras de seguridad
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                string authHeader = context.HttpContext.Request.Headers[Authorization];
                if (authHeader != null)
                {
                    var authHeaderValue = AuthenticationHeaderValue.Parse(authHeader);
                    if (authHeaderValue.Scheme.Equals(AuthenticationSchemes.Basic.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        var credentials = Encoding.UTF8
                                            .GetString(Convert.FromBase64String(authHeaderValue.Parameter ?? string.Empty))
                                            .Split(':', 2);
                        if (credentials.Length != 2)
                            ReturnUnauthorizedResult(context);

                        User user = new User()
                        {
                            Name = credentials[0],
                            Password = credentials[1]
                        };

                        if (IsAuthorized(user, context))
                            return;
                    }
                }

                ReturnUnauthorizedResult(context);
            }
            catch (FormatException)
            {
                ReturnUnauthorizedResult(context);
            }
        }

        public bool IsAuthorized(User u, AuthorizationFilterContext context)
        {            
            IUserAuthenticationService userService = context.HttpContext.RequestServices.GetService(typeof(IUserAuthenticationService)) as IUserAuthenticationService;
            return userService.IsValidUser(u);
        }

        private void ReturnUnauthorizedResult(AuthorizationFilterContext context)
        {
            // Retornar 401 junto al challenge de autenticación
            context.HttpContext.Response.Headers[WWWAuthenticate] = $"Basic realm=\"{Realm}\"";
            context.Result = new UnauthorizedResult();
        }
    }
}
