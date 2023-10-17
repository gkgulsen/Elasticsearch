using System.Net;

namespace Elasticsearch.API.ViewModels
{
    public record ResponseViewModel<T>
    {
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public HttpStatusCode Status { get; set; }

        //Static Factory Method
        public static ResponseViewModel<T> Success(T data, HttpStatusCode statusCode)
        {
            return new ResponseViewModel<T> { Data = data, Status = statusCode };
        }

        public static ResponseViewModel<T> Fail(List<string> errors, HttpStatusCode statusCode)
        {
            return new ResponseViewModel<T> { Errors = errors, Status = statusCode };
        }
        public static ResponseViewModel<T> Fail(string error, HttpStatusCode statusCode)
        {
            return new ResponseViewModel<T> { Errors = new List<string> { error }, Status = statusCode };
        }
    }
}
