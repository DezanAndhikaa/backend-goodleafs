using System;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Application.Common.Models {
    /// <summary>
    /// Utils
    /// </summary>
    public class Utils {
        /// <summary>
        /// Shared logger
        /// </summary>
        public static class ApplicationLogging {
            /// <summary>
            /// LoggerFactory
            /// </summary>
            /// <value></value>
            public static ILoggerFactory LoggerFactory { get; set; }

            /// <summary>
            /// CreateLogger
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            public static ILogger CreateLogger<T> () => LoggerFactory.CreateLogger<T> ();

            /// <summary>
            /// CreateLogger
            /// </summary>
            /// <param name="categoryName"></param>
            /// <returns></returns>
            public static ILogger CreateLogger (string categoryName) => LoggerFactory.CreateLogger (categoryName);

        }

        /// <summary>
        /// Shared logger
        /// </summary>
        public static class Helpers {
            /// <summary>
            /// SetDateIfNull
            /// </summary>
            /// <param name="Dt"></param>
            /// <returns></returns>
            public static DateTime SetDateIfNull (DateTime? Dt) {
                return Dt ?? DateTime.UtcNow;
            }

            /// <summary>
            /// EqualsCaseInsensitive
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public static bool EqualsCaseInsensitive (string a, string b) {
                if (a != null) {
                    return a.Equals (b, StringComparison.InvariantCultureIgnoreCase);
                } else {
                    return false;
                }
            }

            /// <summary>
            /// Truncate
            /// </summary>
            /// <param name="s"></param>
            /// <param name="maxChars"></param>
            /// <returns></returns>
            public static string Truncate (string s, int maxChars) {
                if (s == null)
                    return s;
                return s.Length <= maxChars ? s : s.Substring (0, maxChars);
            }

            /// <summary>
            /// SerializerSettings
            /// </summary>
            /// <returns></returns>
            public static JsonSerializerSettings SerializerSettings () {
                return new JsonSerializerSettings {
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        ContractResolver = new DefaultContractResolver ()
                };
            }
        }
    }
}