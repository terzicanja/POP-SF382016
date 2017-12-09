using POP_SF38_2016GUI.UI;
using POP_SF382016.Model;
using POP_SF382016.utill;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public Korisnik IzabraniKorisnik { get; set; }
        public object IzabranaStavka { get; set; }

        ICollectionView view;

        public MainWindow()
        {
            InitializeComponent();

            //view = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
            //view.Filter = PrikazFilter;
            //dgPrikaz.ItemsSource = view;
            dgPrikaz.IsSynchronizedWithCurrentItem = true;
            dgPrikaz.DataContext = this;

            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private bool NamestajFilter(object obj)
        {
            return !((Namestaj)obj).Obrisan;
        }

        private bool SalonFilter(object obj)
        {
            return !((Salon)obj).Obrisan;
        }

        private bool TipFilter(object obj)
        {
            return !((TipNamestaja)obj).Obrisan;
        }

        private bool UslugeFilter(object obj)
        {
            return !((DodatnaUsluga)obj).Obrisan;
        }

        private bool AkcijeFilter(object obj)
        {
            return !((Akcija)obj).Obrisan;
        }

        private bool KorisniciFilter(object obj)
        {
            return !((Korisnik)obj).Obrisan;
        }



        string trenutnoAktivan = "";


        private void SalonPrikaz(object sender, RoutedEventArgs e)
        {
            trenutnoAktivan = "Salon";
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Salon);
            view.Filter = SalonFilter;
            dgPrikaz.ItemsSource = view;
            //dgPrikaz.ItemsSource = Projekat.Instance.Salon;
        }

        private void NamestajPrikaz(object sender, RoutedEventArgs e)
        {
            //dgPrikaz.ItemsSource = Projekat.Instance.Namestaj;
            //dgPrikaz.SelectedItem += "{Binding Path=IzabraniNamestaj}";

            trenutnoAktivan = "Namestaj";
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
            view.Filter = NamestajFilter;
            dgPrikaz.ItemsSource = view;

            /*
            Button btn = Dodaj;
            btn.Name = "Dodaj";
            btn.Click += DodajNamestaj;
            Dodaj.Click += DodajTipNamestaja;
            Dodaj.Visibility = Visibility.Hidden;*/
        }

        private void TipPrikaz(object sender, RoutedEventArgs e)
        {
            //dgPrikaz.ItemsSource = Projekat.Instance.TipoviNamestaja;
            trenutnoAktivan = "Tip";
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.TipoviNamestaja);
            view.Filter = TipFilter;
            dgPrikaz.ItemsSource = view;

        }

        private void UslugePrikaz(object sender, RoutedEventArgs e)
        {
            trenutnoAktivan = "Usluge";
            //dgPrikaz.ItemsSource = Projekat.Instance.DodatnaUsluga;
            //dgPrikaz.SelectedItem = IzabranaUsluga;
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.DodatnaUsluga);
            view.Filter = UslugeFilter;
            dgPrikaz.ItemsSource = view;
        }

        private void AkcijePrikaz(object sender, RoutedEventArgs e)
        {
            trenutnoAktivan = "Akcije";
            //dgPrikaz.ItemsSource = Projekat.Instance.Akcija;
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Akcija);
            view.Filter = AkcijeFilter;
            dgPrikaz.ItemsSource = view;
        }
        
        private void ProdajePrikaz(object sender, RoutedEventArgs e)
        {
            trenutnoAktivan = "Prodaja";
            dgPrikaz.ItemsSource = Projekat.Instance.ProdajaNamestaja;
            //dgPrikaz.SelectedItem = IzabranaProdaja;
            //view = CollectionViewSource.GetDefaultView(Projekat.Instance.ProdajaNamestaja);
            //view.Filter = ProdajeFilter;
            //dgPrikaz.ItemsSource = view;
        }

        private void KorisniciPrikaz(object sender, RoutedEventArgs e)
        {
            trenutnoAktivan = "Korisnici";
            //dgPrikaz.ItemsSource = Projekat.Instance.Korisnik;
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Korisnik);
            view.Filter = KorisniciFilter;
            dgPrikaz.ItemsSource = view;
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
                Popust = 0,
                PocetakAkcije = DateTime.Today,
                KrajAkcije = DateTime.Now,
                IdNamestaja = new ObservableCollection<int>()
            };
            var prozor = new AkcijeWindow(novaAkcija, NamestajWindow.Operacija.Dodavanje);
            prozor.ShowDialog();
        }

        private void DodajProdaju()
        {
            var novaProdaja = new ProdajaNamestaja()
            {
                IdStavki = new ObservableCollection<int>(),
                DatumProdaje = DateTime.Today,
                BrojRacuna = 0,
                Kupac = "",
                IdUsluga = new ObservableCollection<int>()
            };
            var prozor = new ProdajeWindow(novaProdaja, NamestajWindow.Operacija.Dodavanje);
            prozor.ShowDialog();
        }

        private void DodajKorisnika()
        {
            var noviKorisnik = new Korisnik()
            {
                Ime = ""
            };
            var prozor = new KorisniciWindow(noviKorisnik, NamestajWindow.Operacija.Dodavanje);
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
            Namestaj oznacen = dgPrikaz.SelectedItem as Namestaj;
            Namestaj kopija = (Namestaj)oznacen.Clone();
            var namestajProzor = new NamestajWindow(kopija, NamestajWindow.Operacija.Izmena);
            namestajProzor.ShowDialog();
        }
        
        private void IzmeniTipNamestaja()
        {
            TipNamestaja oznacen = dgPrikaz.SelectedItem as TipNamestaja;
            TipNamestaja kopija = (TipNamestaja)oznacen.Clone();
            var prozor = new TipNamestajaWindow(kopija, TipNamestajaWindow.Operacija.Izmena);
            prozor.ShowDialog();
            //Prikaz();
        }
        
        private void IzmeniUslugu()
        {
            DodatnaUsluga oznacen = dgPrikaz.SelectedItem as DodatnaUsluga;
            DodatnaUsluga kopija = (DodatnaUsluga)oznacen.Clone();
            var prozor = new UslugeWindow(kopija, NamestajWindow.Operacija.Izmena);
            prozor.ShowDialog();
        }
        
        private void IzmeniAkciju()
        {
            Akcija oznacen = dgPrikaz.SelectedItem as Akcija;
            Akcija kopija = (Akcija)oznacen.Clone();
            var prozor = new AkcijeWindow(kopija, NamestajWindow.Operacija.Izmena);
            prozor.ShowDialog();
        }

        private void IzmeniProdaju()
        {
            ProdajaNamestaja oznacen = dgPrikaz.SelectedItem as ProdajaNamestaja;
            ProdajaNamestaja kopija = (ProdajaNamestaja)oznacen.Clone();
            var prozor = new ProdajeWindow(kopija, NamestajWindow.Operacija.Izmena);
            prozor.ShowDialog();
        }

        private void IzmeniKorisnika()
        {
            Korisnik oznacen = dgPrikaz.SelectedItem as Korisnik;
            Korisnik kopija = (Korisnik)oznacen.Clone();
            var prozor = new KorisniciWindow(kopija, NamestajWindow.Operacija.Izmena);
            prozor.ShowDialog();
        }
        


        private void ObrisiNamestaj()
        {
            var IzabraniNamestaj = (Namestaj)dgPrikaz.SelectedItem;
            var lista = Projekat.Instance.Namestaj;
            MessageBoxResult potvrda = MessageBox.Show($"Da li ste sigurni da zelite da obrisete {IzabraniNamestaj.Naziv}?", "Brisanje", MessageBoxButton.YesNo);

            if(potvrda == MessageBoxResult.Yes)
            {
                foreach (var n in lista)
                {
                    if (n.Id == IzabraniNamestaj.Id)
                    {
                        n.Obrisan = true;
                        view.Refresh();
                        break;
                    }
                }
                GenericSerializer.Serialize("namestaj.xml", lista);
            }
        }
        
        private void ObrisiTipNamestaja()
        {
            var izabraniTip = (TipNamestaja)dgPrikaz.SelectedItem;
            var listaNamestaja = Projekat.Instance.Namestaj;
            var lista = Projekat.Instance.TipoviNamestaja;
            MessageBoxResult potvrda = MessageBox.Show($"Da li ste sigurni da zelite da obrisete {izabraniTip.Naziv}?", "Brisanje", MessageBoxButton.YesNo);

            if (potvrda == MessageBoxResult.Yes)
            {
                foreach (var t in lista)
                {
                    if(t.Id == izabraniTip.Id)
                    {
                        t.Obrisan = true;
                        foreach (var nam in listaNamestaja)
                        {
                            if (t.Id == nam.IdTipaNamestaja)
                            {
                                nam.Obrisan = true;
                            }
                        }
                        view.Refresh();
                        break;
                    }

                    /*if (t.Obrisan)
                    {
                        foreach (var nam in listaNamestaja)
                        {
                            if(t.Id == nam.IdTipaNamestaja)
                            {
                                nam.Obrisan = true;
                            }
                        }
                    }*/
                }
                GenericSerializer.Serialize("tip.xml", lista);
                GenericSerializer.Serialize("namestaj.xml", listaNamestaja);
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
                        view.Refresh();
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
                        view.Refresh();
                        break;
                    }
                }
            }
            GenericSerializer.Serialize("akcija.xml", lista);
        }

        private void ObrisiKorisnika()
        {
            var izabraniKorisnik = (Korisnik)dgPrikaz.SelectedItem;
            var lista = Projekat.Instance.Korisnik;
            MessageBoxResult potvrda = MessageBox.Show("Da li ste sigurni da zelite da obrisete?", "Brisanje", MessageBoxButton.YesNo);

            if (potvrda == MessageBoxResult.Yes)
            {
                foreach (var a in lista)
                {
                    if (a.Id == izabraniKorisnik.Id)
                    {
                        a.Obrisan = true;
                        view.Refresh();
                        break;
                    }
                }
            }
            GenericSerializer.Serialize("korisnik.xml", lista);
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
                case "Korisnici":
                    DodajKorisnika();
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
                case "Prodaja":
                    IzmeniProdaju();
                    break;
                case "Korisnici":
                    IzmeniKorisnika();
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
                case "Korisnici":
                    ObrisiKorisnika();
                    break;
                case "Prodaja":
                    MessageBoxResult obavestenjeP = MessageBox.Show("Nije moguce obrisati prodaju", "Obavestenje", MessageBoxButton.OK);
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

        private void dgPrikaz_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if((string)e.Column.Header == "Id" || (string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "PIB"
                || (string)e.Column.Header == "IdStavki" || (string)e.Column.Header == "IdTipaNamestaja" || (string)e.Column.Header == "IdAkcije")
            {
                e.Cancel = true;
            } 
        }

        private void dgPrikaz_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()+1).ToString();
            //+1 je da krene da broji od 1
        }
    }
}
