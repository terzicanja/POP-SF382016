using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF382016.Model
{
    public class DodatnaUsluga
    {
        public int Id { get; set; }

        public bool Obrisan { get; set; }

        public string Usluga { get; set; }

        public int Cena { get; set; }


        public override string ToString()
        {
            return $"{Usluga}, {Cena}";
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
    }
}
