using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Самойлов_Задаие_1
{
    public class figur
    {
        public int width;
        public int height;
        public Color color;
        public Point point;

        public figur()
        {
            width = 50;
            height = 50;
            //Random randomGen = new Random();
            //KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            //KnownColor randomColorName = names[randomGen.Next(names.Length)];
            //color = Color.FromKnownColor(randomColorName);
            //color = new_color;
        }
        public figur(int Width, int Height, Color Color)
        {
            width = Width;
            height = Height;
            color = Color;
        }
        public virtual void Draw(Color p, Graphics g, int x, int y)
        {

        }
      
    }
    public class rectangle : figur
    {
        public rectangle(int wight, int height, Color color) : base( wight, height, color)
        {

        }

        public rectangle()
        {

        }

        public override void Draw(Color p, Graphics g, int x, int y)
        {
            Pen pen = new Pen(p, 1);
            g.DrawRectangle(pen, x, y, width, height);

        }
    }
    public class circle : figur
    {

        public Point center { get; set; }
        public int radious { get; set; }
        public circle(int wight, int height, Color color, Point Center, int Radious) : base(wight, height, color)
        {
            center = Center;
            radious = Radious;
        }

        public circle()
        {

        }

        public override void Draw(Color p, Graphics g, int x, int y)
        {
            Pen pen = new Pen(p, 1);
            center = new Point(x + width / 2, y + height / 2);
            g.DrawEllipse(pen, x, y,width, height);
            //using (var path = GetPath())
            //    g.DrawPath(pen, path);

        }
        //public void Move(Point d)
        //{
        //    center = new Point(center.X + d.X, center.Y + d.Y);
        //}
        public GraphicsPath GetPath()
        {
            var path = new GraphicsPath();
            var p = center;
            p.Offset(-radious, -radious);
            path.AddEllipse(p.X, p.Y, 2 * radious, 2 * radious);
            return path;
        }
        //public bool HitTest(Point p)
        //{
        //    var result = false;
        //    using (var path = GetPath())
        //        result = path.IsVisible(p);
        //    return result;
        //}
    }
}
