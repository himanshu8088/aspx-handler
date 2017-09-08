using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsp.Net.Controls
{
    public class Button : Control
    {
        public override string Id { get; set; }
        public override string Text { get; set; }

        public event EventHandler Click;


        protected void OnClick(EventArgs e)
        {
            Click(this, e);
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<Button ");
            if (Id.Length != 0)
                sb.Append($"id = {Id} ");
            if (Click != null)
                sb.Append($"onclick = \"alert('Button Clicked');\" ");
            sb.Append($"> {Text} ");
            sb.Append("</Button>");
            return sb.ToString();
        }
    }
}
