using System.Net;

namespace Labs.Domain.Comand.Utils
{
    public class ComandResponse
    {
        public ComandResponse() { }
        
        public ComandResponse(bool success, string message, HttpStatusCode statuscode, object data)
        {
            Success = success;
            Message = message;
            StatusCode = statuscode;
            Data = data;
        }

        public ComandResponse(bool success, string message, HttpStatusCode statuscode)
        {
            Success = success;
            Message = message;
            StatusCode = statuscode;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public object Data { get; set; }
    }
}
