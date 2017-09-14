using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WebServer.Core
{
    public interface IHttpHandler
    {
        IHttpResponse ProcessRequest(IHttpRequest request);
    }
}
