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

        protected internal virtual void OnInit(EventArgs e)
        {            
            if (Init != null)
                Init(this, e);
            OnLoad(EventArgs.Empty);
        }

        protected internal virtual void OnPreRender(EventArgs e)
        {
            if(PreRender!=null)
                 PreRender(this, e);
            Render();
        }

        protected internal virtual void OnLoad(EventArgs e)
        {            
            if (Load != null)
                Load(this, e);
            OnPreRender(EventArgs.Empty);
        }

        protected internal virtual void Render()
        {

        }

        public virtual string ToString()
        {
            return String.Empty;
        }
    }
}