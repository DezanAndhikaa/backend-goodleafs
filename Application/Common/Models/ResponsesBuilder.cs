namespace Application.Common.Models {
    /// <summary>
    /// Builder
    /// </summary>
    public class ResponsesBuilder {

        /// <summary>
        /// Static message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string MessageBuilder (string message) {
            return "{\"Error\" : \" " + message + " \"}";
        }

        /// <summary>
        /// Static message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string MessageBuilder (string message, string status) {
            return "{\"" + status + "\" : \" " + message + " \"}";
        }
    }
}