using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.Core
{
    public class RequestHeader
    {
        private static Dictionary<string, string> _headers = new Dictionary<string, string>();


        public RequestHeader()
        {
            _headers = new Dictionary<string, string>();
            Headers = _headers;

        }
        public static Dictionary<string, string> Headers
        {
            get
            {
                return _headers;
            }
            private set
            {
                _headers = value;
                _headers.Add("Accept", "");
                _headers.Add("From", "");
                _headers.Add("Accept-Encoding", "");
                _headers.Add("Accept-Language", "");
                _headers.Add("User-Agent", "");
                _headers.Add("Referer", "");
                _headers.Add("Authorization", "");
                _headers.Add("Charge-To", "");
                _headers.Add("If-Modified-Since", "");
                _headers.Add("Pragma", "");
                
            }
        }

       
    }
}
