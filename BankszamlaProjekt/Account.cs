using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//༼ つ ◕_◕ ༽つ༼ つ ◕_◕ ༽つ//

namespace BankszamlaProjekt
{
    internal class Account
    {
        private string Szamlaszam;
        private string Nev;
        private decimal Kegyenleg;
        private decimal Hitelkeret;

        public Account(string szamlaszam, string nev, decimal KezdoEgyenleg)
        {
            this.Szamlaszam = szamlaszam;
            this.Nev = nev;
            this.Kegyenleg = KezdoEgyenleg;
            this.Hitelkeret = 0;
        }

        public string GetSzamlaszam()
        {
            return Szamlaszam;
        }
        public string GetNev() 
        {
            return Nev;
        }
        public decimal GetKegyenleg()
        {
            return Kegyenleg;
        }
        public decimal GetHitelkeret()
        {
            return Hitelkeret;
        }

    }
}
