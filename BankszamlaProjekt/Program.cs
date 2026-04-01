using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankszamlaProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime most = DateTime.Now;
            
            StreamReader sr = new StreamReader("szamlak.txt", Encoding.UTF8);            
            List<Account> adatok = new List<Account>();
            while (!sr.EndOfStream)
            {
                string[] adatsor = sr.ReadLine().Split(';');
                adatok.Add(new Account(adatsor[0], adatsor[1], decimal.Parse(adatsor[2]) ));
            }
            sr.Close();

            string menupont = "";

            do
            {
                Console.Clear();                
                Console.WriteLine("--- Banki lehetőségek ---");
                Console.WriteLine("1. Befizetés");
                Console.WriteLine("2. Kifizetés");
                Console.WriteLine("3. Utalás");
                Console.WriteLine("4. Adatok kiírása");
                Console.WriteLine("5. Hitelkeret módosítása");
                Console.WriteLine("6. Kilépés");

                Console.Write("\nVálassz menüpontot: ");

                menupont = Console.ReadLine();

                switch (menupont)
                {
                    case "1":  break;
                    case "2":  break;
                    case "3": break;
                    case "4": break;
                    case "5": break;
                    case "6": break;
                    default: break;
                }

            } while (menupont != "6");



        }

        
static void Befizetes(List<Account> adatok)
{
    Console.Write("Kérem a számlaszámot: ");
    string szamSzam = Console.ReadLine();

    Account acc = SzamlaKereses(adatok, szamSzam);

    if (acc != null)
    {
        Console.Write("Kérem a befizetendő összeget: ");
        decimal osszeg = decimal.Parse(Console.ReadLine());

        acc.Befizetes(osszeg);
        Console.WriteLine("A befizetés sikeres volt!");
    }
    else
    {
        Console.WriteLine("Nincs ilyen számla!");
    }
}

static void Kifizetes(List<Account> adatok)
{
    Console.Write("Kérem a számlaszámot: ");
    string szamSzam = Console.ReadLine();

    Account acc = SzamlaKereses(adatok, szamSzam);

    if (acc != null)
    {
        Console.Write("Kérem a kifizetendő összeget: ");
        decimal osszeg = decimal.Parse(Console.ReadLine());

        if (acc.Kifizetes(osszeg))
        {
            Console.WriteLine("A kifizetés sikeres volt!");
        }
        else
        {
            Console.WriteLine("Sikertelen kifizetés! Nincs elég fedezet.");
        }
    }
    else
    {
        Console.WriteLine("Nincs ilyen számla!");
    }
}

static void Utalas(List<Account> adatok)
{
    Console.Write("Melyik számláról utalunk (küldő): ");
    Account kuldo = SzamlaKereses(adatok, Console.ReadLine());

    Console.Write("Melyik számlára utalunk (fogadó): ");
    Account fogado = SzamlaKereses(adatok, Console.ReadLine());

    if (kuldo != null && fogado != null)
    {
        Console.Write("Utalás összege: ");
        decimal osszeg = decimal.Parse(Console.ReadLine());

        if (kuldo.Utalas(osszeg, fogado))
        {
            Console.WriteLine("Az utalás sikeresen megtörtént!");
        }
        else
        {
            Console.WriteLine("Sikertelen utalás! Nincs elég fedezet.");
        }
    }
    else
    {
        Console.WriteLine("Hiba! Valamelyik számlaszám nem létezik.");
    }
}
        
        static void Kiiras(List<Account> adatok)
{
    Console.WriteLine("--- Rendszerben lévő számlák ---");
    foreach (Account acc in adatok)
    {
        Console.WriteLine(acc.ToString());
    }
}
        static void HitelModositas(List<Account> adatok)
{
    Console.Write("Kérem a számlaszámot: ");
    string szamSzam = Console.ReadLine();

    Account acc = SzamlaKereses(adatok, szamSzam);

    if (acc != null)
    {
        Console.Write("Kérem az új hitelkeret összegét: ");
        decimal ujKeret = decimal.Parse(Console.ReadLine());

        if (acc.HitelkeretModositas(ujKeret))
        {
            Console.WriteLine("Hitelkeret sikeresen módosítva!");
        }
        else
        {
            Console.WriteLine("Sikertelen módosítás! A keret túl nagy.");
        }
    }
    else
    {
        Console.WriteLine("Nincs ilyen számla!");
    }
}
        

    }      
}
