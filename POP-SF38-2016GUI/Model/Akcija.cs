using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF382016.Model
{
    public class Akcija : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private DateTime pocetakAkcije;
        private DateTime krajAkcije;
        private double popust;
        private List<int> idNamestaja;
        private bool obrisan;

        

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public DateTime PocetakAkcije
        {
            get { return pocetakAkcije; }
            set
            {
                pocetakAkcije = value;
                OnPropertyChanged("PocetakAkcije");
            }
        }

        public DateTime KrajAkcije
        {
            get { return krajAkcije; }
            set
            {
                krajAkcije = value;
                OnPropertyChanged("KrajAkcije");
            }
        }

        public double Popust
        {
            get { return popust; }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
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

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }


        
        //public List<Namestaj> NamestajNaPopustu { get; set; }
        



        public event PropertyChangedEventHandler PropertyChanged;




        public override string ToString()
        {
            return $"{Popust}%, Pocetak akcije: {PocetakAkcije}, Kraj akcije: {KrajAkcije}";
        }

        public static Akcija GetById(int id)
        {
            foreach (var a in Projekat.Instance.Akcija)
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
            return new Akcija()
            {
                Id = id,
                PocetakAkcije = pocetakAkcije,
                KrajAkcije = krajAkcije,
                Popust = popust,
                IdNamestaja = idNamestaja,
                Obrisan = obrisan
            };
        }
    }
}
