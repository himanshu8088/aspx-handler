using System;

namespace Tsp.Net.Controls
{
    public class Label:Control
    {
        public string Id { get; set; }
        public string Text { get; set; }

        public event EventHandler TextChanged;

        protected internal override void OnInit(EventArgs e)
        {

        }

        protected internal override void OnPreRender(EventArgs e)
        {

        }

        protected internal override void Render(HtmlTextWriter writer)
        {

        }

        protected void OnTextChanged(EventArgs e)
        {
            TextChanged(this, e);
        }
    }
}
