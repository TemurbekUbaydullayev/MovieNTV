using System.Net;


namespace Application.Common.Exceptions;

public  class StatusCodeExeption:Exception
{

    public StatusCodeExeption(HttpStatusCode code, string message)
        : base(message) 
    {
        StatusCode = code;
    }

    public HttpStatusCode StatusCode { get; }

}
