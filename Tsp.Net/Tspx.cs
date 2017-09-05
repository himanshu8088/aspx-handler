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
        public void Run()
        {
            var designPath = @"F:\Work\Git Repo\aspx-handler\WebForm\Tsp.Net\Default.tspx";
            FileInfo fileInfo = new FileInfo(designPath);

            FormFactory formFactory = new FormFactory();
            var form=formFactory.Create(designPath);        

            CodeBehindTemplate template = new CodeBehindTemplate();
            var codeBehindPath = Path.Combine(fileInfo.DirectoryName, $"{fileInfo.Name}.cs");            
            template.Construct(codeBehindPath,form);

            Page page = new Page();
        }
    }
}
