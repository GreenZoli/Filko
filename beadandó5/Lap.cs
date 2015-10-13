using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beadandó5
{
    class Lap
    {
//lapok tulajdonságai
        string szín;

        public string Szín
        {
            get { return szín; }
            set { szín = value; }
            
            
        }
        int érték;

        public int Érték
        {
            get { return érték; }
            set { érték = value; }
            
        }

//melyik játékosnál van a lap
        int kié;

        public int Kié
        {
            get { return kié; }
            set { kié = value; }
        }

       
//Konstruktor
        public Lap(string szín,int érték)
        {
            this.szín = szín;
            this.érték = érték;
        }


    }
}
