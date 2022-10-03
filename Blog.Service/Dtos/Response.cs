using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blog.Service.Dtos
{
    public class Response<T>
    {
        public T Data { get; set; }
        [JsonIgnore] //Postman,swagger'da gözükmemesi adına
        public int StatusCode { get; set; }
        [JsonIgnore]
        public bool IsSuccessful { get; set; }
        public List<string> Errors { get; set; }

        public static Response<T> Success(T data, int statusCode)
        {
            return new() { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response<T> Success(int statusCode)
        {
            return new() { Data = default, StatusCode = statusCode, IsSuccessful = true };
        }
        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new()
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }

        public static Response<T> Fail(string error, int statusCode)
        {
            return new()
            {
                Errors = new List<string>() { error },
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }

    }
}
