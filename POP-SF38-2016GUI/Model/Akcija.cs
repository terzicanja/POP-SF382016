using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF382016.Model
{
    public class Akcija : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private DateTime pocetakAkcije;
        private DateTime krajAkcije;
        private double popust;
        //private List<int> idNamestaja;
        private ObservableCollection<int> idNamestaja;
        private bool obrisan;
        //private Namestaj namestaj;
        //public Namestaj selectedNamestaj;

        /*[XmlIgnore]
        public Namestaj Namestaj
        {
            get
            {
                if(namestaj == null)
                {
                    foreach (var i in IdNamestaja)
                    {
                        namestaj = Namestaj.GetById(IdNamestaja);
                    }
                    namestaj = Namestaj.GetById(IdNamestaja);
                    return namestaj;
                }
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

        public ObservableCollection<int> IdNamestaja
        {
            get { return idNamestaja; }
            set
            {
                idNamestaja = value;
                OnPropertyChanged("IdNamestaja");
            }
        }

        /*public Namestaj SelectedNamestaj
        {
            get { return selectedNamestaj; }
            set
            {
                if (selectedNamestaj == value) return;
                selectedNamestaj = value;
            }
        }
        private void IzabraniNamestaj()
        {
            var listaAkcija = Projekat.Instance.Akcija;
            
        }*/



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
                //IdNamestaja = idNamestaja,
                IdNamestaja = new ObservableCollection<int>(idNamestaja),
                Obrisan = obrisan
            };
        }
    }
}
