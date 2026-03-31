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

            StreamReader sr = new StreamReader("szamlak.txt", Encoding.UTF8);            
            List<Account> adatok = new List<Account>();
            while (!sr.EndOfStream)
            {
                string[] adatsor = sr.ReadLine().Split(';');
                adatok.Add(new Account(adatsor[0], adatsor[1], decimal.Parse(adatsor[2]) ));
            }
            sr.Close();





        }
    }      
}
