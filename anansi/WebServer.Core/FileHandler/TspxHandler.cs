using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tsp.Net;
namespace WebServer.Core.FileHandler
{
    class TspxHandler : IHttpHandler
    {
        public IHttpResponse ProcessRequest(IHttpRequest request)
        {
            var tspxPath = @"D:\Git Repo\Pankaj\aspx-handler\anansi\WebServer.Core\Tspx\Default.tspx";
            var className = "Page1";

            Tspx tspx = new Tspx(tspxPath);
            var form= tspx.CreateForm(new FormParser());

            var pagePath = tspx.CreateClassTemplate(className, form);
            Type classType = Type.GetType($"Tsp.Net.{className}");
            object instance = Activator.CreateInstance(classType);

            Page1 page = new Page1();
            page.HtmlPath = @"D:\Git Repo\Pankaj\aspx-handler\anansi\WebServer.Core\Tspx\index.html";
            page.Form = form;

            tspx.RunPage(page);
            return GenerateResponse(page.HtmlPath);
        }

        private IHttpResponse GenerateResponse(string filePath)
        {
            if (!File.Exists(filePath))
                return FileNotFoundResponse();
            else
                return SuccessResponse(filePath);
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
