using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF382016.Model
{
    public class Akcija
    {
        public int Id { get; set; }

        public bool Obrisan { get; set; }

        public DateTime PocetakAkcije { get; set; }

        public DateTime KrajAkcije { get; set; }

        //public List<Namestaj> NamestajNaPopustu { get; set; }

        public double Popust { get; set; }

        public List<int> IdNamestaja { get; set; }


        public override string ToString()
        {
            return $"{Popust}%, Pocetak akcije: {PocetakAkcije}, Kraj akcije: {KrajAkcije}";
        }

        /*
        public static Akcija AkcijaById(int id)
        {
            foreach (var akcija in Projekat.Instance.Akcija)
            {
                if(akcija.Id == id)
                {
                    return akcija;
                }
            }
            return null;
        }*/
    }
}
