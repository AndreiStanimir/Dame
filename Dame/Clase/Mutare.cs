using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame
{
    class Mutare
    {
        public Patratel_Inchis patratelStart;
        public Patratel_Inchis patratelDestinatie;
        //Patratel_Inchis p;
        public Mutare()
        {
            patratelStart = null;
            patratelDestinatie = null;
        }
        public Mutare(Patratel_Inchis p1,Patratel_Inchis  p2)
        {
            patratelStart = p1;
            patratelDestinatie = p2;
        }
        public bool SuntAdiacente(string culoare)
        {
           
            if (culoare  == "negru")
            {
                if ((patratelStart.Linie - 1 == patratelDestinatie.Linie) && (patratelStart.Coloana - 1 == patratelDestinatie.Coloana))
                    return true;
                if ((patratelStart.Linie - 1 == patratelDestinatie.Linie) && (patratelStart.Coloana + 1 == patratelDestinatie.Coloana))
                    return true;
            }
            if (culoare == "rosu")
            {
                if ((patratelStart.Linie + 1 == patratelDestinatie.Linie) && (patratelStart.Coloana - 1 == patratelDestinatie.Coloana))
                    return true;
                if ((patratelStart.Linie + 1 == patratelDestinatie.Linie) && (patratelStart.Coloana + 1 == patratelDestinatie.Coloana))
                    return true;
            }
            if (culoare == "rege")
            {
                if ((patratelStart.Linie - 1 == patratelDestinatie.Linie) && (patratelStart.Coloana - 1 == patratelDestinatie.Coloana))
                    return true;
                if ((patratelStart.Linie - 1 == patratelDestinatie.Linie) && (patratelStart.Coloana + 1 == patratelDestinatie.Coloana))
                    return true;
                if ((patratelStart.Linie + 1 == patratelDestinatie.Linie) && (patratelStart.Coloana - 1 == patratelDestinatie.Coloana))
                    return true;
                if ((patratelStart.Linie + 1 == patratelDestinatie.Linie) && (patratelStart.Coloana + 1 == patratelDestinatie.Coloana))
                    return true;
            }
            return false;

        }
        public Patratel_Inchis SarituraValida(string culoare,Patratel_Inchis[,] matrice)
        {
            Patratel_Inchis p = null;
            if (patratelDestinatie.Piesa != null)
                return p;
            if(patratelStart.Piesa.Rege)
            {
                if ((patratelStart.Linie + 2 == patratelDestinatie.Linie) && (patratelStart.Coloana - 2 == patratelDestinatie.Coloana))
                    return matrice[patratelStart.Linie + 1, patratelStart.Coloana - 1];
                if ((patratelStart.Linie + 2 == patratelDestinatie.Linie) && (patratelStart.Coloana + 2 == patratelDestinatie.Coloana))
                    return matrice[patratelStart.Linie + 1, patratelStart.Coloana + 1];
                if ((patratelStart.Linie - 2 == patratelDestinatie.Linie) && (patratelStart.Coloana - 2 == patratelDestinatie.Coloana))
                    return matrice[patratelStart.Linie - 1, patratelStart.Coloana - 1];
                if ((patratelStart.Linie - 2 == patratelDestinatie.Linie) && (patratelStart.Coloana + 2 == patratelDestinatie.Coloana))
                    return matrice[patratelStart.Linie - 1, patratelStart.Coloana + 1];
            }
            if (culoare == "negru")
            {
                if ((patratelStart.Linie - 2 == patratelDestinatie.Linie) && (patratelStart.Coloana - 2 == patratelDestinatie.Coloana))
                    return matrice[patratelStart.Linie - 1, patratelStart.Coloana - 1];
                if ((patratelStart.Linie - 2 == patratelDestinatie.Linie) && (patratelStart.Coloana + 2 == patratelDestinatie.Coloana))
                    return matrice[patratelStart.Linie - 1, patratelStart.Coloana + 1];
            }
            if (culoare == "rosu")
            {
                
                if ((patratelStart.Linie + 2 == patratelDestinatie.Linie) && (patratelStart.Coloana - 2 == patratelDestinatie.Coloana))
                    return matrice[patratelStart.Linie + 1, patratelStart.Coloana - 1];
                if ((patratelStart.Linie + 2 == patratelDestinatie.Linie) && (patratelStart.Coloana + 2 == patratelDestinatie.Coloana))
                    return matrice[patratelStart.Linie + 1, patratelStart.Coloana + 1];
            }
            return p;
        }

    }
}
