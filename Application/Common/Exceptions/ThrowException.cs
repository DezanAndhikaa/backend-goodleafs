using System;

namespace Application.Common.Exceptions {
    /// <summary>
    /// ThrowException
    /// </summary>
    public class ThrowException : Exception {
        /// <summary>
        /// ThrowException
        /// </summary>
        /// <param name="message"></param>
        public ThrowException (string message) : base (message) { }
    }
}