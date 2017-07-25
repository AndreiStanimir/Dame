using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dame
{
    public class Joc
    {
        const int InaltimeTabla = 8;
        const int LatimeTabla = 8;

        List<Patratel_Inchis> patrateleInchise;
        private Patratel_Inchis[,] matrice;

        public List<MutareID> primulJucator = new List<MutareID>();
        public List<MutareID> alDoileaJucator = new List<MutareID>();

        Mutare mutareCurenta;
        string tura = "negru";
        Patratel_Inchis pColorat;
        string castigator = null;
        Label labelEroare;
        public Joc(List<Patratel_Inchis> patrateleInchise,FormDame form)
        {
            this.patrateleInchise = patrateleInchise;
            matrice = new Patratel_Inchis[InaltimeTabla, LatimeTabla];
            labelEroare = form.labelRand;
        }
        public void Start()
        {
            InitializareMatrice();
            AdaugaPiese();
           
        }

        public void OnClick(Patratel_Inchis pClicked)
        {
            labelEroare.Visible = false;
            if (pClicked == pColorat) //click pe aceasi piesa
            {
                pColorat.BackColor = Color.Brown;
                pColorat = null;
                mutareCurenta = null;
                return;
            }
            if (pColorat != null)
            {

                pColorat.BackColor = Color.Brown;

                pColorat = null;
            }

            if (mutareCurenta == null)
                mutareCurenta = new Mutare();

            if (mutareCurenta.patratelStart != null && mutareCurenta.patratelDestinatie == null)
            {
                mutareCurenta.patratelDestinatie = pClicked;
            }
            else if (mutareCurenta.patratelStart == null && pClicked.Piesa != null)
            {
                if ((pClicked.Piesa.Culoare() != tura))
                {
                    labelEroare.Text = "Este randul lui " + tura;
                    labelEroare.Visible = true;
                    return;
                }
                mutareCurenta.patratelStart = pClicked;
                pClicked.BackColor = Color.Green;
                pColorat = pClicked;
                //pColorat.BackColor = Color.gre;

            }



            var p1 = mutareCurenta.patratelStart;
            var p2 = mutareCurenta.patratelDestinatie;

            if (VerificaMutare(p1, p2))
            {
                if (p1.Piesa.Rege == true && mutareCurenta.SuntAdiacente("rege"))
                    MutaPiesele(p1, p2);

                else if (mutareCurenta.SuntAdiacente(tura))
                {
                    MutaPiesele(p1, p2);
                }
                Patratel_Inchis p = mutareCurenta.SarituraValida(tura, matrice);
                if (p != null)
                {
                    SchimaPieseleInMatrice(p1, p2);
                    StergePiesa(p);
                    if (tura == "negru")
                    {
                        if (p2.Piesa.Rege)
                        {
                            p2.Piesa = new Piesa(1, p2, this);
                            p2.Piesa.transformaInRege();
                        }
                        else
                        {
                            p2.Piesa = new Piesa(1, p2, this);
                        }
                        if (p2.Piesa.Linie == 0)
                        {
                            p2.Piesa.transformaInRege();
                        }
                    }
                    else
                    {
                        if (p2.Piesa.Rege)
                        {
                            p2.Piesa = new Piesa(0, p2, this);
                            p2.Piesa.transformaInRege();
                        }
                        else
                        {
                            p2.Piesa = new Piesa(0, p2, this);
                        }
                        if (p2.Piesa.Linie == 7)
                        {
                            p2.Piesa.transformaInRege();
                        }
                    }
                    p2.Controls.Add(p2.Piesa);
                    StergePiesa(p1);
                }
                mutareCurenta.patratelStart = null;
                mutareCurenta.patratelDestinatie = null;

            }
            castigator = VerificaCastigator();
            if(castigator!=null)
            {
                System.Windows.Forms.MessageBox.Show(castigator);
                
            }

        }

        private void MutaPiesele(Patratel_Inchis p1, Patratel_Inchis p2)
        {
            SchimaPieseleInMatrice(p1, p2);
            if (tura == "negru")
            {
                if (p2.Piesa.Rege)
                {
                    p2.Piesa = new Piesa(1, p2, this);
                    p2.Piesa.transformaInRege();
                }
                else
                {
                    p2.Piesa = new Piesa(1, p2, this);
                }
                if (p2.Piesa.Linie == 0)
                {
                    p2.Piesa.transformaInRege();
                }
            }
            else
            {
                if (p2.Piesa.Rege)
                {
                    p2.Piesa = new Piesa(0, p2, this);
                    p2.Piesa.transformaInRege();
                }
                else
                {
                    p2.Piesa = new Piesa(0, p2, this);
                }

                if (p2.Piesa.Linie == 7)
                {
                    p2.Piesa.transformaInRege();
                }
            }
            p2.Controls.Add(p2.Piesa);
            StergePiesa(p1);

            if (tura == "rosu")
                tura = "negru";
            else
                tura = "rosu";
        }

        private void SchimaPieseleInMatrice(Patratel_Inchis p1, Patratel_Inchis p2)
        {
            var t = matrice[p2.Linie, p2.Coloana].Piesa;
            matrice[p2.Linie, p2.Coloana].Piesa = matrice[p1.Linie, p1.Coloana].Piesa;
            matrice[p1.Linie, p1.Coloana].Piesa = t;
        }

        private static void StergePiesa(Patratel_Inchis p1)
        {
            p1.Piesa = null;
            p1.Controls.Clear();
            p1.BackColor = Color.Brown;
        }

        void deBugPrint()
        {
            for (int i = 0; i < InaltimeTabla; i++)
            {
                for (int j = 0; j < LatimeTabla; j++)
                {
                    if (matrice[i, j] != null)
                    {
                        if (matrice[i, j].Piesa != null)
                            Console.Write(1 + " ");

                        else

                            Console.Write("0" + " ");

                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private bool VerificaMutare(Patratel_Inchis p1, Patratel_Inchis p2)
        {
            if (p1 == null || p2 == null)
                return false;
            if (p1.Piesa != null && p2.Piesa != null)
            {
                return false;
            }
            if (p1.Piesa == null)
                return false;
            if (p1.Piesa.Equals(p2.Piesa))
            {
                mutareCurenta = null;
                return false;
            }
            if (p1.Piesa.Culoare() != tura)
            {
                mutareCurenta = null;
                //System.Windows.Forms.MessageBox.Show();
                labelEroare.Text = "Este randul lui " + tura;
                labelEroare.Visible = true;
                return false;
            }
            return true;
        }

        private void InitializareMatrice()
        {
            for (int i = 0; i < InaltimeTabla; i++)
            {
                int j = 0;
                if (i % 2 == 0)
                    j = 1;

                for (; j < LatimeTabla; j += 2)
                {
                    matrice[i, j] = patrateleInchise[i * 4 + j / 2];
                    matrice[i, j].ID = i * 4 + j / 2 + 1;
                    matrice[i, j].joc = this;
                    matrice[i, j].Linie = i;
                    matrice[i, j].Coloana = j;
                }
            }

        }

        private void AdaugaPiese()
        {
            for (int i = 0; i < 3; i++)
            {
                int j = 0;
                if (i % 2 == 0)
                    j = 1;
                for (; j < LatimeTabla; j += 2)
                {
                    CreazaPiesaInchisa(matrice[i, j], i, j);
                    AdaugaPiesaInPatratel(i, j);
                }
            }
            for (int i = 5; i < 8; i++)
            {
                int j = 0;
                if (i % 2 == 0)
                    j = 1;
                for (; j < LatimeTabla; j += 2)
                {
                    CreazaPiesaDeschisa(matrice[i, j], i, j);
                    AdaugaPiesaInPatratel(i, j);
                }
            }

        }
        public void CurataTabla()
        {
            foreach(Patratel_Inchis p in patrateleInchise)
            {
                StergePiesa(p);
                //p.Piesa.picBox.Dispose();
                
            }
        }

        string VerificaCastigator()
        {
            int nrPieseNegre = 0;
            int nrPieseRosii = 0;
            foreach (var p in patrateleInchise)
            {
                if (p.Piesa != null)
                {
                    if (p.Piesa.Culoare() == "negru")
                        nrPieseNegre++;
                    else
                        nrPieseRosii++;
                }
            }
            if (nrPieseNegre == 0)
                return "Rosu a castigat!";
            if (nrPieseRosii == 0)
                return "Negru a castigat!";

            return null;
        }

        private void AdaugaPiesaInPatratel(int i, int j)
        {
            matrice[i, j].Controls.Add(matrice[i, j].Piesa);
        }

        private void CreazaPiesaInchisa(Patratel_Inchis p, int l, int c)
        {
            p.Piesa = new Piesa(0, matrice[l, c], this);

        }

        private void CreazaPiesaDeschisa(Patratel_Inchis p, int l, int c)
        {
            p.Piesa = new Piesa(1, matrice[l, c], this);
        }

        private bool SuntCoordonateleIntreLimiteleMesei(int i, int j)
        {
            return i >= 0 && i < 8 && j >= 0 && j < 8;
        }
    }
    
}
