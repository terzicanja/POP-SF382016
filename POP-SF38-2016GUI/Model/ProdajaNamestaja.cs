﻿using System;
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
        //public List<Namestaj> NamestajZaProdaju { get; set; }


        public List<int> IdNamestaja { get; set; }

        public DateTime DatumProdaje { get; set; }

        public int BrojRacuna { get; set; }

        public int IdKupca { get; set; }

        public double PDV { get; set; }

        //public List<DodatnaUsluga> DodatnaUsluga { get; set; }
        public List<int> IdUsluga { get; set; }

        public double UkupanIznos { get; set; }


        public override string ToString()
        {
            return $"{DatumProdaje}, {IdKupca}";
        }

        public static ProdajaNamestaja GetById(int id)
        {
            foreach (var a in Projekat.Instance.ProdajaNamestaja)
            {
                if (a.Id == id)
                {
                    return a;
                }
            }
            return null;
        }
    }
}
