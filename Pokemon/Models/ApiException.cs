using System;
using System.Net;

namespace Pokemon.Models
{
    public class ApiException : Exception
    {
        public string ErrorMessage { get; set; }
        public HttpStatusCode ErrorCode { get; set; }

        public ApiException(HttpStatusCode code, string errorMessage)
        {
            this.ErrorCode = code;
            this.ErrorMessage = errorMessage;
        }
    }
}
