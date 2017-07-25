using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dame
{
    public class Patratel_Inchis : Patratel
    {

        public PictureBox picbox;
        public int ID;
        public Joc joc;
        public Patratel_Inchis()
        {
            this.BackColor = Color.Brown;
            this.Click += Patratel_Inchis_Click;

        }

        private void Patratel_Inchis_Click(object sender, EventArgs e)
        {

            joc.OnClick(this);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

    }
}
