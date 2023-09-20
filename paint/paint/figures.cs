using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace paint
{
    public class figures
    {
        public int wight {
            get; set;
        }
        
        public int height { get; set; }
        public Color color { get; set; }
        public Point point;
        public figures() {
            wight = 50;
            height = 50;
            Random randomGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[randomGen.Next(names.Length)];
            color = Color.FromKnownColor(randomColorName);
        }

        public figures(int Width, int Height, Color Color) {
            wight = Width;
            height = Height;
            color = Color;
        }
        public virtual void Draw(Graphics g, int x, int y) {

        }

    }
    public class rectangle : figures {
        public rectangle(int wight, int height, Color color):base(wight,height,color) { 
        
        }

        public rectangle() {

        }

        public override void Draw(Graphics g, int x, int y) {
            Pen pen = new Pen(color, 1);
            g.DrawRectangle(pen, x, y, wight, height);

        }
    }

    public class circle : figures
    {
        
        public Point center { get; set; }
        public int radious { get; set; }
        public circle(int wight, int height, Color color, Point Center, int Radious) : base(wight, height, color) {
            center = Center;
            radious = Radious;
        }

        public circle() {

        }

        public override void Draw(Graphics g, int x, int y) {
            Pen pen = new Pen(color, 1);
            center = new Point(x+wight/2, y+height/2);
            using (var path = GetPath())
                g.DrawPath(pen, path);

        }
        public void Move(Point d) {
            center = new Point(center.X + d.X, center.Y + d.Y);
        }
        public GraphicsPath GetPath() {
            var path = new GraphicsPath();
            var p = center;
            p.Offset(-radious, -radious);
            path.AddEllipse(p.X, p.Y, 2 * radious, 2 * radious);
            return path;
        }
        public bool HitTest(Point p) {
            var result = false;
            using (var path = GetPath())
                result = path.IsVisible(p);
            return result;
        }
    }

}
