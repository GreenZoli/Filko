using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace beadandó5
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Játék Szabályok: Színre színt kell tenni vagy adut.\n");
            Console.WriteLine("Program használata: \n"+
            "Kiírja az adut és az asztalra lerakott lapokat.\n"+
            "Megmutatja milyen lapjaink vannak és a sorszámukat.\n"+
            "Lapválasztáshoz a lap előtti számot kell beírni.\n"+
            "Ezután kiírja az asztalra lerakott lapokat és ki vitte őket.\n\n"+
            "Továbblépéshez egy entert kell használni!\n\n"+
            "A legvégén, hogy melyik csapat nyert.\n\n"+
            "ESCAPE-el tudod feladni a játékot\n\n\n" +
            "nyomj Entert a továbblépéshez");
            Console.ReadLine();
            int jé = 1;
            int kiOszt = 0;

            Console.Clear();
            Console.WriteLine("Hány személyes játék? (4/6):");
            int játékosDb = int.Parse(Console.ReadLine());
            
            Játszma játszma = new Játszma(játékosDb);
            if (játékosDb == 4)
            {
                játszma.AkiOszt = 3;
            }
            else if (játékosDb == 6)
            {
                játszma.AkiOszt = 5;
            }

            Console.WriteLine("Előbb Játszani akarsz vagy visszajátszani egy előző játékot? (játék/vissza)");
            string érték = Console.ReadLine();
            if (érték == "vissza")
            {
                Console.Clear();
                Console.WriteLine("Add meg a fájl nevét amibe elmentetted az állást:");
                érték = Console.ReadLine();
                játszma.BeolvasFájlból(érték);
                játszma.ConvertMutatFormátumba();
                játszma.Lépegető();
                Console.WriteLine("Játékhoz tovább Nyomj Entert!");
                Console.ReadLine();
                Console.Clear();
                játszma.KiírTömb1 = new string[játszma.KezSzáma];
            }
         
            do
            {
                if (jé == 0)
                {
                    
                    
                    játszma.AkiOszt = kiOszt;
                    játszma.KiírTömb1 = new string[játszma.KezSzáma];

                }
            

            Console.Clear();
            játszma.Létrehoz();

            

//beletesszük a kiíratásokat egy tömbe és azt közben ki is írjuk
            játszma.KiírTömb1[Játszma.kiírFigyelő] += "Adu: " + játszma.Pakli.Adu+"\n";
            

            játszma.KiírTömb1[Játszma.kiírFigyelő] += 1 + "kör: \n";
            
            játszma.egyKör(kiOszt);
            int kivitte = játszma.Kivitte();

            játszma.KiírTömb1[Játszma.kiírFigyelő] += "\n\nAsztalon: \n";
            for (int i = 0; i < játszma.Asztal.Length; i++)
            {
                if (i == (játszma.KezSzáma / 2)+1) { játszma.KiírTömb1[Játszma.kiírFigyelő] +="\n"; }
                játszma.KiírTömb1[Játszma.kiírFigyelő] +=játszma.Asztal[i].Szín + "-" + (Érték)játszma.Asztal[i].Érték + " ; ";
            }
            játszma.KiírTömb1[Játszma.kiírFigyelő] +="===>"+játszma.Játékosok[kivitte].Név + " vitte" + "\n\nnyomj Entert a továbblépéshez";
            int k = 1;
            Console.Clear();
            Console.WriteLine(játszma.KiírTömb1[Játszma.kiírFigyelő]);
            Console.ReadLine();
            while (k < játszma.KezSzáma)
            {
                Console.Clear();
                Játszma.kiírFigyelő++;
                játszma.KiírTömb1[Játszma.kiírFigyelő] += "Adu: " + játszma.Pakli.Adu + "\n";


                játszma.KiírTömb1[Játszma.kiírFigyelő] += 1 + "kör: \n";

                játszma.egyKör(kivitte);
                kivitte = játszma.Kivitte();

                játszma.KiírTömb1[Játszma.kiírFigyelő] += "\n\nAsztalon: \n";
                for (int i = 0; i < játszma.Asztal.Length; i++)
                {
                    if (i == (játszma.KezSzáma / 2) + 1) { játszma.KiírTömb1[Játszma.kiírFigyelő] += "\n"; }
                    játszma.KiírTömb1[Játszma.kiírFigyelő] += játszma.Asztal[i].Szín + "-" + (Érték)játszma.Asztal[i].Érték + " ; ";
                }
                játszma.KiírTömb1[Játszma.kiírFigyelő] += játszma.Játékosok[kivitte].Név + " vitte" + "\n\nnyomj Entert a továbblépéshez";
                
                Console.Clear();
                Console.WriteLine(játszma.KiírTömb1[Játszma.kiírFigyelő]);
                
                Console.ReadLine();
                k++;
            }

            string eredmény = játszma.Kinyert(out kiOszt);
            Console.WriteLine(eredmény);

            
            játszma.KiírTömb1[Játszma.kiírFigyelő] += "\n"+eredmény;

            kiOszt++;

                
            Console.WriteLine(játszma.Játékosok[kiOszt-1].Név + " Osztja a következő kört.");
            
            Console.WriteLine("El akarod Menteni?");
            string mentés = Console.ReadLine();
                if(mentés == "Igen" || mentés == "igen")
                {
                    játszma.ConvertKiirFormátumba();
                    Console.WriteLine("Add meg a fájl nevét:");
                    string kifájlNév = Console.ReadLine();
                    játszma.KiirFájlba(kifájlNév);
                }
                
                
                    Console.WriteLine("Akarsz még játszani?");
                    mentés = Console.ReadLine();
                    if (mentés == "Igen" || mentés == "igen")
                    {
                        jé = 0;
                        játszma.Pakli.OsztásFelügyelő = 0;
                        Játszma.kiírFigyelő = 0;
                        játszma.Pakli.AduReset();
                        for (int i = 0; i < játszma.Játékosok.Length; i++)
                        {
                            játszma.Játékosok[i].ElvittSzámítottLap = 0;
                        }
                        

                    }
                    else 
                    { jé = 1;
                    Console.WriteLine("\nOké akkor kilép a program\nNyomj Entert, hogy megtörténjen!");
                    }
                
                
            }while(jé < 1);






            
            




            Console.ReadLine();
        }
    }
}
