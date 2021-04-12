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
        }
    }
}
