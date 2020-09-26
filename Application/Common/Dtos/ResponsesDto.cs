using System.Net.Http;
using System.Text;
using Application.Common.Models;
using Newtonsoft.Json;

namespace Application.Common.Dtos {
    public class ResponsesDto {
        public static StringContent ResponsesMaker (string status, string message) {
            return new StringContent (JsonConvert.SerializeObject (new Responses { Status = status, Message = message }), Encoding.UTF8, "application/json");
        }
    }
}