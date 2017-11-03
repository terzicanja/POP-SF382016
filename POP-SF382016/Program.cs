using POP_SF382016.Model;
using POP_SF382016.utill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF382016
{
    class Program
    {
        //static List<Namestaj> namestaj { get; set;} = new List<Namestaj>();
        //static List<TipNamestaja> tipnamestaja { get; set;} = new List<TipNamestaja>();
        static List<Korisnik> korisnici { get; set; } = new List<Korisnik>();
        static List<Akcija> akcije { get; set; } = new List<Akcija>();

        static List<Namestaj> namestaj { get; set; } = Projekat.Instance.Namestaj;
        static List<TipNamestaja> tipnamestaja { get; set; } = Projekat.Instance.Tip;



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
                Sajt = "hhtps://www.ftn.uns.ac.rs"
            };

            var tn1 = new TipNamestaja()
            {
                Id = 1,
                Naziv = "Sofa"
            };

            var tn2 = new TipNamestaja()
            {
                Id = 2,
                Naziv = "Regal"
            };

            var n1 = new Namestaj()
            {
                Id = 1,
                Naziv = "Super sofa",
                Sifra = "SF sifra za sofe",
                Cena = 28,
                IdTipaNamestaja = 2,
                //TipNamestaja = tn1,
                KolicinaUMagacinu = 2
            };

            var k1 = new Korisnik()
            {
                Id = 1,
                Ime = "Petar",
                Prezime = "Petrovic",
                KorisnickoIme = "petarp",
                Lozinka = "sifra",
                //TipKorisnika = "Prodavac"
            };

            var du1 = new DodatnaUsluga()
            {
                Id = 1,
                Usluga = "Prevoz",
                Cena = 123
            };

            var pr1 = new ProdajaNamestaja()
            {
                Id = 1,
                BrojRacuna = 5,
                PDV = 12
            };

            var a1 = new Akcija()
            {
                Id = 1,
                Popust = 12
            };

            /*
            var l2 = new List<Akcija>();
            l2.Add(a1);
            Console.WriteLine("Serialization...");
            GenericSerializer.Serialize<Akcija>("akcija.xml", l2);

            List<Akcija> ucitanaLista = GenericSerializer.Deserialize<Akcija>("akcija.xml");

            Console.WriteLine("finished");
            Console.ReadLine();
            */
            
            namestaj.Add(n1);
            tipnamestaja.Add(tn1);
            tipnamestaja.Add(tn2);
            //akcije.Add(a1);
            Console.WriteLine($"====== Dobrodosli u salon {s1.Naziv} =====");

            IspisGlavnogMenija();
            //Login();

            /*
            var lista = Projekat.Instance.Namestaj;
            lista.Add(new Namestaj() { Id = 32, Naziv = "remix" });
            Projekat.Instance.Namestaj = lista;

            foreach (var stavka in lista)
            {
                Console.WriteLine($"{stavka.Naziv}");
            }
            */

            
        }


        /*
         * ovo za dodavanje namestaja i kako tip resiti
         * 
        var tipovinamestaja = projekat.instamce.tipovinamestaja;
        Tipnamestaja trazenitip;
        foreach (var tip in tipovinamestaja){
        if (tip.id == idtipanamestaja (to je conolse.readline)){
            trazenitip = tip


        projekat.instance.namestaj = nesto da bi ucitalo u xml valjda
        */
  

        private static void IspisGlavnogMenija()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("====Glavni meni====");
                Console.WriteLine("1. Rad sa namestajem");
                Console.WriteLine("2. Rad sa tipom namestaja");
                Console.WriteLine("3. Rad sa salonom");
                Console.WriteLine("4. Rad sa dodatnim uslugama");
                Console.WriteLine("5. Rad sa korisnicima");
                Console.WriteLine("6. Rad sa akcijama");
                Console.WriteLine("0. Izlaz iz aplikacije");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 6);

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
                case 3:
                    SalonMeni();
                    break;
                case 4:
                    UslugeMeni();
                    break;
                case 5:
                    KorisniciMeni();
                    break;
                case 6:
                    AkcijeMeni();
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
                case 4:
                    BrisanjeNamestaja();
                    break;
                default:
                    break;
            }
        }

        private static void IzlistajNamestaj()
        {
            Console.WriteLine("===Izlistavanje namestaja===");
            var lista = Projekat.Instance.Namestaj;
            //Projekat.Instance.Namestaj = lista;
            //hoce i bez ove iznad linije, nisam sigurna dal treba
            //foreach (var stavka in lista)
            //{
            //    Console.WriteLine($"{stavka.Naziv}");

            for (int i = 0; i < lista.Count; i++)
            {
                if (!lista[i].Obrisan)
                {
                    Console.WriteLine($"{i+1}.{lista[i].Naziv}, cena: {lista[i].Cena}, tip namestaja: {TipNamestaja.GetById(lista[i].IdTipaNamestaja).Naziv}");
                }
            }
            IspisiMeniNamestaja();
        }
        
        private static void DodavanjeNovogNamestaja()
        {
            var lista = Projekat.Instance.Namestaj;
            //var lista = new Namestaj();
            //Projekat.Instance.Namestaj = lista;


            Console.WriteLine("====Dodavanje novog namestaja====");


            var noviNamestaj = new Namestaj();
            noviNamestaj.Id = lista.Count + 1;
            int idTipaNamestaja = 0;

            Console.WriteLine("Unesite naziv: ");
            noviNamestaj.Naziv = Console.ReadLine();
            Console.WriteLine("Unesite cenu: ");
            noviNamestaj.Cena = double.Parse(Console.ReadLine());
            Console.WriteLine("Unesite sifru: ");
            noviNamestaj.Sifra = Console.ReadLine();
            Console.WriteLine("Unesite kolicinu: ");
            noviNamestaj.KolicinaUMagacinu = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite id tipa namestaja: ");
            idTipaNamestaja = int.Parse(Console.ReadLine());

            //int idTipaNamestaja = 0;
            //TipNamestaja trazeniTip = null;

            //string nazivTipaNamestaja = "";
            //TipNamestaja trazeniTipNamestaja = null;


            var tipoviNamestaja = Projekat.Instance.Tip;
            TipNamestaja trazenitip;
            foreach (var tip in tipoviNamestaja)
            {
                if (tip.Id == idTipaNamestaja)
                {
                    trazenitip = tip;
                    noviNamestaj.IdTipaNamestaja = idTipaNamestaja;
                    Console.WriteLine("dodeljen id tipa");
                }
            }

            //Projekat.Instance.Namestaj = lista;
            //IZGLEDA DA MOZE I BEZ OVE IZNAD LINIJE
            lista.Add(noviNamestaj);
            GenericSerializer.Serialize<Namestaj>("namestaj.xml", lista);
            Console.WriteLine("dodato u xml");

            /*
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
            lista.Add(noviNamestaj);*/
            IspisiMeniNamestaja();
        }

        private static void IzmenaNamestaja()
        {
            Namestaj trazeniNamestaj = null;
            string nazivTrazenogNamestaja = "";
            var namestaji = Projekat.Instance.Namestaj;

            do
            {
                Console.WriteLine("Unesite naziv namestaja koji zelite da menjate: ");
                nazivTrazenogNamestaja = Console.ReadLine();

                foreach (var nam in namestaji)
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
            GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestaji);
            IspisiMeniNamestaja();
        }

        private static void BrisanjeNamestaja()
        {
            Namestaj trazeniNamestaj = null;
            string nazivZaBrisanje = "";
            var namestaji = Projekat.Instance.Namestaj;

            do
            {
                Console.WriteLine("Unesite naziv namestaja koji zelite da obrisete: ");
                nazivZaBrisanje = Console.ReadLine();

                foreach (var n in namestaji)
                {
                    if(n.Naziv == nazivZaBrisanje)
                    {
                        trazeniNamestaj = n;
                        n.Obrisan = true;
                    }
                }
            } while (trazeniNamestaj == null);

            GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestaji);
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
                case 4:
                    BrisanjeTipaNamestaja();
                    break;
                default:
                    break;
            }
        }

        private static void IzlistajTipoveNamestaja()
        {
            Console.WriteLine("===Izlistavanje tipova namestaja===");
            var listatip = Projekat.Instance.Tip;
            //Projekat.Instance.Tip = listatip;        SA OVOM LINIJOM JA MSM DA KAO OPET UPISE U XML ILI NESTO SLICNO
            
            foreach (var tip in listatip)
            {
                if(!tip.Obrisan)
                {
                    Console.WriteLine($"{tip.Naziv}");
                }
            }
            // MOZE OBE VERZIJE
            /*
            for (int i = 0; i < listatip.Count; i++)
            {
                if (!listatip[i].Obrisan)
                {
                    Console.WriteLine($"{i+1}.{listatip[i].Naziv}");
                }
            }*/
            MeniZaTipNamestaja();
        }

        private static void DodavanjeNovogTipa()
        {
            Console.WriteLine("====Dodavanje novog tipa namestaja====");
            var lista = Projekat.Instance.Tip;
            var noviTip = new TipNamestaja();
            noviTip.Id = lista.Count + 1;

            Console.WriteLine("Unesite naziv novog tipa namestaja: ");
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
            lista.Add(noviTip);
            GenericSerializer.Serialize<TipNamestaja>("tip.xml", lista);
            MeniZaTipNamestaja();
        }

        private static void IzmenaTipaNamestaja()
        {
            TipNamestaja trazeniTip = null;
            string nazivTrazenogTipa = "";
            var tipovinamestaja = Projekat.Instance.Tip;

            do
            {
                Console.WriteLine("Unesite naziv tipa namestaja koji zelite da izmenite: ");
                nazivTrazenogTipa = Console.ReadLine();

                foreach (var tip in tipovinamestaja)
                {
                    if(tip.Naziv == nazivTrazenogTipa)
                    {
                        trazeniTip = tip;
                    }
                }
            } while (trazeniTip == null);

            Console.WriteLine("Unesite novi naziv tipa namestaja: ");
            trazeniTip.Naziv = Console.ReadLine();
            GenericSerializer.Serialize<TipNamestaja>("tip.xml", tipovinamestaja);
            MeniZaTipNamestaja();
        }

        private static void BrisanjeTipaNamestaja()
        {
            TipNamestaja trazeniTip = null;
            string nazivZaBrisanje = "";
            var tipovinamestaja = Projekat.Instance.Tip;

            do
            {
                Console.WriteLine("Unesite naziv tipa namestaja koji zelite da obrisete: ");
                nazivZaBrisanje = Console.ReadLine();

                foreach (var tip in tipovinamestaja)
                {
                    if(tip.Naziv == nazivZaBrisanje)
                    {
                        trazeniTip = tip;
                        tip.Obrisan = true;
                    }
                }
            } while (trazeniTip == null);
            
            GenericSerializer.Serialize<TipNamestaja>("tip.xml", tipovinamestaja);
            MeniZaTipNamestaja();
        }


        private static void SalonMeni()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("====Meni salona====");
                Console.WriteLine("1. Pregled salona");
                Console.WriteLine("2. Dodaj novi salon");
                Console.WriteLine("3. Izmeni salon");
                Console.WriteLine("4. Obrisi postojeci");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 4);

            switch (izbor)
            {
                case 0:
                    IspisGlavnogMenija();
                    break;
                case 1:
                    PregledSalona();
                    break;
                case 2:
                    DodavanjeNovogSalona();
                    break;
                case 3:
                    IzmenaSalona();
                    break;
                case 4:
                    BrisanjeSalona();
                    break;
                default:
                    break;
            }
        }

        private static void PregledSalona()
        {
            Console.WriteLine("===Pregled salona===");

            var lista = Projekat.Instance.Salon;

            for (int i = 0; i < lista.Count; i++)
            {
                if (!lista[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}.{lista[i].Naziv}, adresa: {lista[i].Adresa}, " +
                        $"telefon: {lista[i].Telefon}, email: {lista[i].Email}, web stranica: {lista[i].Sajt}");
                }
            }
            SalonMeni();
        }

        private static void DodavanjeNovogSalona()
        {
            var lista = Projekat.Instance.Salon;
            Console.WriteLine("===Dodavanje novog salona===");
            var noviSalon = new Salon();
            noviSalon.Id = lista.Count + 1;

            Console.WriteLine("Unesite naziv: ");
            noviSalon.Naziv = Console.ReadLine();
            Console.WriteLine("Unesite adresu: ");
            noviSalon.Adresa = Console.ReadLine();
            Console.WriteLine("Unesite telefon: ");
            noviSalon.Telefon = Console.ReadLine();
            Console.WriteLine("Unesite email: ");
            noviSalon.Email = Console.ReadLine();
            Console.WriteLine("Unesite sajt: ");
            noviSalon.Sajt = Console.ReadLine();
            Console.WriteLine("Unesite pib: ");
            noviSalon.PIB = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite maticni broj: ");
            noviSalon.MaticniBroj = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite broj ziro racuna: ");
            noviSalon.ZiroRacun = Console.ReadLine();

            lista.Add(noviSalon);
            GenericSerializer.Serialize<Salon>("salon.xml", lista);
            SalonMeni();
        }

        private static void IzmenaSalona()
        {
            Salon trazeniSalon = null;
            string nazivTrazenogSalona = "";
            var saloni = Projekat.Instance.Salon;

            do
            {
                Console.WriteLine("Unesite naziv salona koji zelite da izmenite");
                nazivTrazenogSalona = Console.ReadLine();

                foreach (var s in saloni)
                {
                    if (s.Naziv == nazivTrazenogSalona)
                    {
                        trazeniSalon = s;
                    }
                }
            } while (trazeniSalon == null);

            Console.WriteLine("Unesite naziv: ");
            trazeniSalon.Naziv = Console.ReadLine();
            Console.WriteLine("Unesite adresu: ");
            trazeniSalon.Adresa = Console.ReadLine();
            Console.WriteLine("Unesite telefon: ");
            trazeniSalon.Telefon = Console.ReadLine();
            Console.WriteLine("Unesite email: ");
            trazeniSalon.Email = Console.ReadLine();
            Console.WriteLine("Unesite sajt: ");
            trazeniSalon.Sajt = Console.ReadLine();
            Console.WriteLine("Unesite pib: ");
            trazeniSalon.PIB = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite maticni broj: ");
            trazeniSalon.MaticniBroj = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite broj ziro racuna: ");
            trazeniSalon.ZiroRacun = Console.ReadLine();

            GenericSerializer.Serialize<Salon>("salon.xml", saloni);

            SalonMeni();
        }

        private static void BrisanjeSalona()
        {
            Salon trazeniSalon = null;
            string nazivZaBrisanje = "";
            var saloni = Projekat.Instance.Salon;

            do
            {
                Console.WriteLine("Unesite naziv salona koji zelite da obrisete");
                nazivZaBrisanje = Console.ReadLine();

                foreach (var sal in saloni)
                {
                    if (sal.Naziv == nazivZaBrisanje)
                    {
                        trazeniSalon = sal;
                        sal.Obrisan = true;
                    }
                }
            } while (trazeniSalon == null);

            GenericSerializer.Serialize<Salon>("salon.xml", saloni);
            SalonMeni();
        }


        private static void UslugeMeni()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("====Meni usluga====");
                Console.WriteLine("1. Pregled usluga");
                Console.WriteLine("2. Dodaj novu uslugu");
                Console.WriteLine("3. Izmeni uslugu");
                Console.WriteLine("4. Obrisi postojecu");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 4);

            switch (izbor)
            {
                case 0:
                    IspisGlavnogMenija();
                    break;
                case 1:
                    PregledUsluga();
                    break;
                case 2:
                    DodavanjeNoveUsluge();
                    break;
                case 3:
                    IzmenaUsluge();
                    break;
                case 4:
                    BrisanjeUsluge();
                    break;
                default:
                    break;
            }
        }

        private static void PregledUsluga()
        {
            Console.WriteLine("===Pregled usluga===");
            var lista = Projekat.Instance.DodatnaUsluga;
            for (int i = 0; i < lista.Count; i++)
            {
                if (!lista[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}.{lista[i].Usluga}, cena: {lista[i].Cena}");
                }
            }
            UslugeMeni();
        }

        private static void DodavanjeNoveUsluge()
        {
            var lista = Projekat.Instance.DodatnaUsluga;
            Console.WriteLine("===Dodavanje nove usluge===");
            var novaUsluga = new DodatnaUsluga();
            novaUsluga.Id = lista.Count + 1;

            Console.WriteLine("Unesite naziv usluge: ");
            novaUsluga.Usluga = Console.ReadLine();
            Console.WriteLine("Unesite cenu usluge: ");
            novaUsluga.Cena = int.Parse(Console.ReadLine());

            lista.Add(novaUsluga);
            GenericSerializer.Serialize<DodatnaUsluga>("dodatna_usluga.xml", lista);
            UslugeMeni();
        }

        private static void IzmenaUsluge()
        {
            DodatnaUsluga trazenaUsluga = null;
            string nazivTrazeneUsluge = "";
            var usluge = Projekat.Instance.DodatnaUsluga;

            do
            {
                Console.WriteLine("Unesite naziv usluge koji zelite da izmenite");
                nazivTrazeneUsluge = Console.ReadLine();

                foreach (var s in usluge)
                {
                    if (s.Usluga == nazivTrazeneUsluge)
                    {
                        trazenaUsluga = s;
                    }
                }
            } while (trazenaUsluga == null);

            Console.WriteLine("Unesite naziv usluge: ");
            trazenaUsluga.Usluga = Console.ReadLine();
            Console.WriteLine("Unesite cenu usluge: ");
            trazenaUsluga.Cena = int.Parse(Console.ReadLine());

            GenericSerializer.Serialize<DodatnaUsluga>("dodatna_usluga.xml", usluge);
            UslugeMeni();
        }

        private static void BrisanjeUsluge()
        {
            DodatnaUsluga trazenaUsluga = null;
            string nazivZaBrisanje = "";
            var usluge = Projekat.Instance.DodatnaUsluga;

            do
            {
                Console.WriteLine("Unesite naziv usluge koju zelite da obrisete");
                nazivZaBrisanje = Console.ReadLine();

                foreach (var sal in usluge)
                {
                    if (sal.Usluga == nazivZaBrisanje)
                    {
                        trazenaUsluga = sal;
                        sal.Obrisan = true;
                    }
                }
            } while (trazenaUsluga == null);

            GenericSerializer.Serialize<DodatnaUsluga>("dodatna_usluga.xml", usluge);
            UslugeMeni();
        }


        private static void KorisniciMeni()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("====Meni korisnika====");
                Console.WriteLine("1. Pregled korisnika");
                Console.WriteLine("2. Dodaj novog korisnika");
                Console.WriteLine("3. Izmeni korisnika");
                Console.WriteLine("4. Obrisi postojeceg");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 4);

            switch (izbor)
            {
                case 0:
                    IspisGlavnogMenija();
                    break;
                case 1:
                    PregledKorisnika();
                    break;
                case 2:
                    DodavanjeNovogKorisnika();
                    break;
                case 3:
                    IzmenaKorisnika();
                    break;
                case 4:
                    BrisanjeKorisnika();
                    break;
                default:
                    break;
            }
        }

        private static void PregledKorisnika()
        {
            Console.WriteLine("===Pregled korisnika===");
            var lista = Projekat.Instance.Korisnik;
            for (int i = 0; i < lista.Count; i++)
            {
                if (!lista[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}.{lista[i].Ime} {lista[i].Prezime}, {lista[i].TipKorisnika}");
                }
            }
            KorisniciMeni();
        }

        private static void DodavanjeNovogKorisnika()
        {
            var lista = Projekat.Instance.Korisnik;
            Console.WriteLine("===Dodavanje novog korisnika===");
            var novKorisnik = new Korisnik();
            novKorisnik.Id = lista.Count + 1;

            Console.WriteLine("Unesite ime: ");
            novKorisnik.Ime = Console.ReadLine();
            Console.WriteLine("Unesite prezime: ");
            novKorisnik.Prezime = Console.ReadLine();
            Console.WriteLine("Unesite username: ");
            novKorisnik.KorisnickoIme = Console.ReadLine();
            Console.WriteLine("Unesite lozinku: ");
            novKorisnik.Lozinka = Console.ReadLine();

            lista.Add(novKorisnik);
            GenericSerializer.Serialize<Korisnik>("korisnik.xml", lista);
            KorisniciMeni();
        }

        private static void IzmenaKorisnika()
        {
            Korisnik trazeniKorisnik = null;
            string userTrazenogKorisnika = "";
            var korisnici = Projekat.Instance.Korisnik;

            do
            {
                Console.WriteLine("Unesite user korisnika kojeg zelite da izmenite");
                userTrazenogKorisnika = Console.ReadLine();

                foreach (var s in korisnici)
                {
                    if (s.KorisnickoIme == userTrazenogKorisnika)
                    {
                        trazeniKorisnik = s;
                    }
                }
            } while (trazeniKorisnik == null);

            Console.WriteLine("Unesite ime: ");
            trazeniKorisnik.Ime = Console.ReadLine();
            Console.WriteLine("Unesite prezime: ");
            trazeniKorisnik.Prezime = Console.ReadLine();
            Console.WriteLine("Unesite novu sifru: ");
            trazeniKorisnik.Lozinka = Console.ReadLine();

            GenericSerializer.Serialize<Korisnik>("korisnik.xml", korisnici);
            KorisniciMeni();
        }

        private static void BrisanjeKorisnika()
        {
            Korisnik trazeniKorisnik = null;
            string nazivZaBrisanje = "";
            var korisnici = Projekat.Instance.Korisnik;

            do
            {
                Console.WriteLine("Unesite user korisnika kojeg zelite da obrisete");
                nazivZaBrisanje = Console.ReadLine();

                foreach (var sal in korisnici)
                {
                    if (sal.KorisnickoIme == nazivZaBrisanje)
                    {
                        trazeniKorisnik = sal;
                        sal.Obrisan = true;
                    }
                }
            } while (trazeniKorisnik == null);

            GenericSerializer.Serialize<Korisnik>("korisnik.xml", korisnici);
            KorisniciMeni();
        }


        private static void AkcijeMeni()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("====Meni akcija====");
                Console.WriteLine("1. Pregled akcija");
                Console.WriteLine("2. Dodaj novu akciju");
                Console.WriteLine("3. Izmeni akciju");
                Console.WriteLine("4. Obrisi postojecu");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 4);

            switch (izbor)
            {
                case 0:
                    IspisGlavnogMenija();
                    break;
                case 1:
                    PregledAkcija();
                    break;
                case 2:
                    DodavanjeNoveAkcije();
                    break;
                case 3:
                    //IzmenaAkcije();
                    break;
                case 4:
                    //BrisanjeKorisnika();
                    break;
                default:
                    break;
            }
        }

        private static void PregledAkcija()
        {
            Console.WriteLine("===Pregled akcija===");
            var lista = Projekat.Instance.Akcija;
            for (int i = 0; i < lista.Count; i++)
            {
                if (!lista[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}.{lista[i].Popust} {lista[i].PocetakAkcije}, {lista[i].KrajAkcije}");
                }
            }
            AkcijeMeni();
        }

        private static void DodavanjeNoveAkcije()
        {
            var lista = Projekat.Instance.Akcija;
            Console.WriteLine("===Dodavanje nove akcije===");
            var novaAkcija = new Akcija();
            novaAkcija.Id = lista.Count + 1;

            Console.WriteLine("Unesite popust: ");
            novaAkcija.Popust = double.Parse(Console.ReadLine());

            lista.Add(novaAkcija);
            GenericSerializer.Serialize<Akcija>("akcija.xml", lista);
            AkcijeMeni();
        }
        








        private static void Login()
        {
            Console.WriteLine("Login");
            var korisnici = Projekat.Instance.Korisnik;
            Console.WriteLine("Unesite korisnicko ime: ");
            var username = Console.ReadLine();
            Console.WriteLine("Unesite lozinku: ");
            var sifra = Console.ReadLine();

            //Korisnik trazeniKorisnik = null;
            TipKorisnika tipKorisnika;
            //string tipKorisnika = "";

            foreach (var k in korisnici)
            {
                if (!k.Obrisan && k.KorisnickoIme==username && k.Lozinka==sifra)
                {
                    //k.TipKorisnika = trazeniKorisnik;
                    //trazeniKorisnik = k;
                    tipKorisnika = k.TipKorisnika;

                    switch (tipKorisnika)
                    {
                        case TipKorisnika.Korisnik:
                            Console.WriteLine("ovo je korisnik");
                            Console.ReadLine();
                            break;
                        case TipKorisnika.Administrator:
                            Console.WriteLine("ovo je admin");
                            Console.ReadLine();
                            break;
                        case TipKorisnika.Prodavac:
                            Console.WriteLine("ovo je prodavac");
                            Console.ReadLine();
                            break;
                        default:
                            break;
                    }
                }
            }

        }
    }




}
