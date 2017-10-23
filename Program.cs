using POP_SF382016.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF382016
{
    class Program
    {
        static List<Namestaj> Namestaj { get; set; } = new List<Namestaj>();

        static List<TipNamestaja> TipoviNamestaja { get; set; } = new List<TipNamestaja>();

        static void Main(string[] args)
        {
            var s1 = new Model.Salon()
            {
                Id = 1,
                Naziv = "Forma FTNale",
                Adresa = "Trg Dositeja Obradovica 6",
                ZiroRacun = "840-0000-2121",
                Email = "email@gmail.com",
                MaticniBroj = 2424242,
                PIB = 21873921,
                Telefon = "021 23234",
                Sajt = "google.com"
            };

            var tn1 = new TipNamestaja()
            {
                Id = 1,
                Naziv = "neka sofa"
            };

            var tn2 = new TipNamestaja()
            {
                Id = 2,
                Naziv = "regal"
            };

            TipoviNamestaja.Add(tn1);
            TipoviNamestaja.Add(tn2);

        }

        private static void IspisGlavnogMenija()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("=== GLAVNI MENI ===");
                Console.WriteLine("1. Rad sa namestajem");
                Console.WriteLine("2. Rad sa tipom namestaja");
                Console.WriteLine("0. Izlaz iz aplikacije");
                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor >2);
            

            switch (izbor)
            {
                case 1:
                    IspisiMeniNamestaja();
                    break;
                default:
                    break;
            }
        }

        private static void IspisiMeniNamestaja()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("=== MENI GLAVNOG NAMESTAJA ===");
                Console.WriteLine("1. Izlistaj namestaj");
                Console.WriteLine("2. Dodaj novi namestaj");
                Console.WriteLine("3. Izmeni postojeci namestaj");
                Console.WriteLine("4. Obrisi postojeci");
                Console.WriteLine("0. Povratak u glavni meni");
                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 4);

            switch (izbor)
            {
                case 1:
                    IzlistajNamestaj();
                    break;
                case 2:
                    DodavanjeNamestaja();
                    break;
                case 3:
                    IzmenaNamestaja();
                    break;
                case 0:
                    IspisGlavnogMenija();
                    break;
                default:
                    break;
            }
        }

        private static void IzlistajNamestaj()
        {
            Console.WriteLine("=== IZLISTAVANJE NAMESTAJA ===");
            for (int i = 0; i < Namestaj.Count; i++)
            {
                if (!Namestaj[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}. {Namestaj[i].Naziv}, cena: {Namestaj[i].Cena}, tip namestaja: {Namestaj[i].TipNamestaja.Naziv}");
                }
            }
        }


        private static void DodavanjeNamestaja()
        {
            Console.WriteLine("=== DODAVANJE NOVOG NAMESTAJA ===");

            var n1 = new Namestaj();

            n1.Id = n1.GetHashCode();
            Console.WriteLine("Unesite naziv namestaja");
            n1.Naziv = Console.ReadLine();
            Console.WriteLine("Unesite sifru namestaja");
            n1.Sifra = Console.ReadLine();
            Console.WriteLine("Unesite cenu namestaja");
            n1.Cena = double.Parse(Console.ReadLine());
            Console.WriteLine("Unesite kolicinu u magacinu namestaja");
            n1.KolicinaUMagacinu = int.Parse(Console.ReadLine());
            

            string nazivTipaNamestaja = "";
            TipNamestaja trazeniTipNamestaja = null;
            do
            {
                Console.WriteLine("Unesite tip namestaja: ");
                nazivTipaNamestaja = Console.ReadLine();
                foreach (var tipNamestaja in TipoviNamestaja)
                {
                    if(tipNamestaja.Naziv == nazivTipaNamestaja)
                    {
                        trazeniTipNamestaja = tipNamestaja;
                    }
                }
            } while (trazeniTipNamestaja == null);

            n1.TipNamestaja = trazeniTipNamestaja;
            
            Namestaj.Add(n1);

            IspisiMeniNamestaja();
        }

        private static void IzmenaNamestaja()
        {
            Console.WriteLine("=== IZMENA NAMESTAJA ===");
            Console.WriteLine("Unesite id namestaja koji zelite da izmenite");
        }

    }
}

