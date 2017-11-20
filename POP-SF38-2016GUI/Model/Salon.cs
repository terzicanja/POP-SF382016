using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF382016.Model
{
    public class Salon : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private string adresa;
        private string telefon;
        private string email;
        private string sajt;
        private int pib;
        private int maticniBroj;
        private string ziroRacun;
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

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        public string Adresa
        {
            get { return adresa; }
            set
            {
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }

        public string Telefon
        {
            get { return telefon; }
            set
            {
                telefon = value;
                OnPropertyChanged("Telefon");
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Sajt
        {
            get { return sajt; }
            set
            {
                sajt = value;
                OnPropertyChanged("Sajt");
            }
        }

        public int PIB
        {
            get { return pib; }
            set
            {
                pib = value;
                OnPropertyChanged("PIB");
            }
        }

        public int MaticniBroj
        {
            get { return maticniBroj; }
            set
            {
                maticniBroj = value;
                OnPropertyChanged("MaticniBroj");
            }
        }

        public string ZiroRacun
        {
            get { return ziroRacun; }
            set
            {
                ziroRacun = value;
                OnPropertyChanged("ZiroRacun");
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



        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new Salon()
            {
                Id = id,
                Naziv = naziv,
                Adresa = adresa,
                Telefon = telefon,
                Email = email,
                Sajt = sajt,
                PIB = pib,
                MaticniBroj = maticniBroj, 
                ZiroRacun = ziroRacun, 
                Obrisan = obrisan
            };
        }

        public override string ToString()
        {
            return $"{Naziv}, {Adresa}, {Sajt}";
        }
    }
}
