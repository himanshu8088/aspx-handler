using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebServer.Core
{
    public interface IContent
    {
        Stream GetStream();

        string ContentType { get; }
    }

    public class ReadonlyFileContent : IContent
    {
        private readonly string _path;

        public ReadonlyFileContent(string path, string contentType)
        {
            _path = path;
            ContentType = contentType;
        }

        public string ContentType { get; private set; }

        public Stream GetStream()
        {
            return new FileStream(_path, FileMode.Open, FileAccess.Read);
        }
    }
}
