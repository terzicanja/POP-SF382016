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

        public int? IdAkcije { get; set; }

        public int IdTipaNamestaja { get; set; }

        //public TipNamestaja TipNamestaja { get; set; }

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
    }
}
