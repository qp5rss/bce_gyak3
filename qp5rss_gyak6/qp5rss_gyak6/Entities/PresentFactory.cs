using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qp5rss_gyak6.Abstractions;

namespace qp5rss_gyak6.Entities
{
    public class PresentFactory : IToyFactory
    {
        public Color FirstColor { get; set; }  
        public Color SecondColor { get; set; }

        public Toy CreateNew()
        {
            return new Present(FirstColor, SecondColor);
        }
    }
}
