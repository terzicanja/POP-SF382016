using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF382016.Model
{
    public class ProdajaNamestaja : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private List<int> idNamestaja;
        private DateTime datumProdaje;
        private int brojRacuna;
        private int idKupca;
        private double pdv;
        private List<int> idUsluga;
        private double ukupanIznos;
        private Korisnik korisnik;


        public Korisnik Korisnik
        {
            get
            {
                if(korisnik == null)
                {
                    korisnik = Korisnik.GetById(IdKupca);
                }
                return korisnik;
            }
            set
            {
                korisnik = value;
                IdKupca = korisnik.Id;
                OnPropertyChanged("IdKupca");
            }
        }



        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public List<int> IdNamestaja
        {
            get { return idNamestaja; }
            set
            {
                idNamestaja = value;
                OnPropertyChanged("IdNamestaja");
            }
        }

        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }
        }

        public int BrojRacuna
        {
            get { return brojRacuna; }
            set
            {
                brojRacuna = value;
                OnPropertyChanged("BrojRacuna");
            }
        }

        public int IdKupca
        {
            get { return idKupca; }
            set
            {
                idKupca = value;
                OnPropertyChanged("IdKupca");
            }
        }

        public double PDV
        {
            get { return pdv; }
            set
            {
                pdv = value;
                OnPropertyChanged("PDV");
            }
        }

        public List<int> IdUsluga
        {
            get { return idUsluga; }
            set
            {
                idUsluga = value;
                OnPropertyChanged("IdUsluga");
            }
        }

        public double UkupanIznos
        {
            get { return ukupanIznos; }
            set
            {
                ukupanIznos = value;
                OnPropertyChanged("UkupanIznos");
            }
        }



        //public List<Namestaj> NamestajZaProdaju { get; set; }

        //public List<DodatnaUsluga> DodatnaUsluga { get; set; }
        


        public event PropertyChangedEventHandler PropertyChanged;



        public override string ToString()
        {
            return $"{DatumProdaje}, {IdKupca}";
        }

        public static ProdajaNamestaja GetById(int id)
        {
            foreach (var a in Projekat.Instance.ProdajaNamestaja)
            {
                if (a.Id == id)
                {
                    return a;
                }
            }
            return null;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new ProdajaNamestaja()
            {
                Id = id,
                IdNamestaja = idNamestaja,
                DatumProdaje = datumProdaje,
                BrojRacuna = brojRacuna,
                IdKupca = idKupca,
                PDV = pdv,
                IdUsluga = idUsluga,
                UkupanIznos = ukupanIznos
            };
        }
    }
}
