using System.Collections.Generic;

namespace WebServer.Core
{
    public class RequestVerb
    {
        private static Dictionary<string, string> _verbType;
        public RequestVerb()
        {
            _verbType = new Dictionary<string, string>();
            VerbType = _verbType;
        }
        
        public static Dictionary<string, string> VerbType
        {
            get
            {
                return _verbType;
            }
            private set
            {
                
                _verbType.Add("Get", "");
                _verbType.Add("Post", "");
                _verbType = value;
            }
                
        }
    }

    
}
