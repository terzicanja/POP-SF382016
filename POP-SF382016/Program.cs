﻿using POP_SF382016.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF382016
{
    class Program
    {
        static List<Namestaj> namestaj { get; set;} = new List<Namestaj>();
        static List<TipNamestaja> tipnamestaja { get; set;} = new List<TipNamestaja>();


        static void Main(string[] args)
        {
            var s1 = new Salon()
            {
                Id = 1,
                Naziv = "Forma FTNale",
                Adresa = "Trg Dositeja Obradovica 6",
                ZiroRacun = "840-00073666-83",
                Email = "kontakt@ftn.uns.ac.rs",
                MaticniBroj = 234324,
                PIB = 323232,
                Telefon = "021/342-343",
                InternetAdresa = "hhtps://www.ftn.uns.ac.rs"
            };

            var tn1 = new TipNamestaja()
            {
                Id = 1,
                Naziv = "Sofa"
            };

            var tn2 = new TipNamestaja()
            {
                Id = 2,
                Naziv = "Regal",
            };

            var n1 = new Namestaj()
            {
                Id = 1,
                Naziv = "Super sofa",
                Sifra = "SF sifra za sofe",
                Cena = 28,
                TipNamestaja = tn1,
                KolicinaUMagacinu = 2
            };

            namestaj.Add(n1);
            Console.WriteLine($"====== Dobrodosli u salon {s1.Naziv}");
            IspisGlavnogMenija();

        }

        private static void IspisGlavnogMenija()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("====Glavni meni====");
                Console.WriteLine("1. Rad sa namestajem");
                Console.WriteLine("2. Rad sa tipom namestaja");
                Console.WriteLine("0. Izlaz iz aplikacije");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 2);

            switch (izbor)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    IspisiMeniNamestaja();
                    break;
                case 2:
                    MeniZaTipNamestaja();
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
                Console.WriteLine("====Meni namestaja====");
                Console.WriteLine("1. Izlistaj namestaj");
                Console.WriteLine("2. Dodaj novi namestaj");
                Console.WriteLine("3. Izmeni namestaj");
                Console.WriteLine("4. Obrisi postojeci");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor<0 || izbor>4);

            switch (izbor)
            {
                case 0:
                    IspisGlavnogMenija();
                    break;
                case 1:
                    IzlistajNamestaj();
                    break;
                case 2:
                    DodavanjeNovogNamestaja();
                    break;
                case 3:
                    IzmenaNamestaja();
                    break;
                case 3:
                    BrisanjeNamestaja();
                    break;
                default:
                    break;
            }
        }

        private static void IzlistajNamestaj()
        {
            Console.WriteLine("===Izlistavanje namestaja===");
            for (int i = 0; i < namestaj.Count; i++)
            {
                if (!namestaj[i].Obrisan)
                {
                    Console.WriteLine($"{i+1}.{namestaj[i].Naziv}, cena: {namestaj[i].Cena}, tip namestaja: {namestaj[i].TipNamestaja}");
                }
            }
            IspisiMeniNamestaja();
        }

        private static void DodavanjeNovogNamestaja()
        {
            Console.WriteLine("====Dodavanje novog namestaja====");
            var noviNamestaj = new Namestaj();
            noviNamestaj.Id = namestaj.Count + 1;

            Console.WriteLine("Unesite naziv: ");
            noviNamestaj.Naziv = Console.ReadLine();
            Console.WriteLine("Unesite cenu: ");
            noviNamestaj.Cena = double.Parse(Console.ReadLine());
            Console.WriteLine("Unesite sifru: ");
            noviNamestaj.Sifra = Console.ReadLine();
            Console.WriteLine("Unesite kolicinu: ");
            noviNamestaj.KolicinaUMagacinu = int.Parse(Console.ReadLine());

            int idTipaNamestaja = 0;
            TipNamestaja trazeniTip = null;

            //string nazivTipaNamestaja = "";
            //TipNamestaja trazeniTipNamestaja = null;

            do
            {
                Console.WriteLine("Unesite id tipa namestaja: ");
                idTipaNamestaja = int.Parse(Console.ReadLine());
                //nazivTipaNamestaja = Console.ReadLine();
                foreach (var tipNamestaja in tipnamestaja)
                {
                    if (tipNamestaja.Id == idTipaNamestaja)
                    {
                        trazeniTip = tipNamestaja;
                    }
                }
            } while (trazeniTip == null);

            noviNamestaj.TipNamestaja = trazeniTip;
            namestaj.Add(noviNamestaj);
            IspisiMeniNamestaja();
        }

        private static void IzmenaNamsetaja()
        {
            Namestaj trazeniNamestaj = null;

            // MENJATI OVDE, NE TREBA PO NAZIVU NEGO PO ID JA MSM

            string nazivTrazenogNamestaja = "";

            do
            {
                Console.WriteLine("Unesite naziv namestaja: ");
                nazivTrazenogNamestaja = Console.ReadLine;

                foreach (var nam in namestaj)
                {
                    if(nam.Naziv == nazivTrazenogNamestaja)
                    {
                        trazeniNamestaj = nam;
                    }
                }
            } while (trazeniNamestaj == null);

            Console.WriteLine("Unesite novi naziv namestaja: ");
            trazeniNamestaj.Naziv = Console.ReadLine();
            Console.WriteLine("Unesite novu cenu namestaja: ");
            trazeniNamestaj.Cena = double.Parse(Console.ReadLine());
            IspisiMeniNamestaja();
        }

        private static void BrisanjeNamestaja()
        {
            Namestaj trazeniNamestaj = null;
            string nazivZaBrisanje = "";

            do
            {
                Console.WriteLine("Unesite naziv namestaja koji zelite da obrisete: ");
                nazivZaBrisanje = Console.ReadLine;

                foreach (var n in namestaj)
                {
                    trazeniNamestaj = n;
                }
            } while (trazeniNamestaj == null);

            trazeniNamestaj.Obrisan = true;
            IspisiMeniNamestaja();
        }



        private static void MeniZaTipNamestaja()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("====Meni za tip namestaja====");
                Console.WriteLine("1. Izlistaj tipove namestaja");
                Console.WriteLine("2. Dodaj novi tip namestaja");
                Console.WriteLine("3. Izmeni tip namestaja");
                Console.WriteLine("4. Obrisi postojeci");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor<0 || izbor>4);

            switch (izbor)
            {
                case 0:
                    IspisGlavnogMenija();
                    break;
                case 1:
                    IzlistajTipoveNamestaja();
                    break;
                case 2:
                    DodavanjeNovogTipa();
                    break;
                case 3:
                    IzmenaTipaNamestaja();
                    break;
                case 3:
                    BrisanjeNamestaja();
                    break;
                default:
                    break;
            }
        }

        private static void IzlistajTipoveNamestaja()
        {
            Console.WriteLine("===Izlistavanje tipova namestaja===");
            for (int i = 0; i < tipnamestaja.Count; i++)
            {
                if (!tipnamestaja[i].Obrisan)
                {
                    Console.WriteLine($"{i+1}.{tipnamestaja[i].Naziv}");
                }
            }
            IspisiMeniNamestaja();
        }

        private static void DodavanjeNovogTipa()
        {
            Console.WriteLine("====Dodavanje novog tipa namestaja====");
            var noviTip = new TipNamestaja();
            noviTip.Id = tipnamestaja.Count + 1;

            Console.WriteLine("Unesite naziv: ");
            noviTip.Naziv = Console.ReadLine();
            /*
            string nazivTipaNamestaja = "";
            TipNamestaja trazeniTipNamestaja = null;

            do
            {
                Console.WriteLine("Unesite tip namestaja: ");
                nazivTipaNamestaja = Console.ReadLine();
                foreach (var tipNamestaja in tipnamestaja)
                {
                    if (tipNamestaja.Naziv == nazivTipaNamestaja)
                    {
                        trazeniTipNamestaja = tipNamestaja;
                    }
                }
            } while (trazeniTipNamestaja == null);
            noviNamestaj.TipNamestaja = trazeniTipNamestaja;
            */
            tipnamestaja.Add(noviTip);
            MeniZaTipNamestaja();
        }

        private static void IzmenaTipaNamsetaja()
        {
            TipNamestaja trazeniTip = null;
            string nazivTrazenogTipa = "";

            //Namestaj trazeniNamestaj = null;
            //string nazivTrazenogNamestaja = "";

            do
            {
                Console.WriteLine("Unesite naziv tipa namestaja: ");
                nazivTrazenogTipa = Console.ReadLine;

                foreach (var tip in tipnamestaja)
                {
                    if(tip.Naziv == nazivTrazenogTipa)
                    {
                        trazeniTip = tip;
                    }
                }
            } while (trazeniTip == null);

            Console.WriteLine("Unesite novi naziv tipa namestaja: ");
            trazeniTip.Naziv = Console.ReadLine();
            MeniZaTipNamestaja();
        }





    }



























}
