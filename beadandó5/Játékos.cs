using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beadandó5
{
    class Játékos
    {
//Adattagok és tulajdonságaik
        

       
        string név;

        public string Név
        {
            get { return név; }
            set { név = value; }
        }

        int hanyadik;

        public int Hanyadik
        {
            get { return hanyadik; }
            set { hanyadik = value; }
        }

        Lap[] kez;

        public Lap[] Kez
        {
            get { return kez; }
           
        }

        int elvittSzámítottLap = 0;

        public int ElvittSzámítottLap
        {
            get { return elvittSzámítottLap; }
            set { elvittSzámítottLap += value; }
        }

        Pakli pakli;

        private int kezSzáma;

        public int KezSzáma
        {
            get { return kezSzáma; }
            
        }

        


//Konstruktor
        public Játékos(int kezSzáma, Pakli pakli)
        {
            kez = new Lap[kezSzáma];
            this.pakli = pakli;
            this.kezSzáma = kezSzáma;
           
        }

        public void egyKez()
        {
//hányat osztunk egyszerre
            int egyszerre = 0;
            if (kezSzáma == 8)
            {
                egyszerre = 4;
            }
            else if (kezSzáma == 5)
            {
                egyszerre = 5;
            }

//kiosztjuk a lapokat 
            for (int i = 0; i < egyszerre; i++)
            {
                kez[i] = pakli.Pakli1[pakli.OsztásFelügyelő];
                pakli.Pakli1[pakli.OsztásFelügyelő].Kié = hanyadik;
                pakli.OsztásFelügyelő++;
            }
            if (egyszerre == 4)
            {
                for (int j = egyszerre; j < kez.Length; j++)
                {
                    int átmeneti = pakli.OsztásFelügyelő + 8 + j;
                    kez[j] = pakli.Pakli1[átmeneti];
                    pakli.Pakli1[átmeneti].Kié = hanyadik;

                }
            }

        }
        
//kiveszünk egy lapot és értékét nullra állítjuk
        public Lap lapKivesz(int index)
        {
            Lap lap = kez[index];
            kez[index] = null;

            return lap;

        }

    }
}
