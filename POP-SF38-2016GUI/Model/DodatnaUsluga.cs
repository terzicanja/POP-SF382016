using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF382016.Model
{
    public class DodatnaUsluga : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string usluga;
        private int cena;
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

        public string Usluga
        {
            get { return usluga; }
            set
            {
                usluga = value;
                OnPropertyChanged("Usluga");
            }
        }

        public int Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
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



        public override string ToString()
        {
            return $"{Usluga}, {Cena} dinara";
        }

        public static DodatnaUsluga GetById(int id)
        {
            foreach (var a in Projekat.Instance.DodatnaUsluga)
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
            return new DodatnaUsluga()
            {
                Id = id,
                Usluga = usluga,
                Cena = cena,
                Obrisan = obrisan
            };
        }
    }
}
