using System.Collections.Generic;

namespace WebServer.Core
{
    public class StatusCode
    {
        private static Dictionary<int, string> _codes;
        public StatusCode()
        {
            _codes = new Dictionary<int, string>()
                {
                    {200, "Success" },
                    {400, "BadRequest" }
                };
            Codes = _codes;
        }
        public static Dictionary<int, string> Codes {
            get
            {
                return _codes;
            }
            private set
            {               
                _codes = value;
            }
        }
         

       
    }

    
}
