using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF382016.Model
{
    public class Namestaj : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private string sifra;
        private double cena;
        private int kolicinaUMagacinu;
        //public int idAkcije;
        public int idTipaNamestaja;
        private bool obrisan;
        private TipNamestaja tipNamestaja;
        private Akcija akcija;

        [XmlIgnore]
        public TipNamestaja TipNamestaja
        {
            get
            {
                if(tipNamestaja == null)
                {
                    tipNamestaja = TipNamestaja.GetById(IdTipaNamestaja);
                }
                return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                IdTipaNamestaja = tipNamestaja.Id;
                OnPropertyChanged("TipNamestaja");
            }
        }
        /*
        [XmlIgnore]
        public Akcija Akcija
        {
            get
            {
                if(akcija == null)
                {
                    akcija = Akcija.GetById(IdAkcije);
                }
                return akcija;
            }
            set
            {
                akcija = value;
                IdAkcije = akcija.Id;
                OnPropertyChanged("Akcija");
            }
        }
        */


        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        public string Sifra
        {
            get { return sifra; }
            set
            {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }

        public double Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }

        public int KolicinaUMagacinu
        {
            get { return kolicinaUMagacinu; }
            set
            {
                kolicinaUMagacinu = value;
                OnPropertyChanged("KolicinaUMagacinu");
            }
        }
        /*
        public int IdAkcije
        {
            get { return idAkcije; }
            set
            {
                idAkcije = value;
                OnPropertyChanged("IdAkcije");
            }
        }*/
        public int IdTipaNamestaja
        {
            get { return idTipaNamestaja; }
            set
            {
                idTipaNamestaja = value;
                OnPropertyChanged("IdTipaNamestaja");
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

        public event PropertyChangedEventHandler PropertyChanged;
        

        //treba izmeniti kod tipa da je int i da je to id, i dodati akciju i uraditi isto
        //public int? AkcijaId treba taj upitnik da bi bilo null a ne 0 (nullable)

        public override string ToString()
        {
            return $"{Naziv}, {Cena}, {TipNamestaja.GetById(IdTipaNamestaja).Naziv}";
        }

        public static Namestaj GetById(int id)
        {
            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if (namestaj.Id == id)
                {
                    return namestaj; //mozda nije id nego naziv ili nzm i onda pozivan Tipnamestaja.getbyid(idtipnamestaja)
                }
            }
            return null;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new Namestaj()
            {
                Id = id,
                Naziv = naziv,
                Sifra = sifra,
                Cena = cena,
                KolicinaUMagacinu = kolicinaUMagacinu,
                //IdAkcije = idAkcije,
                Obrisan = obrisan, 
                TipNamestaja = tipNamestaja,
                IdTipaNamestaja = idTipaNamestaja
            };
        }
    }
}
