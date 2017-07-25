using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dame
{
    public partial class Piesa : UserControl
    {
        public int Linie;
        public int Coloana;

        public bool Rege;
        public int PlayerId; //0 Rosu  ;   1 Negru
        Patratel_Inchis Parinte;
        Joc joc;
    

        public Piesa(int id, Patratel_Inchis P, Joc joc)
        {
            InitializeComponent();
            Linie = P.Linie;
            Coloana = P.Coloana;
            PlayerId = id;
            Parinte = P;
            this.joc = joc;
            Rege = false;

            if (id == 1)
            {
                picBox.Image = Dame.Properties.Resources.PiesaNeagra;
            }
            else
            {
                picBox.Image = Dame.Properties.Resources.PiesaRosie;
            }
            
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox.Width = 45;
            picBox.Height = 45;
            picBox.BringToFront();
            picBox.Click += Piece_Click;
        }

        private void Piece_Click(object sender, EventArgs e)
        {
            joc.OnClick(Parinte);


        }
        public string Culoare()
        {
            if (PlayerId == 0)
                return "rosu";

            return "negru";
        }
        public void transformaInRege()
        {
            if (Rege == true)
                return;
            Rege = true;
            if (PlayerId==1)
                picBox.Image = Dame.Properties.Resources.RegeNegru;
            else
                picBox.Image = Dame.Properties.Resources.RegeRosu;

        }
        public override bool Equals(object piesa)
        {
            if (piesa == null)
                return false;
            var p = piesa as Piesa;
            return (p.Linie == this.Linie && p.Coloana == this.Coloana);
        }
    }

}
