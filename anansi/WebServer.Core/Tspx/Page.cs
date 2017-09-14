using System;
using System.Collections.Generic;
using System.IO;

namespace Tsp.Net
{
    public class Page:Control
    {        
        public Form Form { get; set; }        
        public string HtmlPath { get; set; }
               
        public event EventHandler PreInit;                

        internal virtual void OnPreInit(EventArgs e)
        {            
        }

        internal override void Render(HtmlTextWriter writer)
        {
            writer.Write(Form, HtmlPath);
        }
    }
}
