using System;
using System.ComponentModel.DataAnnotations;

namespace GoalSystems.InventoryManager.Infrastructure.CrossCutting.ExtensionMethod
{
    /// <summary>
    /// Clase extensora para realizar validaciones de parametros de entrada en los metodos
    /// </summary>
    public static class ArgumentValidationExtensions
    {
        /// <summary>
        /// Lanza excepcion si el parametro es nulo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static T ThrowIfNull<T>(this T o, string paramName) where T : class
        {
            if (o == null)
                throw new ArgumentNullException(paramName);
            return o;
        }

        /// <summary>
        /// Lanza excepcion si el parametro es igual al valor indicado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ThrowIfEquals<T>(this T o, T value) where T : struct
        {
            if (o.Equals(value))
                throw new ArgumentException($"Error, '{nameof(o)}' is equals to '{nameof(value)}'");
            return o;
        }

        /// <summary>
        /// Lanza excepcion si el parametro no es igual al valor indicado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ThrowIfNotEquals<T>(this T o, T value) where T : struct
        {
            if (!o.Equals(value))
                throw new ArgumentException($"Error, '{nameof(o)}' is different than '{nameof(value)}'");
            return o;
        }

        /// <summary>
        /// Lanza excepcion si el valor es menor que el valor indicado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ThrowIfLessThan<T>(this T o, T value) where T : struct
        {
            if (typeof(T) == typeof(int))
            {
                int value1 = Convert.ToInt32(o);
                int value2 = Convert.ToInt32(value);
                if (value1 < value2)
                    throw new ArgumentException($"Error, the value of '{nameof(o)}' is less than '{value}'");
            }
            return o;
        }

        /// <summary>
        /// Lanza excepcion si el valor es mayor que el valor indicado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ThrowIfBiggerThan<T>(this T o, T value) where T : struct
        {
            if (typeof(T) == typeof(int))
            {
                int value1 = Convert.ToInt32(o);
                int value2 = Convert.ToInt32(value);
                if (value1 > value2)
                    throw new ArgumentException($"Error, the value of '{nameof(o)}' is bigger than '{value}'");
            }
            return o;
        }

        /// <summary>
        /// Lanza excepcion si el parametro de entrada es vacio o nulo
        /// </summary>
        /// <param name="o"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static String ThrowIfNullorEmpty(this String o, string paramName)
        {
            if (String.IsNullOrEmpty(o))
                throw new ArgumentNullException(paramName);
            return o;
        }

        /// <summary>
        /// Lanza una excepción si el parámetro es nulo.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <param name="message"></param>
        public static void ThrowIfNull<T>(this T? o, string message) where T : struct
        {
            if (o == null)
                throw new ValidationException(message);
        }

        /// <summary>
        /// Lanza excepción si el valor es mayor que el valor indicado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void ThrowIfDateTimeBiggerThan(this DateTime? o, DateTime value)
        {
            if (o > value)
                 throw new ArgumentException($"Error, the value of '{nameof(o)}' is bigger than '{value}'");          
        }
        
        /// <summary>
        /// Lanza excepción si el valor es menor que el valor indicado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void ThrowIfDateTimeLessThan(this DateTime? o, DateTime value)
        {
            if (o < value)
                 throw new ArgumentException($"Error, el valor de '{nameof(o)}' no puede ser mayor que '{value}'.");          
        }

        /// <summary>
        /// Lanza una excepción en caso de que el valor devuelto sea "true"
        /// </summary>
        /// <param name="o"></param>
        /// <param name="message"></param>
        public static void ThrowIfTrue(this bool o, string message)
        {
            if (o)
                throw new ValidationException(message);           
        }

        /// <summary>
        /// Lanza una excepción en caso de que el valor devuelto sea "false"
        /// </summary>
        /// <param name="o"></param>
        /// <param name="message"></param>
        public static void ThrowIfFalse(this bool o, string message)
        {
            if (!o)
                throw new ValidationException(message);
        }
    }
}