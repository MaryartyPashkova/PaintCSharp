using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paint
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
        }
        Graphics gr;
        private void Form1_Load(object sender, EventArgs e) {
            gr = panel1.CreateGraphics();
            

        }
        List<figures> points = new List<figures>();
        private void panel1_MouseClick(object sender, MouseEventArgs e) {
            if (radioButton1.Checked == true) {
                figures fig = new figures();
                fig = new rectangle();
                fig.Draw(gr, e.X, e.Y);
            }
            else if(radioButton2.Checked == true) {
                figures fig = new figures();
                fig = new circle();
                fig.Draw(gr, e.X, e.Y);
            }
            else {
                //for (var i = figures.Count - 1; i >= 0; i--)
                //    if (figures[i].HitTest(e.Location)) { selectedShape = Shapes[i]; break; }
                //if (selectedShape != null) { moving = true; previousPoint = e.Location; }
                //base.OnMouseDown(e);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            radioButton1.Checked = false;
            radioButton2.Checked = false;

        }
    }
}
