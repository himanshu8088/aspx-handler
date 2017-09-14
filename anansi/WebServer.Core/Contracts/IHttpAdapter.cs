using System.IO;

namespace WebServer.Core
{
    public interface IHttpAdapter
    {
        IHttpRequest ReadRequest(Stream requestStream);

        void WriteResponse(IHttpResponse response, Stream responseStream);
    }
}
