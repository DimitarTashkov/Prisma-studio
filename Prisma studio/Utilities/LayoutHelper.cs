using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOazis.Utilities
{
    public class LayoutHelper
    {
        public static void set_FormBackground(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Panel panel = sender as Panel;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, panel.Width, panel.Height);

            //define gradient's properties
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(28, 231, 233), Color.FromArgb(242, 255, 147), 90f);

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }
    }
}
