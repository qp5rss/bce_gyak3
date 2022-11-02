using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qp5rss_gyak6.Abstractions;

namespace qp5rss_gyak6.Entities
{
    public class Car : Toy
    {
        public Car()
        {

        }

        protected override void DrawImage(Graphics g)
        {
            Image imageFile = Image.FromFile("Images/car.png");
            g.DrawImage(imageFile, new Rectangle(0, 0, Width, Height));
        }
    }
}
