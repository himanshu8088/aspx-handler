using System;
using System.IO;

namespace Tsp.Net
{
    public class Control
    {
        public event EventHandler Init;
        public event EventHandler Load;
        public event EventHandler PreRender;

        public virtual string Id { get; set; }
        public virtual string Text { get; set; }

        internal virtual void OnInit(EventArgs e)
        {

        }

        internal virtual void OnPreRender(EventArgs e)
        {

        }

        internal virtual void OnLoad(EventArgs e)
        {

        }

        internal virtual void Render(HtmlTextWriter writer)
        {

        }       
    }
}