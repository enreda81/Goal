using System;
using System.Runtime.Serialization;

namespace GoalSystems.InventoryManager.Infrastructure.CrossCutting.Services.Logging
{
    [Serializable]
    public abstract class BaseException : ApplicationException
    {
        /// <summary>
        /// Se bloquea el constructor sin parámetros
        /// </summary>
        protected BaseException() : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public BaseException(string message) : base(message) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public BaseException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected BaseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

}