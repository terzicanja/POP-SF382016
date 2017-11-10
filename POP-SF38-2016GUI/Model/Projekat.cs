using POP_SF382016.utill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF382016.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; set;  } = new Projekat();


        private List<Namestaj> namestaj;

        public List<Namestaj> Namestaj
        {
            get
            {
                this.namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
                return namestaj;
            }
            set
            {
                this.namestaj = value;
                GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestaj);
            }
        }


        private List<TipNamestaja> tip;

        public List<TipNamestaja> Tip
        {
            get
            {
                this.tip = GenericSerializer.Deserialize<TipNamestaja>("tip.xml");
                return tip;
            }
            set
            {
                this.tip = value;
                GenericSerializer.Serialize<TipNamestaja>("tip.xml", tip);
            }
        }


        private List<Korisnik> korisnik;

        public List<Korisnik> Korisnik
        {
            get
            {
                this.korisnik = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
                return korisnik;
            }
            set
            {
                korisnik = value;
                GenericSerializer.Serialize<Korisnik>("korisnik.xml", korisnik);
            }
        }

        
        private List<Akcija> akcija;

        public List<Akcija> Akcija
        {
            get
            {
                this.akcija = GenericSerializer.Deserialize<Akcija>("akcija.xml");
                return akcija;
            }
            set
            {
                akcija = value;
                GenericSerializer.Serialize<Akcija>("akcija.xml", akcija);
            }
        }


        private List<DodatnaUsluga> dodatnaUsluga;

        public List<DodatnaUsluga> DodatnaUsluga
        {
            get
            {
                this.dodatnaUsluga = GenericSerializer.Deserialize<DodatnaUsluga>("dodatna_usluga.xml");
                return dodatnaUsluga;
            }
            set
            {
                dodatnaUsluga = value;
                GenericSerializer.Serialize<DodatnaUsluga>("dodatna_usluga.xml", dodatnaUsluga);
            }
        }


        private List<ProdajaNamestaja> prodajaNamestaja;

	    public List<ProdajaNamestaja> ProdajaNamestaja
	    {
		    get 
            {
                this.prodajaNamestaja = GenericSerializer.Deserialize<ProdajaNamestaja>("prodaja.xml");
                return prodajaNamestaja;
            }
		    set 
            { 
                prodajaNamestaja = value;
                GenericSerializer.Serialize<ProdajaNamestaja>("prodaja.xml", prodajaNamestaja);
            }
	    }


        private List<Salon> salon;

	    public List<Salon> Salon
	    {
		    get
            {
                this.salon = GenericSerializer.Deserialize<Salon>("salon.xml");
                return salon;
            }
		    set
            {
                salon = value;
                GenericSerializer.Serialize<Salon>("salon.xml", salon);
            }
	    }

        









    }
}
