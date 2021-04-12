using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaMZ
{
    class Program
    {
        class Auto
        {
            public int ertek;
            public string tipus;
            public string rsz;
        }
        static void Main(string[] args)
        {
            //fájlbeolvasás
            string [] sorok = File.ReadAllLines("forras.txt");
            List<Auto> autok = new List<Auto>();
            foreach (string sor in sorok.Skip(1)) //skip, ha van fejléc
            { 
                autok.Add(new Auto());
            }
            //adatok száma
            int N = autok.Count; //Ha van fejléc, akkor -1
            //legtöbb vmi
            /*szélső érték keresés*/
            int minIndex = 0,  maxIndex = 0;
            for (int i = 0; i < N; i++)
            {
                if(autok[i].ertek > autok[maxIndex].ertek)
                {
                    maxIndex = i;
                }
                if (autok[i].ertek < autok[minIndex].ertek)
                {
                    minIndex = i;
                }
            }
            Console.WriteLine($"a legnagyobb érték: {maxIndex}, a legkisebb érték: {minIndex}");
            //van-e egy valamilyen
            /* eldöntés I. */
            int i = 0;
            while (i <N && !(T)) { i++; } //T: mit vizsgálunk, pl autok[i].ertek == 12000)
            bool van = i < N; //i <N || i>= N;
            //mindenki valamilyen-e
            /* eldöntés II. */
            i = 0;
            while (i < N && (T)) { i++; } //T: mit vizsgálunk, pl autok[i].ertek == 12000)
            bool mind = i >= N; //i <N || i>= N;


            //Hány féle van. melyek ezek
            /* HashSet<> */
            HashSet<int> ertekek = new HashSet<int>();
            foreach (Auto auto in autok)
            {
                ertekek.Add(auto.ertek);
            }
            //kiiras
            foreach (int ertek in ertekek)
            {
                Console.WriteLine(ertek);
            }

            //melyikből mennyi van
            /* Dictionary<string,int> */
            Dictionary<string, int> tipusDb = new Dictionary<string, int>();
            foreach (Auto auto in autok)
            {
                string kulcs = auto.tipus;
                if (tipusDb.ContainsKey(kulcs))
                {
                    tipusDb[kulcs]++;
                }
                else
                {
                    tipusDb.Add(kulcs, 1);
                }
            }
            //kiiras
            foreach (KeyValuePair<string,int> item in tipusDb)
            {
                Console.WriteLine($"{item.Key} típusból {item.Value} darab ");
            }

            //fájlkiiras
            string fn = "statisztika.txt"; //bin/Debug mappába jön létre
            /* ha egy stringbe van: */
            string kimenet = "ezt írom ki, ez lesz a fájlban";
            File.WriteAllText(fn, kimenet);

            /* ha string[], amit ki kell írni: */
            string[] kiirandosorok = new string[3];
            File.WriteAllLines(fn, kiirandosorok);

            //össz BMW rsz fájlba
            List<string> bmwrsz = new List<string>();
            foreach (Auto auto in autok)
            {
                if (auto.tipus == "BMW")
                {
                    bmwrsz.Add($"{auto.rsz}\n");

                }

            }
            File.WriteAllLines("bmwrendszamok.txt", bmwrsz.ToArray());
        }
    }
}
