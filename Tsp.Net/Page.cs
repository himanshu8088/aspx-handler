using System;
using System.IO;

namespace Tsp.Net
{
    public class Page
    {
        //private HtmlForm _htmlForm;
        //private FileInfo _fileInfo;
        //private Form _form;

        public Page()
        {
            HtmlForm htmlForm = new HtmlForm();
            var designPath = @"F:\Work\Git Repo\aspx-handler\WebForm\Tsp.Net\Default.tspx";
            FileInfo fileInfo = new FileInfo(designPath);

            FormFactory formFactory = new FormFactory();
            var form = formFactory.Create(designPath);

            var htmlFilePath = Path.Combine(fileInfo.DirectoryName, "index.html");
            htmlForm.Construct(htmlFilePath,form);
        }

        protected virtual void OnPreInit(EventArgs e)
        {
            
        }

        protected virtual void OnInit(EventArgs e)
        {
           
        }

        protected virtual void OnRender(EventArgs e)
        {
            
        }
    }
}
