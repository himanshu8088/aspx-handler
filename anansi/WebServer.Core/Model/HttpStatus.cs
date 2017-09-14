using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.Core
{
    public class HttpStatus
    {
        private HttpStatus(int code, string desc)
        {
            Code = code;
            Description = desc;
        }

        public static readonly HttpStatus OK = new HttpStatus(200, "OK");
        public static readonly HttpStatus Created = new HttpStatus(201, "Created");
        public static readonly HttpStatus Accepted = new HttpStatus(202, "Accepted");
        public static readonly HttpStatus NonAuthoritativeInformation = new HttpStatus(203, "NonAuthoritative Information");
        public static readonly HttpStatus NoContent = new HttpStatus(204, "No Content");
        public static readonly HttpStatus ResetContent = new HttpStatus(205, "Reset Content");
        public static readonly HttpStatus MultipleChoices = new HttpStatus(300, "Multiple Choices");
        public static readonly HttpStatus MovedPermanently = new HttpStatus(301, "Moved Permanently");
        public static readonly HttpStatus Found = new HttpStatus(302, "Found");
        public static readonly HttpStatus SeeOther = new HttpStatus(303, "See Other");
        public static readonly HttpStatus UseProxy = new HttpStatus(305, "Use Proxy");
        public static readonly HttpStatus TemporaryRedirect = new HttpStatus(307, "Temporary Redirect");
        public static readonly HttpStatus BadRequest = new HttpStatus(400, "Bad Request");
        public static readonly HttpStatus Unauthorized = new HttpStatus(401, "Unauthorized");
        public static readonly HttpStatus PaymentRequired = new HttpStatus(402, "Payment Required");
        public static readonly HttpStatus Forbidden = new HttpStatus(403, "Forbidden");
        public static readonly HttpStatus NotFound = new HttpStatus(404, "Not Found");
        public static readonly HttpStatus MethodNotAllowed = new HttpStatus(405, "Method Not Allowed");
        public static readonly HttpStatus NotAcceptable = new HttpStatus(406, "Not Acceptable");
        public static readonly HttpStatus ProxyAuthenticationRequired = new HttpStatus(407, "Proxy Authentication Required");
        public static readonly HttpStatus RequestTimeOut = new HttpStatus( 408, "Request Time-Out");
        public static readonly HttpStatus Conflict = new HttpStatus(409, "Conflict");
        public static readonly HttpStatus Gone = new HttpStatus(410, "Gone");
        public static readonly HttpStatus LengthRequired = new HttpStatus(411, "Length Required");
        public static readonly HttpStatus PreconditionFailed = new HttpStatus(412, "Precondition Failed");
        public static readonly HttpStatus PayloadTooLarge = new HttpStatus(413, "Payload Too Large");
        public static readonly HttpStatus URITooLong = new HttpStatus(414, "URI Too Long");
        public static readonly HttpStatus UnsupportedMediaType = new HttpStatus(415, "Unsupported Media Type");
        public static readonly HttpStatus RangeNotSatisfiable = new HttpStatus(416, "Range Not Satisfiable");
        public static readonly HttpStatus ExpectationFailed = new HttpStatus(417, "Expectation Failed");
        public static readonly HttpStatus UpgradeRequired = new HttpStatus(426, "Upgrade Required");
        public static readonly HttpStatus InternalServerError = new HttpStatus(500, "Internal Server Error");
        public static readonly HttpStatus NotImplemented = new HttpStatus(501, "Not Implemented");
        public static readonly HttpStatus BadGateway = new HttpStatus(502, "Bad Gateway");
        public static readonly HttpStatus ServiceUnavailable = new HttpStatus(503, "Service Unavailable");
        public static readonly HttpStatus GatewayTimeOut = new HttpStatus( 504, "Gateway Time-Out");
        public static readonly HttpStatus HTTPVersionNotSupported = new HttpStatus(505, "HTTP Version Not Supported");


        public int Code { get; private set; }

        public string Description { get; private set; }
    }
}
