using System;                   
using System.IO;                  
using System.Text;                
using System.Collections.Generic; 
using System.Linq;
class Jackie
{
    public int ev;
    public int verseny;
    public int nyeresek;
    public int helyezes;
    public int elsohely;
    public int leggyorsabb;

    public int evtized { get; private set; }

    public Jackie(string sor)
    {
        var s = sor.Split();
        ev = int.Parse(s[0]);
        verseny = int.Parse(s[1]);
        nyeresek = int.Parse(s[2]);
        helyezes = int.Parse(s[3]);
        elsohely = int.Parse(s[4]);
        leggyorsabb = int.Parse(s[5]);
        evtized = int.Parse(s[0].Substring(2, 1)) * 10;
    }
}
class Program
{
    public static void Main(string[] args)
    {
        var lista = new List<Jackie>();
        var f = new StreamReader("jackie.txt");
        var elsosor = f.ReadLine();

        while (!f.EndOfStream)
        {
            lista.Add(new Jackie(f.ReadLine()));
        }
        f.Close();

        // 3.feladat
        Console.WriteLine($"3. feladat: {lista.Count}");

        // 4.feldat
        var year = (
            from sor in lista
            orderby sor.verseny
            select sor.ev
            ).Last();
        Console.WriteLine($"4. feladat: {year}");

        // 5. feladat
        var statisztika = new Dictionary<int, int>();
        foreach (var sor in lista)
        {
            if (statisztika.ContainsKey(sor.evtized))
            {
                statisztika[sor.evtized] += sor.nyeresek;
            }
            else
            {
                statisztika[sor.evtized] = sor.nyeresek;
            }
        }

        Console.WriteLine($"5. feladat: ");
        foreach (var kulcs_ertek in statisztika)
        {
            Console.WriteLine($"        {kulcs_ertek.Key}-es évek {kulcs_ertek.Value} megnyert verseny");
        }
        // 6.feladat
        Console.ReadKey();
    }
}