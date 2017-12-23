using POP_SF382016.Model;
//using POP_SF382016.utill;
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

        public ObservableCollection<Namestaj> Namestaji { get; set; }
        public ObservableCollection<TipNamestaja> TipoviNamestaja { get; set; }
        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public ObservableCollection<Akcija> Akcije { get; set; }
        public ObservableCollection<DodatnaUsluga> DodatneUsluge { get; set; }
        public ObservableCollection<ProdajaNamestaja> ProdajeNamestaja { get; set; }
        public ObservableCollection<Salon> Salon { get; set; }
        public ObservableCollection<StavkaProdaje> StavkeProdaje { get; set; }
        public ObservableCollection<UslugaProdaje> UslugeProdaje { get; set; }
        public ObservableCollection<NaAkciji> NaAkcijama { get; set; }


        private Projekat()
        {
            //Akcije = Akcija.GetAll();
            Namestaji = Namestaj.GetAll();
            TipoviNamestaja = TipNamestaja.GetAll();
            Korisnici = Korisnik.GetAll();
            DodatneUsluge = DodatnaUsluga.GetAll();
            ProdajeNamestaja = ProdajaNamestaja.GetAll();
            StavkeProdaje = StavkaProdaje.GetAll();
            UslugeProdaje = UslugaProdaje.GetAll();
            Akcije = Akcija.GetAll();
            NaAkcijama = NaAkciji.GetAll();

            //Namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
            //TipoviNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tip.xml");
            //Korisnik = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
            //Akcije = GenericSerializer.Deserialize<Akcija>("akcija.xml");
            //DodatneUsluge = GenericSerializer.Deserialize<DodatnaUsluga>("dodatna_usluga.xml");
            //ProdajeNamestaja = GenericSerializer.Deserialize<ProdajaNamestaja>("prodaja.xml");
            Salon = GenericSerializer.Deserialize<Salon>("salon.xml");
            //StavkeProdaje = GenericSerializer.Deserialize<StavkaProdaje>("stavka.xml");
        }
        

    }
}
