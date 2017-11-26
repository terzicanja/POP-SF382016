using POP_SF38_2016GUI.UI;
using POP_SF382016.Model;
using POP_SF382016.utill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POP_SF38_2016GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Namestaj IzabraniNamestaj { get; set; }
        public TipNamestaja IzabraniTipNamestaja { get; set; }
        public Salon IzabraniSalon { get; set; }
        public DodatnaUsluga IzabranaUsluga { get; set; }
        public Akcija IzabranaAkcija { get; set; }
        public ProdajaNamestaja IzabranaProdaja { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            dgPrikaz.IsSynchronizedWithCurrentItem = true;
            dgPrikaz.DataContext = this;
            
        }
        
        string trenutnoAktivan = "";


        private void SalonPrikaz(object sender, RoutedEventArgs e)
        {
            trenutnoAktivan = "Salon";
            dgPrikaz.ItemsSource = Projekat.Instance.Salon;
        }

        private void NamestajPrikaz(object sender, RoutedEventArgs e)
        {
            dgPrikaz.ItemsSource = Projekat.Instance.Namestaj;
            //dgPrikaz.SelectedItem += "{Binding Path=IzabraniNamestaj}";
            trenutnoAktivan = "Namestaj";
            /*
            Button btn = Dodaj;
            btn.Name = "Dodaj";
            btn.Click += DodajNamestaj;*/
        }

        private void TipPrikaz(object sender, RoutedEventArgs e)
        {
            dgPrikaz.ItemsSource = Projekat.Instance.TipoviNamestaja;
            //dgPrikaz.SelectedItem = "{Binding Path=IzabraniTipNamestaja}";
            //Dodaj.Click += DodajTipNamestaja;
            trenutnoAktivan = "Tip";
            
            //Dodaj.Visibility = Visibility.Hidden;
        }

        private void UslugePrikaz(object sender, RoutedEventArgs e)
        {
            trenutnoAktivan = "Usluge";
            dgPrikaz.ItemsSource = Projekat.Instance.DodatnaUsluga;
        }

        private void AkcijePrikaz(object sender, RoutedEventArgs e)
        {
            trenutnoAktivan = "Akcije";
            dgPrikaz.ItemsSource = Projekat.Instance.Akcija;
        }
        
        private void ProdajePrikaz(object sender, RoutedEventArgs e)
        {
            trenutnoAktivan = "Prodaja";
            dgPrikaz.ItemsSource = Projekat.Instance.ProdajaNamestaja;
        }
        


        private void DodajNamestaj()
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = ""
            };
            var namestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.Dodavanje);
            namestajProzor.ShowDialog();
        }

        private void DodajTipNamestaja()
        {
            var noviTip = new TipNamestaja()
            {
                Naziv = ""
            };
            var tipProzor = new TipNamestajaWindow(noviTip, TipNamestajaWindow.Operacija.Dodavanje);
            tipProzor.ShowDialog();
        }

        private void DodajUslugu()
        {
            var novaUsluga = new DodatnaUsluga()
            {
                Usluga = "",
                Cena = 0
            };
            var uslugeProzor = new UslugeWindow(novaUsluga, NamestajWindow.Operacija.Dodavanje);
            uslugeProzor.ShowDialog();
        }

        //KAKO DA STAVI DANASNJI DATUM?? !!!!!
        private void DodajAkciju()
        {
            var novaAkcija = new Akcija()
            {
                Popust = 0
            };
            var prozor = new AkcijeWindow(novaAkcija, NamestajWindow.Operacija.Dodavanje);
            prozor.ShowDialog();
        }

        private void DodajProdaju()
        {
            var novaProdaja = new ProdajaNamestaja()
            {
                BrojRacuna = 0
            };
            var prozor = new ProdajeWindow(novaProdaja, NamestajWindow.Operacija.Dodavanje);
            prozor.ShowDialog();
        }



        private void IzmeniSalon()
        {
            Salon kopija = (Salon)IzabraniSalon.Clone();
            var prozor = new SalonWindow(kopija, SalonWindow.Operacija.Izmena);
            prozor.ShowDialog();
        }

        private void IzmeniNamestaj()
        {
            Namestaj kopija = (Namestaj)IzabraniNamestaj.Clone();
            var namestajProzor = new NamestajWindow(kopija, NamestajWindow.Operacija.Izmena);
            namestajProzor.ShowDialog();
        }
        
        private void IzmeniTipNamestaja()
        {
            TipNamestaja kopija = (TipNamestaja)IzabraniTipNamestaja.Clone();
            var prozor = new TipNamestajaWindow(kopija, TipNamestajaWindow.Operacija.Izmena);
            prozor.ShowDialog();
            //Prikaz();
        }
        
        private void IzmeniUslugu()
        {
            DodatnaUsluga kopija = (DodatnaUsluga)IzabranaUsluga.Clone();
            var prozor = new UslugeWindow(kopija, NamestajWindow.Operacija.Izmena);
            prozor.ShowDialog();
        }
        
        private void IzmeniAkciju()
        {
            Akcija kopija = (Akcija)IzabranaAkcija.Clone();
            var prozor = new AkcijeWindow(kopija, NamestajWindow.Operacija.Izmena);
            prozor.ShowDialog();
        }
        


        private void ObrisiNamestaj()
        {
            var izabraniNamestaj = (Namestaj)dgPrikaz.SelectedItem;
            var lista = Projekat.Instance.Namestaj;
            MessageBoxResult potvrda = MessageBox.Show($"Da li ste sigurni da zelite da obrisete {izabraniNamestaj.Naziv}?", "Brisanje", MessageBoxButton.YesNo);

            if(potvrda == MessageBoxResult.Yes)
            {
                foreach (var n in lista)
                {
                    if (n.Id == izabraniNamestaj.Id)
                    {
                        n.Obrisan = true;
                        break;
                    }
                }
                GenericSerializer.Serialize("namestaj.xml", lista);
            }
        }
        
        private void ObrisiTipNamestaja()
        {
            var izabraniTip = (TipNamestaja)dgPrikaz.SelectedItem;
            var lista = Projekat.Instance.TipoviNamestaja;
            MessageBoxResult potvrda = MessageBox.Show($"Da li ste sigurni da zelite da obrisete {izabraniTip.Naziv}?", "Brisanje", MessageBoxButton.YesNo);

            if (potvrda == MessageBoxResult.Yes)
            {
                foreach (var t in lista)
                {
                    if(t.Id == izabraniTip.Id)
                    {
                        t.Obrisan = true;
                        break;
                    }
                }
                GenericSerializer.Serialize("tip.xml", lista);
            }
        }

        private void ObrisiUslugu()
        {
            var izabraniTip = (DodatnaUsluga)dgPrikaz.SelectedItem;
            var lista = Projekat.Instance.DodatnaUsluga;
            MessageBoxResult potvrda = MessageBox.Show($"Da li ste sigurni da zelite da obrisete {izabraniTip.Usluga}?", "Brisanje", MessageBoxButton.YesNo);

            if (potvrda == MessageBoxResult.Yes)
            {
                foreach (var t in lista)
                {
                    if (t.Id == izabraniTip.Id)
                    {
                        t.Obrisan = true;
                        break;
                    }
                }
            }
            GenericSerializer.Serialize("dodatna_usluga.xml", lista);
        }

        private void ObrisiAkciju()
        {
            var izabranaAkcija = (Akcija)dgPrikaz.SelectedItem;
            var lista = Projekat.Instance.Akcija;
            MessageBoxResult potvrda = MessageBox.Show("Da li ste sigurni da zelite da obrisete?", "Brisanje", MessageBoxButton.YesNo);

            if(potvrda == MessageBoxResult.Yes)
            {
                foreach (var a in lista)
                {
                    if(a.Id == izabranaAkcija.Id)
                    {
                        a.Obrisan = true;
                        break;
                    }
                }
            }
            GenericSerializer.Serialize("akcija.xml", lista);
        }


        
        /*private void Proba(object p)
        {
            lbPrikaz.Items.Clear();
            //var nesto = Projekat.Instance.p;
            foreach (var s in p)
            {
                if (!s.Obrisan)
                {
                    lbPrikaz.Items.Add(s);
                }
            }
        }*/

        /*private void Prikaz()
        {
            switch (trenutnoAktivan)
            {
                case "Salon":
                    Proba(Projekat.Instance.Salon);
                    Dodaj.Visibility = Visibility.Hidden;
                    break;
                case "Namestaj":
                    dgPrikaz.ItemsSource = Projekat.Instance.Namestaj;
                    //Proba(Projekat.Instance.Namestaj);
                    Dodaj.Click += DodajNamestaj;
                    break;
                case "Tip":
                    Proba(Projekat.Instance.TipoviNamestaja);
                    Dodaj.Click += DodajTipNamestaja;
                    break;
                case "Usluge":
                    Proba(Projekat.Instance.DodatnaUsluga);
                    break;
                case "Akcije":
                    Proba(Projekat.Instance.Akcija);
                    break;
                default:
                    break;
            }
        }*/

        private void DugmeDodaj(object sender, RoutedEventArgs e)
        {
            switch (trenutnoAktivan)
            {
                case "Salon":
                    MessageBoxResult obavestenje = MessageBox.Show("Nije moguce dodati novi salon", "Obavestenje", MessageBoxButton.OK);
                    break;
                case "Namestaj":
                    DodajNamestaj();
                    break;
                case "Tip":
                    DodajTipNamestaja();
                    break;
                case "Usluge":
                    DodajUslugu();
                    break;
                case "Akcije":
                    DodajAkciju();
                    break;
                case "Prodaja":
                    DodajProdaju();
                    break;
                default:
                    break;
            }
        }

        private void DugmeIzmeni(object sender, RoutedEventArgs e)
        {
            switch (trenutnoAktivan)
            {
                case "Salon":
                    IzmeniSalon();
                    break;
                case "Namestaj":
                    IzmeniNamestaj();
                    break;
                case "Tip":
                    IzmeniTipNamestaja();
                    break;
                case "Usluge":
                    IzmeniUslugu();
                    break;
                case "Akcije":
                    IzmeniAkciju();
                    break;
                default:
                    break;
            }
        }

        private void DugmeObrisi(object sender, RoutedEventArgs e)
        {
            switch (trenutnoAktivan)
            {
                case "Salon":
                    MessageBoxResult obavestenje = MessageBox.Show("Nije moguce obrisati salon", "Obavestenje", MessageBoxButton.OK);
                    break;
                case "Namestaj":
                    ObrisiNamestaj();
                    break;
                case "Tip":
                    ObrisiTipNamestaja();
                    break;
                case "Usluge":
                    ObrisiUslugu();
                    break;
                case "Akcije":
                    ObrisiAkciju();
                    break;
                default:
                    break;
            }
        }

        
        //wpf control !!!!!!!!
        //i sve u try catch
        

        private void ZatvoriSalon(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
