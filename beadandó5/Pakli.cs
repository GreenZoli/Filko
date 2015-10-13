using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beadandó5
{
    class Pakli
    {
//Adattagok:
        static Random r = new Random();
        Lap[] pakli;

        public Lap[] Pakli1
        {
            get { return pakli; }
            
        }

        string adu;

        public string Adu
        {
            get { return adu; }
            
        }

        int játékosDb;

        public int JátékosDb
        {
            get { return játékosDb; }
            
        }
        int osztásFelügyelő = 0;

        public int OsztásFelügyelő
        {
            get { return osztásFelügyelő; }
            set { osztásFelügyelő = value; }
        }

      
//Konstruktor 
        public Pakli(int lapokSzáma, int játékosDb)
        {
            pakli = new Lap[lapokSzáma];
            this.játékosDb = játékosDb;
            
        }

//Metódusok 
//Minden Laphoz hozzárendelünk egy értéket az "Érték" enumból és a "Szín" enumból és ezt beletöltjük egy tömbbe
        public void Készít()
        {
            
            if (játékosDb == 4)
            {
                int k = 0;
                for (int i = 0; i < Enum.GetNames(typeof(Szín)).Length; i++)
                {

                    for (int j = 0; j < Enum.GetValues(typeof(Érték)).Length; j++)
                    {
                        pakli[k] = new Lap(((Szín)i).ToString(), ((int)(Érték)j));
                        k++;
                    }
                }
            }
            else if(játékosDb == 6)
            {
                 int k = 0;
            for (int i = 0; i < Enum.GetNames(typeof(Szín)).Length; i++)
            {
                
                for (int j = 0; j < Enum.GetNames(typeof(Érték)).Length; j++)
                {
                    if (((Szín)i).ToString() == "Tök" && ((Érték)j).ToString() != "VII" || ((Szín)i).ToString() == "Zöld" && ((Érték)j).ToString() != "VII" || ((Szín)i).ToString() == "Piros" || ((Szín)i).ToString() == "Makk")
                    {
                        pakli[k] = new Lap(((Szín)i).ToString(), ((int)(Érték)j));
                        k++;
                    }
                    
                  
                    
                }
            }
            
            }
           
            
        }

//Előzőleg létrehozott paklit bekeverjük
        public void Kever()
        {
            Lap segéd;
            int random_index = 0;

            for (int i = pakli.Length - 1; i > 0; i--)
            {
                
                random_index = r.Next(i + 1);
                segéd = pakli[i];
                pakli[i] = pakli[random_index];
                pakli[random_index] = segéd;


            }
            
            
        }

//A kevert paklinkból kihúzunk egy adut
        public void Aduthuz(int lapokSzáma)
        {
            while(Adu == null)
            {
                int aduIndex = r.Next(0,lapokSzáma);
                if(pakli[aduIndex].Érték != (int)Érték.Felső)
                    {
                        adu = pakli[aduIndex].Szín;
                    }
            }
        }
        public void AduReset()
        {
            adu = null;
        }


    }


}
