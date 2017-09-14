using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace WebServer.Core
{
    public class Resolver
    {
        public string ResolvePhysicalPath(string baseDirectory, IHttpRequest request)
        {
            var virtualPath = Uri.UnescapeDataString(request.Url);
            if (virtualPath == "/")
                virtualPath = "index.html";
            else
            {
                virtualPath = SanitizeBasedOnOS(virtualPath);
                // Trim the starting slash
                virtualPath = virtualPath.Substring(1);
            }

            return Path.Combine(baseDirectory, virtualPath);
        }

        private string SanitizeBasedOnOS(string url)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return url.Replace("/", @"\");
            else return url;
        }
    }
}
