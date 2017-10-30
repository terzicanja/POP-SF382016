using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF382016.Model
{
    public class Namestaj
    {
        public int Id { get; set; }

        public bool Obrisan { get; set; }

        public string Naziv { get; set; }

        //treba izmeniti kod tipa da je int i da je to id, i dodati akciju i uraditi isto
        //public int? AkcijaId treba taj upitnik da bi bilo null a ne 0 (nullable)

        public string Sifra { get; set; }

        public double Cena { get; set; }

        public int KolicinaUMagacinu { get; set; }

        public TipNamestaja TipNamestaja { get; set; }
    }
}
