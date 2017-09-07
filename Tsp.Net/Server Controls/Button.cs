using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsp.Net.Controls
{
    public class Button: Control
    {
        public string Id { get; set; }
        public string Text { get; set; }

        public event EventHandler Click;

        
        protected void OnClick(EventArgs e)
        {
            Click(this, e);
        }
    }
}
