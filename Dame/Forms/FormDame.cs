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
    public partial class FormDame : Form
    {
        public FormDame()
        {
            InitializeComponent();


        }
        public List<Patratel> patratele = new List<Patratel>();

        List<Patratel_Inchis> PatrateleInchise;

        protected override void OnPaint(PaintEventArgs e)
        {


            //this.Controls.Add(p);


            base.OnPaint(e);
        }
        Joc joc;
        private void Form1_Load(object sender, EventArgs e)
        {
            PatrateleInchise = new List<Patratel_Inchis>() { patratel_Inchis1, patratel_Inchis2, patratel_Inchis3, patratel_Inchis4, patratel_Inchis5, patratel_Inchis6, patratel_Inchis7, patratel_Inchis8, patratel_Inchis9, patratel_Inchis10, patratel_Inchis11, patratel_Inchis12, patratel_Inchis13, patratel_Inchis14, patratel_Inchis15, patratel_Inchis16, patratel_Inchis17, patratel_Inchis18, patratel_Inchis19, patratel_Inchis20, patratel_Inchis21, patratel_Inchis22, patratel_Inchis23, patratel_Inchis24, patratel_Inchis25, patratel_Inchis26, patratel_Inchis27, patratel_Inchis28, patratel_Inchis29, patratel_Inchis30, patratel_Inchis31, patratel_Inchis32 };


            joc = new Joc(PatrateleInchise, this);

            joc.Start();

        }

        private void buttonJocNou_Click(object sender, EventArgs e)
        {
            joc.CurataTabla();
            joc = new Joc(PatrateleInchise, this);
            joc.Start();
        }
    }
}

