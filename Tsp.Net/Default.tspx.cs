using System;
using Tsp.Net.Controls;
namespace Tsp.Net
{
    public class PageDefault : Page
    {
        Button btn0 = new Button();
        Label lbl0 = new Label();

        public PageDefault()
        {
            btn0.Text = "button1";
            PreInit += PreInitHandler;
            OnPreInit(EventArgs.Empty);
        }

        protected void PreInitHandler(object sender, EventArgs args)
        {
            Console.WriteLine(btn0);             
        }
    }
}