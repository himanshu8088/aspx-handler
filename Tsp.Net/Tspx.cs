using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsp.Net
{
    public class Tspx
    {
        private string _tspxPath;

        public Tspx(string tspxPath)
        {
            _tspxPath = tspxPath;
        }
        public void CreateCodeBehindTemplate()
        {                        
            Page page = new Page(_tspxPath);
            CodeBehindTextWriter template = new CodeBehindTextWriter();
            FileInfo fi = new FileInfo(_tspxPath);
            var codeBehindPath = Path.Combine(fi.DirectoryName, $"{fi.Name}.cs");
            template.Write(codeBehindPath, page.TspxForm);       
        }
    }
}
