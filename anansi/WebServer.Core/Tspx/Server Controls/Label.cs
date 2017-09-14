using System;
using System.Text;

namespace Tsp.Net.Controls
{
    public class Label:Control
    {
        public string Id { get; set; }
        public string Text { get; set; }
        

        internal override void OnInit(EventArgs e)
        {

        }

        internal override void OnPreRender(EventArgs e)
        {

        }

        internal override void Render(HtmlTextWriter textWriter)
        {

        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<Label ");
            if (Id.Length != 0)
                sb.Append($"id = {Id} ");            
            sb.Append($"> {Text} ");
            sb.Append("</Label>");
            return sb.ToString();
        }
    }
}
