using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF382016.Model
{
    public class ProdajaNamestaja : INotifyPropertyChanged, ICloneable
    {
        private int id;
        //private List<int> idNamestaja;
        private ObservableCollection<int> idStavki;
        private DateTime datumProdaje;
        private int brojRacuna;
        //private int idKupca;
        private string kupac;
        private double pdv;
        private ObservableCollection<int> idUsluga;
        private double ukupanIznos;
        /*private Korisnik korisnik;


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
        }*/



        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public ObservableCollection<int> IdStavki
        {
            get { return idStavki; }
            set
            {
                idStavki = value;
                OnPropertyChanged("IdStavki");
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

        public string Kupac
        {
            get { return kupac; }
            set
            {
                kupac = value;
                OnPropertyChanged("Kupac");
            }
        }

        public double PDV
        {
            get { return 0.02; }
            /*set
            {
                pdv = value;
                OnPropertyChanged("PDV");
            }*/
        }

        public ObservableCollection<int> IdUsluga
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
            return $"{DatumProdaje}, {Kupac}";
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
                IdStavki = new ObservableCollection<int>(idStavki),
                DatumProdaje = datumProdaje,
                BrojRacuna = brojRacuna,
                Kupac = kupac,
                //PDV = 0.2,
                IdUsluga = new ObservableCollection<int>(idUsluga),
                UkupanIznos = ukupanIznos
            };
        }
    }
}
