using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF382016.Model
{
    public class ProdajaNamestaja
    {
        public int Id { get; set; }

        //i ovde isto nije lista namestaja nego lista integera id namestaja, i tako za svaku listu otp
        public List<Namestaj> NamestajZaProdaju { get; set; }

        public DateTime DatumProdaje { get; set; }

        public int BrojRacuna { get; set; }

        public string Kupac { get; set; }

        public double PDV { get; set; }

        public List<DodatnaUsluga> DodatnaUsluga { get; set; }

        public double UkupanIznos { get; set; }
    }
}
