using System;

namespace Application.Common.Exceptions {
    /// <summary>
    /// NotFoundException
    /// </summary>
    public class NotFoundException : Exception {
        /// <summary>
        /// NotFoundException
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        public NotFoundException (string name, object key) : base ($"Entity {name} with key ({key}) was not found.") { }
    }
}