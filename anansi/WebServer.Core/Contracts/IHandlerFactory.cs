namespace WebServer.Core
{
    public interface IHandlerFactory
    {
        IHttpHandler Create(IHttpRequest httpRequest);
    }
}