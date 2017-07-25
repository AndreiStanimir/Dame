using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dame
{
    public partial class Patratel : Control
    {

            public Piesa Piesa;
            public int Linie;
            public int Coloana;

        public Patratel()
        {
            InitializeComponent();
            //picbox = pictureBox1;
            Size = new Size(100, 100);
            Padding = new Padding(0);
            Margin = new Padding(0);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
