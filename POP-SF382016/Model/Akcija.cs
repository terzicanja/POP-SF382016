using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF382016.Model
{
    class Akcija
    {
        public int Id { get; set; }

        public bool Obrisan { get; set; }

        public DateTime PocetakAkcije { get; set; }

        public DateTime KrajAkcije { get; set; }

        public List<Namestaj> NamestajNaPopustu { get; set; }

        public double Popust { get; set; }
    }
}
