using POP_SF382016.utill;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF382016.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();

        public ObservableCollection<Namestaj> Namestaj { get; set; }
        public ObservableCollection<TipNamestaja> TipoviNamestaja { get; set; }
        public ObservableCollection<Korisnik> Korisnik { get; set; }
        public ObservableCollection<Akcija> Akcija { get; set; }
        public ObservableCollection<DodatnaUsluga> DodatnaUsluga { get; set; }
        public ObservableCollection<ProdajaNamestaja> ProdajaNamestaja { get; set; }
        public ObservableCollection<Salon> Salon { get; set; }


        private Projekat()
        {
            Namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
            TipoviNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tip.xml");
            Korisnik = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
            Akcija = GenericSerializer.Deserialize<Akcija>("akcija.xml");
            DodatnaUsluga = GenericSerializer.Deserialize<DodatnaUsluga>("dodatna_usluga.xml");
            ProdajaNamestaja = GenericSerializer.Deserialize<ProdajaNamestaja>("prodaja.xml");
            Salon = GenericSerializer.Deserialize<Salon>("salon.xml");
        }
        

    }
}
