using System;
using System.Dynamic;
using System.Net;
using System.Threading;

namespace GoalSystems.InventoryManager.Infrastructure.CrossCutting.Services.Logging
{
    /// <summary>
    /// Servicio de persistencia de errores y trazas
    /// </summary>
    public static class LoggingService
    {
        /// <summary>
        /// Persiste un error
        /// </summary>
        /// <param name="exception">Excepción a persistir</param>
        /// <param name="aditionalInfo">Información adicional</param>
        public static void LogException(Exception exception, string aditionalInfo = "")
        {
            // Sin implementar
        }

        /// <summary>
        /// Persiste una traza de depuración
        /// </summary>
        /// <param name="message">Mensaje de la traza</param>
        public static void LogTrace(string message)
        {
            // Sin implementar
        }
    }
}
