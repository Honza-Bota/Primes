using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Primes
{
    public delegate bool Kriterium(string input, string param);
    class PrimeCounter
    {        
        public Kriterium[] KrArr { get; set; }
        Kriterium kriterium;

        public PrimeCounter()
        {
            KrArr = new Kriterium[] 
            { 
                Obsahuje_Jednotlive_Znaky, 
                Dalsi_Cislo_Nez_Parametr, 
                Obsahuje_Znaky_Po_Sobe, 
                Vetsi_Cislo_Nez_Parametr, 
                Obsahuje_X_Vyskytu_Y_Zapsano_Jako_XxY 
            };
        }

        public async Task<string> GetRequestPrimeAsync(int vybranaMetoda, string parametr)
        {
            kriterium = KrArr[vybranaMetoda];
            ulong vysledek = 0;

            await Task.Run(() =>
            {
                for (ulong i = 0; i <= ulong.MaxValue; i++)
                {
                    try
                    {
                        if (IsPrime(i) && kriterium(i.ToString(), parametr))
                        {
                            vysledek = i;
                            break;
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                        return;
                    }
                }
            });

            return vysledek.ToString();
        }

        bool IsPrime(ulong number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            ulong boundary = (ulong)Math.Floor(Math.Sqrt(number));

            for (ulong i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        bool Obsahuje_Jednotlive_Znaky(string input, string param)
        {
            Convert.ToUInt64(param);

            char[] znaky = param.ToCharArray(); 
            int vyskyty = 0;

            foreach (var item in znaky)
            {
                if (input.Contains(item))
                {
                    vyskyty++;
                }
            }

            if (vyskyty == znaky.Length) return true;
            else return false;
        }

        bool Vetsi_Cislo_Nez_Parametr(string input, string param)
        {
            Convert.ToUInt64(param);

            if (Convert.ToUInt64(input) > Convert.ToUInt64(param)) return true;
            else return false;
        }

        bool Dalsi_Cislo_Nez_Parametr(string input, string param)
        {
            Convert.ToInt32(param);

            int delka = int.Parse(param);

            if (input.Length > delka) return true;
            else return false;
        }

        bool Obsahuje_Znaky_Po_Sobe(string input, string param)
        {
            Convert.ToUInt64(param);

            if (input.Contains(param)) return true;
            else return false;
        }

        bool Obsahuje_X_Vyskytu_Y_Zapsano_Jako_XxY(string input, string param)
        {
            if (!param.Contains('x') && param.Length != 3) throw new FormatException();

            int pocetVyskytu = Convert.ToInt32(param.Split('x')[0]);
            char hodnota = Convert.ToChar(param.Split('x')[1]);
            int pocet = 0;

            foreach (var item in input)
            {
                if (item == hodnota) pocet++;
            }

            if (pocetVyskytu == pocet) return true;
            else return false;
        }
    }
}
