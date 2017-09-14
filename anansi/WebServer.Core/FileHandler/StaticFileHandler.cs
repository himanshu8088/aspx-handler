using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace WebServer.Core
{
    public class StaticFileHandler : IHttpHandler
    {                
        public StaticFileHandler(string baseDirectory = null)
        {
            BaseDirectory = baseDirectory ?? @"D:\website";         
        }

        public string BaseDirectory { get; private set; }
        public string FilePath { get; private set; }
      

        public IHttpResponse ProcessRequest(IHttpRequest request)
        {
            FilePath = new Resolver().ResolvePhysicalPath(BaseDirectory, request);
            return GenerateResponse(FilePath);
        }
       
        private IHttpResponse GenerateResponse(string filePath)
        {                        
            if (!File.Exists(filePath))
                return FileNotFoundResponse();
            else
                return SuccessResponse(FilePath);
        }

        private IHttpResponse SuccessResponse(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            var contentType = MimeTypeMap.GetMimeType(fileInfo.Extension);
            return new HttpResponse
            {
                Status = HttpStatus.OK,
                Content = new ReadonlyFileContent(filePath, contentType)
            };
        }
        private IHttpResponse FileNotFoundResponse()
        {
            return new HttpResponse
            {
                Status = HttpStatus.NotFound
            };
        }        
    }


}
