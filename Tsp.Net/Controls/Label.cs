using System;

namespace Tsp.Net.Controls
{
    public class Label
    {
        public string Id { get; set; }
        public string Text { get; set; }

        public event EventHandler TextChanged;
    }
}
