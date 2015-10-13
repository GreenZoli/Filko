using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace beadandó5
{
    class Játszma
    {
//Adattagok:
        static Random r2 = new Random();
        public static int kiírFigyelő = 0;
        string[] KiírTömb;

        public string[] KiírTömb1
        {
            get { return KiírTömb; }
            set { KiírTömb = value; }
        }

        string[] újszínSor = Enum.GetNames(typeof(Szín));
       

        public string[] ÚjszínSor
        {
            get { return újszínSor; }
            
        }

        Pakli pakli;
        public Pakli Pakli
        {
            get { return pakli; }
            

        }
        Játékos[] játékosok;

        public Játékos[] Játékosok
        {
            get { return játékosok; }
            
        }
        int lapokSzáma;

        public int LapokSzáma
        {
            get { return lapokSzáma; }

        }

        private int akiOszt;

        public int AkiOszt
        {
            get { return akiOszt; }
            set { akiOszt = value; }
            
        }
        int kezSzáma;

        public int KezSzáma
        {
            get { return kezSzáma; }
            
        }

        Lap[] asztal;

        public Lap[] Asztal
        {
            get { return asztal; }
            
        }

//Konstruktor
        public Játszma(int játékosDb)
        {
            if (játékosDb == 4)
            {
//akiOszt azért 3 mert alapértelmezetten mi osztunk először
                
               lapokSzáma = 32;
               kezSzáma = 8;
            }
            else if (játékosDb == 6) 
            {
                ;
                lapokSzáma = 30;
                kezSzáma = 5;
            }
//tömb amibe mindent kiírunk
            KiírTömb = new string[kezSzáma];

//létrehozzuk a pakli példányt
            pakli = new Pakli(lapokSzáma,játékosDb);

//létrehozzuk az asztal tömbünket amibe beletesszük mindig a lapokat            
            asztal = new Lap[játékosDb];

//játékosok létrehozása
            játékosok = new Játékos[játékosDb];

//játékos tömb feltöltése játékosokkal és közben sorszámozzuk őket ezeket az értékeket adjuk a Lap.Kié tulajdonságnak  
            
            for (int i = 0; i < játékosDb; i++)
            {
                játékosok[i] = new Játékos(kezSzáma,pakli);
                játékosok[i].Hanyadik = i;
                if (i == játékosok.Length - 1)
                {
                    játékosok[i].Név = "Játékos";
                }
                else { játékosok[i].Név = "Gép" + (i + 1); }
            }
            
        }


//Konstruktor2 itt már nem a házigazda fog feltétlenül osztani
        public Játszma(int játékosDb,int akiOszt)
        {
            if (játékosDb == 4)
            {
//akiOszt azért 3 mert alapértelmezetten mi osztunk először
                this.akiOszt = akiOszt;
                lapokSzáma = 32;
                kezSzáma = 8;
            }
            else if (játékosDb == 6)
            {
                this.akiOszt = akiOszt;
                lapokSzáma = 30;
                kezSzáma = 5;
            }
//tömb amibe mindent kiírunk
            KiírTömb = new string[kezSzáma];

//létrehozzuk a pakli példányt
            pakli = new Pakli(lapokSzáma, játékosDb);

//létrehozzuk az asztal tömbünket amibe beletesszük mindig a lapokat            
            asztal = new Lap[játékosDb];

//játékosok létrehozása
            játékosok = new Játékos[játékosDb];

//játékos tömb feltöltése játékosokkal és közben sorszámozzuk őket ezeket az értékeket adjuk a Lap.Kié tulajdonságnak            
            for (int i = 0; i < játékosDb; i++)
            {
                játékosok[i] = new Játékos(kezSzáma, pakli);
                játékosok[i].Hanyadik = i;

                
            }

        }

        public void Létrehoz()
        {

            pakli.Készít();
            pakli.Kever();
            pakli.Aduthuz(LapokSzáma);
            SzínMod(pakli.Adu);
            Kioszt();
            
////ellenőrzésre szánt kiírások
//            for (int i = 0; i < pakli.Pakli1.Length; i++)
//            {
//                Console.WriteLine(pakli.Pakli1[i].Szín + "-" + (Érték)pakli.Pakli1[i].Érték);
//            }
//            Console.WriteLine(pakli.Adu);
//            Console.WriteLine("Új színsor: ");
//            for (int i = 0; i < ÚjszínSor.Length; i++)
//            {
//                Console.WriteLine(ÚjszínSor[i]);
//            }
            
//            Console.WriteLine();
//            for (int i = 0; i < játékosok.Length; i++)
//            {
//                Console.WriteLine(játékosok[i].Név+" Lapjai :"); 
                
//                for (int j = 0; j < játékosok[i].Kez.Length; j++)
//                {
//                    Console.WriteLine(játékosok[i].Kez[j].Szín +"-"+ (Érték)játékosok[i].Kez[j].Érték);
//                }
//                Console.WriteLine();

                
//            }



        }

        public void Kioszt()
        {
            int hanyosztásVolt = 0;

// ne magának osszon
            if (akiOszt < játékosok.Length-1)
            {
                akiOszt++;
            }
            
            else { akiOszt = 0; }
            
//osztás
            for (int i = akiOszt; hanyosztásVolt < játékosok.Length; i++)
            {
                
                játékosok[i].egyKez();
                

//ha a tömb végére értünk, de még nem mindenkinek osztottunk induljunk elölről
                if (i == játékosok.Length - 1 && hanyosztásVolt < játékosok.Length)
                {
                    i = -1;
                }

                akiOszt++;
                hanyosztásVolt++;
            }
           
        }

//A "Szín" enumból létrehozok egy új string tömböt a módosított sorrendel Adu alapján
        public void SzínMod(string adu)
        {
           string segéd;
           
           
            for (int i = újszínSor.Length - 1; i >= 0; i--)
            {
                if (újszínSor[i] == adu)
                {
                    segéd = újszínSor[i];
                    for (int j = i; j < újszínSor.Length - 1; j++)
                    {
                        újszínSor[j] = újszínSor[j + 1];

                    }
                    újszínSor[3] = segéd;
                    i = -1;



                }
            }

        }

//lapok asztalra
        public Lap kezLap( int index, int asztalhely)
        {
            
            
            Lap kezlap = null;

//lapok vizsgálata
             if (játékosok[index].Név == "Gép"+(játékosok[index].Hanyadik+1) )
            {

// ha első lap az asztalon akkor a gép random választ egy nem null lapot
                if (asztalhely == 0)
                {

//randomot úgy választunk, hogy létrehozunk egy akkora tömböt amekkorába elfér az összes lap a kezünkben
//a kezünkben levő lapok száma minden körben csökken ezért van szükség erre
                    int nemNullDb = 0;

//megszámoljuk hány db nem null lap van a kezünkben
                    for (int i = 0; i < játékosok[index].Kez.Length; i++)
                    {
                        if (játékosok[index].Kez[i] != null)
                        {
                            nemNullDb++;
                        }
                    }

//ahány nem null annyi elemszámú int tömböt csinálunk
                    int[] melyLapokMaradtak = new int[nemNullDb];

                    int k = 0;

//ezután az összes nem null lap indexét beletöltjük egy tömbbe így könnyen megtudjuk majd adni melyikre gondolunk
                    for (int i = 0; i < játékosok[index].Kez.Length; i++)
                    {
                        if (játékosok[index].Kez[i] != null)
                        {
                            melyLapokMaradtak[k] = i;
                            k++;
                        }
                        
                        
                        
                    }
                    while (kezlap == null)
                    {
                        
                        int random = r2.Next(0, melyLapokMaradtak.Length-1);

                        Lap randElsőLap = játékosok[index].Kez[melyLapokMaradtak[random]];

                        if (randElsőLap != null)
                        {
                            kezlap = játékosok[index].lapKivesz(melyLapokMaradtak[random]);

                        }
                    }
                }

//ciklus, hogy van e a kézben olyan szinű
                else
                {
                    for (int i = 0; i < játékosok[index].Kez.Length; i++)
                    {
                        if (játékosok[index].Kez[i] != null && játékosok[index].Kez[i].Szín == asztal[0].Szín && játékosok[index].Kez[i].Érték != (int)Érték.Felső)
                        {
                            kezlap = játékosok[index].lapKivesz(i);
                            i = játékosok[index].Kez.Length;
                        }
                    }
                }

// ha volt szín akkor vége ha nem akkor megvizsgálja van-e adu
                if (kezlap == null)
                {

                    for (int i = 0; i < játékosok[index].Kez.Length; i++)
                    {
//ha van egy aduszín azt teszi le
                        if (játékosok[index].Kez[i] != null && játékosok[index].Kez[i].Szín == újszínSor[3])
                        {
                            
                                kezlap = játékosok[index].lapKivesz(i);
                                i = játékosok[index].Kez.Length;

                              
                            
                        }
// ha nincs aduszín akkor egy felső is jó 
                        else if (játékosok[index].Kez[i] != null && játékosok[index].Kez[i].Érték == (int)Érték.Felső)
                        {
                            kezlap = játékosok[index].lapKivesz(i);
                            i = játékosok[index].Kez.Length;
                            
                        }
                    }

                                    }
//ha nincs semmilyen adu akkor bámi jó, de ekkor már nem viheti ezért false
                    if (kezlap == null) 
                    {
                        
                        for (int i = 0; i < játékosok[index].Kez.Length; i++)
                        {
//bármit tegyünk, de csak abból amink van
                            if (játékosok[index].Kez[i] != null)
                            {
                                kezlap = játékosok[index].lapKivesz(i);

                                i = játékosok[index].Kez.Length;
                            }
                        
                        
                        }
                    
                    }

                }

               
            
            else
            {
// Játékos jön: ****                 
//megvizsgáljuk, hogy egyáltalán tud-e tenni a felhasználó megfelelő lapot feleslegesnek tűnik, de másképp nem lehetett vizsgálni jót tesz le vagy nem
                bool vanKártya = false;
                int választ = 0;
                //ciklus, hogy van e a kézben olyan szinű
                if (asztalhely != 0)
                {
                    for (int i = 0; i < kezSzáma; i++)
                    {
                        if (játékosok[index].Kez[i] != null && játékosok[index].Kez[i].Szín == asztal[0].Szín)
                        {
                            vanKártya = true;
                            i = kezSzáma;
                        }
                    }

                    // ha volt szín akkor vége ha nem akkor megvizsgálja van-e adu szín
                    if (vanKártya == false)
                    {

                        for (int i = 0; i < kezSzáma; i++)
                        {
                            if (játékosok[index].Kez[i] != null && játékosok[index].Kez[i].Szín == újszínSor[3] || játékosok[index].Kez[i] != null && játékosok[index].Kez[i].Érték == (int)Érték.Felső)
                            {
                                vanKártya = true;
                                i = kezSzáma;
                            }
                        }

                    }

                    
                }
                else  
                { 

//mi van az asztalon

                    KiírTömb[kiírFigyelő] += "\nEddig lerakott: \n";
                     for (int i = 0; i < asztal.Length; i++)
                    {
                        if (asztal[i] != null)
                        {
                            
                            KiírTömb[kiírFigyelő]+=asztal[i].Szín + "-" + (Érték)asztal[i].Érték + ", ";
                        }
                        else { i = asztal.Length; }
                    }

// ha mi kezdünk tudjunk bármit letenni

                     KiírTömb[kiírFigyelő] += "\n\n\nKezedben lévő lapok: \n";

                     KiírTömb[kiírFigyelő]+=JátékosKézMaradt(index);

                     KiírTömb[kiírFigyelő]+="\nHányadik Lap Legyen? ";
                     Console.WriteLine(KiírTömb[kiírFigyelő]);
                     ConsoleKeyInfo cki = Console.ReadKey();
                     
                     if (cki.Key == ConsoleKey.Escape)
                     {
                         Console.WriteLine("Feladtad a játékot a program kilép\n\n\nNyomj Entert");
                         Console.ReadLine();
                         Environment.Exit(0);
                     }
                     else if (char.IsNumber(cki.KeyChar))
                     {
                         választ = (int)Char.GetNumericValue(cki.KeyChar);

                     }

                    Lap nemGépTesz = játékosok[index].Kez[választ - 1];
                    if(nemGépTesz != null)
                    {
                    kezlap = játékosok[index].lapKivesz(választ - 1); 
                    }
                }
//mi van az asztalon és nem mi teszünk először
                if(kezlap == null)
                {
                    
                    KiírTömb[kiírFigyelő]+="\nEddig lerakott: \n";
                    for (int i = 0; i < asztal.Length; i++)
                    {
                        if (asztal[i] != null)
                        {
                            
                            KiírTömb[kiírFigyelő]+=asztal[i].Szín + "-" + (Érték)asztal[i].Érték + ", ";
                        }
                        else { i = asztal.Length; }
                    }
                }
                    

//itt mi adunk és nagyjából vizsgáljuk, hogy jót tudjunk lerakni
                if (kezlap == null)
                {

                    KiírTömb[kiírFigyelő] += "\n\n\nKezedben lévő lapok: \n";

                    KiírTömb[kiírFigyelő]+=JátékosKézMaradt(index);
                    KiírTömb[kiírFigyelő] += "\nHányadik Lap Legyen? ";
                    while (kezlap == null)
                    {

                        
                        
                        Console.WriteLine(KiírTömb[kiírFigyelő]);
                        ConsoleKeyInfo cki = Console.ReadKey();

                        if (cki.Key == ConsoleKey.Escape)
                        {
                            Console.WriteLine("Feladtad a játékot a program kilép\n\n\nNyomj Entert");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                        else if (char.IsNumber(cki.KeyChar))
                        {
                            választ = (int)Char.GetNumericValue(cki.KeyChar);

                        }
                        //int választ = int.Parse(Console.ReadLine());
                        
                        Lap nemGépTesz = játékosok[index].Kez[választ - 1];

                        //legyen még lap a kezünkben és feleljen meg a kitételeknek
                        if (vanKártya == true)
                        {
                            if (nemGépTesz != null)
                            {

                                //Ha van megfelelő lap a kézben akkor sok lehetőségünk van: színre szín, színre adu,színre felső(ami adu)
                                if (nemGépTesz.Szín == asztal[0].Szín || nemGépTesz.Szín == újszínSor[3] || nemGépTesz.Érték == (int)Érték.Felső)
                                {
                                    kezlap = játékosok[index].lapKivesz(választ - 1); ;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("Nem jó lap. Színre színt kell tenni! Ha nincs akkor adut!");
                                    Console.ResetColor();
                                    
                                }
                            }

                            else 
                            {
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Ezt a lapot már leraktad egyszer!");
                                Console.ResetColor();
                            }
                        }

    //ha nem találtunk megfelelő lapot bármi jó kivéve null
                        else if (nemGépTesz != null) { kezlap = játékosok[index].lapKivesz(választ - 1); }
                        else 
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Ezt a lapot már leraktad egyszer!");
                            Console.ResetColor();
                        }
                    }
                }



            }

// lapok vizsgálatának vége
            return kezlap;






        }

        

//Egy kör vezérlése ki mikor tesz le lapot
        public  void egyKör(int kivitte)
        
        {
            if (asztal[0] != null)
            {
                for (int j = 0; j < asztal.Length; j++)
                {
                    asztal[j] = null;
                }
            }
            int i = 0;

            while (i < játékosok.Length)
            {


                if (kivitte != játékosok.Length)
                {
                    

                    asztal[i] = kezLap(kivitte, i);



                    kivitte++;
                    i++;
                }
                else
                { kivitte = 0; }
                
                

            }


            

        }

//Játékos Maradék lapjainak kilistázása
        public string JátékosKézMaradt(int index)
        {
            string ki = "";
            
            for (int i = 0; i < játékosok[index].Kez.Length; i++)
            {
                if (kezSzáma > 5 && i == kezSzáma / 2) { ki += "\n"; }
                if (játékosok[index].Kez[i] != null)
                {
                    ki += (i+1)+":"+játékosok[index].Kez[i].Szín + "-" + (Érték)játékosok[index].Kez[i].Érték + ", ";
                    
                }
            }
            return ki;
        }

//Az asztalon lévő lapokból kiválasztjuk a legnagyobbat és annak a tulajdonosa viszi
        public int Kivitte()
        {

            Lap legnagyobb = asztal[0];
            int hányJóLap = 0;

//for ciklussal átnézzük az asztal elemeit, hogy tartalmaz-e Ászt vagy X-et, ha tartalmaz növeljük a hányJóLap számát
            for (int i = 0; i < asztal.Length; i++)
            {
                if (asztal[i].Érték == (int)Érték.Ász || asztal[i].Érték == (int)Érték.X)
                {
                    hányJóLap++;
                }
            }
            
//Legnagyobb lap vizsgálása           
            for (int i = 1; i < asztal.Length; i++)
            {

                if (asztal[i].Szín == legnagyobb.Szín)
                {
                    if (asztal[i].Érték > legnagyobb.Érték)
                    {

                        legnagyobb = asztal[i];
                                            
                    }
                }


                else if (asztal[i].Érték == (int)Érték.Felső)
                {

                    if (legnagyobb.Érték == (int)Érték.Felső)
                    {
                        if (Színkeres(legnagyobb.Szín) < Színkeres(asztal[i].Szín))
                        {
                            legnagyobb = asztal[i];


                        }
                    }
                    else
                    {
                        legnagyobb = asztal[i];

                    }

                }
                
                   
                else if (asztal[i].Szín == újszínSor[3])
                {
                    if (legnagyobb.Szín != újszínSor[3] && legnagyobb.Érték != (int)Érték.Felső)
                    {

                       
                            legnagyobb = asztal[i];
                     
                    }
                   

                }

                

            }
//Annak a játékosnak akinek a lapja bizonyult legnagyobbnak jóváírjuk a jó lapok pontját(hányJóLap)
            játékosok[legnagyobb.Kié].ElvittSzámítottLap = hányJóLap;
            return legnagyobb.Kié;


        }

//Egy csúnya megoldás a módosított Színsor nagyságának vizsgálásához
        public int Színkeres(string szín)
        {
            int index = 0;
            for (int i = 0; i < újszínSor.Length; i++)
            {
                if (szín == újszínSor[i])
                {
                    index = i;
                    i = újszínSor.Length;
                }
            }
            return index;
        }

//számoljuk meg hány X-et és Ászt gyüjtöttek a szembenülök
        public string Kinyert(out int kiOszt)
        {
            string kiirni = "";
            int j = 0;
            int melyikCsapat = 0;
            int[] vesztesekIndexe = new int[játékosok.Length - 2];
            int átmeneti = játékosok[0].ElvittSzámítottLap + játékosok[0+(játékosok.Length/2)].ElvittSzámítottLap;

//kiválasztjuk azt a csapatot akik a legtöbbet vitték el
            for (int i = 1; i < játékosok.Length/2; i++)
            {

                if (átmeneti < játékosok[i].ElvittSzámítottLap + játékosok[i + (játékosok.Length / 2)].ElvittSzámítottLap)
                { 
                    átmeneti = játékosok[i].ElvittSzámítottLap + játékosok[i + (játékosok.Length / 2)].ElvittSzámítottLap;
                    melyikCsapat = i;
                }
                

            }


            

//4 személynél ha legalább 6-ot szereztek akkor nyertek egyébként döntetlen
            if (játékosok.Length == 4)
            {
                if ((játékosok[melyikCsapat].ElvittSzámítottLap + játékosok[(melyikCsapat + játékosok.Length / 2)].ElvittSzámítottLap) >= 6)
                {
                    kiirni += "A " + játékosok[melyikCsapat].Név + " és " + játékosok[(melyikCsapat + játékosok.Length / 2)].Név + " csapat Nyert!";


//ki fog osztani egy tömben tárolva, hogy tudjunk randommal választani azok közül akik oszthatnak
                    
                    
                    for (int i = 0; i < játékosok.Length; i++)
                    {
                        if (i != melyikCsapat && i != melyikCsapat + játékosok.Length / 2)
                        {
                            vesztesekIndexe[j] = i;
                            j++;
                        }
                    }
                    j = r2.Next(0, vesztesekIndexe.Length);
                    kiOszt = vesztesekIndexe[j];

                }
                else
                {
                    kiirni += "Senki nem Nyert! Döntetlen";
                }
            }

//6 személynél ha legalább 4-et szereztek akkor nyertek egyébként döntetlen
            else if (játékosok.Length == 6)
            {
                if ((játékosok[melyikCsapat].ElvittSzámítottLap + játékosok[(melyikCsapat + játékosok.Length / 2)].ElvittSzámítottLap) >= 4)
                {
                    kiirni += "A " + játékosok[melyikCsapat].Név + " és " + játékosok[(melyikCsapat + játékosok.Length / 2)].Név + " csapat Nyert!";

//ki fog osztani egy tömben tárolva, hogy tudjunk randommal választani azok közül akik oszthatnak
                    
                    
                    for (int i = 0; i < játékosok.Length; i++)
                    {
                        if (i != melyikCsapat && i != melyikCsapat + játékosok.Length / 2)
                        {
                            vesztesekIndexe[j] = i;
                            j++;
                        }
                    }
                    j = r2.Next(0, vesztesekIndexe.Length);
                    

                }
                else
                {
                    kiirni += "Senki nem Nyert! Döntetlen";
                }
                
            }
            kiOszt = vesztesekIndexe[j];
            return kiirni;
        }
//a Console kimenetet kiírjuk egy fájlba aminek a nevét a felhasználó adja
        public void KiirFájlba(string név)
        {
            StreamWriter kiköp = new StreamWriter(név + ".txt", true,Encoding.Default);
            for (int i = 0; i < KiírTömb.Length; i++)
            {
                kiköp.WriteLine(KiírTömb[i]);
            }
            kiköp.Close();
        }
//ahhoz, hogy ugyanazt az eredményt lássuk amikor visszajátsszuk ezért a sortöréseket kicserélem csillagra
        public void ConvertKiirFormátumba()
        {
            string segéd = "";
            string csere = "*";
            string vizsgál = "\n";
            
            for (int i = 0; i < KiírTömb.Length; i++)
            {
                
                segéd = KiírTömb[i];

                KiírTömb[i] = segéd.Replace(vizsgál, csere) ;
                    
            }
        }
//itt a beolvasás után a csillagokat visszacserélem az eredeti sortörésre és így már megkapjuk ugyanazt a kimenetet
        public void ConvertMutatFormátumba()
        {
            string segéd = "";
            string csere = "*";
            string vizsgál = "\n";

            for (int i = 0; i < KiírTömb.Length; i++)
            {

                segéd = KiírTömb[i];

                KiírTömb[i] = segéd.Replace(csere, vizsgál);

            }
            
        }


//beolvasunk fájlból
        public void BeolvasFájlból(string név)
        {
            int k = 0;
            StreamReader read = new StreamReader(név + ".txt", Encoding.Default);
            while (!read.EndOfStream)
            {
                KiírTömb[k] = read.ReadLine();
                 
                k++;
            }
            read.Close();
        }
//ezzel a metódussal tudunk lépegetni az elmentett játékunk egyes körein
        public void Lépegető()
        {
            Console.WriteLine("Állások között a Lefele és a Felfele Nyíl segítségével tudsz navigálni.\nKilépéshez nyomj Escapet");
            Console.WriteLine("nyomj entert\n");
            ConsoleKeyInfo bekért = Console.ReadKey();
            Console.Clear();
            int k = 0;
            Console.WriteLine(KiírTömb[k]);
            while (bekért.Key != ConsoleKey.Escape)
            {
                
                bekért = Console.ReadKey();
                Console.Clear();


               
                    if (bekért.Key == ConsoleKey.UpArrow)
                    {
                        k--;
                        if (k >= 0 && k <KiírTömb.Length)
                        {

                            Console.WriteLine(KiírTömb[k]);

                        }
                        else { Console.WriteLine("Ez az eleje!"); }
                    }
                    else if (bekért.Key == ConsoleKey.DownArrow)
                    {
                        k++;
                        if (k < KiírTömb.Length && k >= 0)
                        {

                            Console.WriteLine(KiírTömb[k]);
                        }
                        else { Console.WriteLine("Ez a vége"); }
                    }
                }
            
        }
        


        

        
    }

    enum Érték
    {
        VII,
        VIII,
        IX,
        Alsó,
        Király,
        X,
        Ász,
        Felső,

    }

    enum Szín
    {
        Tök,
        Piros,
        Zöld,
        Makk,

    }


}
