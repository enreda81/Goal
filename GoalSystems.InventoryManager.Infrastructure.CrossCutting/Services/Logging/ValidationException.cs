using System;
using System.Runtime.Serialization;

namespace GoalSystems.InventoryManager.Infrastructure.CrossCutting.Services.Logging
{
    [Serializable]
    public class ValidationException : BaseException
    {
        /// <summary>
        /// Se bloquea el constructor sin parámetros
        /// </summary>
        private ValidationException() : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ValidationException(string message) : base(message) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ValidationException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

}