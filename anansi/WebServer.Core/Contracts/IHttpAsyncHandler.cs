using System.Threading.Tasks;

namespace WebServer.Core
{
    public interface IHttpAsyncHandler
    {
        Task<IHttpResponse> ProcessAsyncRequest(IHttpRequest request);
    }
}