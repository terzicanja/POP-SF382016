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
using MahApps.Metro.Controls;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;

namespace POP_SF38_2016GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ICollectionView view;
        public ProdajaNamestaja SelektovanaProdaja = null;
        public TipKorisnika tipKorisnika;
        public ProdajaNamestaja novaProdaja = null;

        public MainWindow(TipKorisnika tipKorisnika)
        {
            InitializeComponent();

            this.tipKorisnika = tipKorisnika;
            SelektovanaProdaja = new ProdajaNamestaja();

            dgPrikaz.IsSynchronizedWithCurrentItem = true;
            dgPrikaz.DataContext = this;

            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);



            switch (tipKorisnika)
            {
                case TipKorisnika.Administrator:
                    break;
                case TipKorisnika.Prodavac:
                    Dodaj.Visibility = Visibility.Collapsed;
                    Obrisi.Visibility = Visibility.Collapsed;
                    Izmeni.Visibility = Visibility.Collapsed;
                    btnKorisnici.Visibility = Visibility.Collapsed;

                    switch (trenutnoAktivan)
                    {
                        case "Prodaja":
                            Dodaj.Visibility = Visibility.Visible;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
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

        /*private bool AkcijeFilter(object obj)
        {
            return !((Akcija)obj).Obrisan;
        }*/
        private bool AkcijeFilter(object obj)
        {
            Akcija akk = obj as Akcija;
            return (akk.Id > 0);
        }

        private bool KorisniciFilter(object obj)
        {
            return !((Korisnik)obj).Obrisan;
        }



        string trenutnoAktivan = "";


        private void SalonPrikaz(object sender, RoutedEventArgs e)
        {
            trenutnoAktivan = "Salon";
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Saloni);
            view.Filter = SalonFilter;
            dgPrikaz.ItemsSource = view;

            if (tipKorisnika == TipKorisnika.Prodavac)
            {
                Dodaj.Visibility = Visibility.Collapsed;
            }
            //dgPrikaz.ItemsSource = Projekat.Instance.Salon;
        }

        private void NamestajPrikaz(object sender, RoutedEventArgs e)
        {
            //dgPrikaz.ItemsSource = Projekat.Instance.Namestaji;
            //dgPrikaz.SelectedItem += "{Binding Path=IzabraniNamestaj}";

            trenutnoAktivan = "Namestaj";
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaji);
            view.Filter = NamestajFilter;
            dgPrikaz.ItemsSource = view;

            cbSort.Items.Clear();
            cbSort.Items.Add("Nazivu");
            cbSort.Items.Add("Ceni");
            cbSort.Items.Add("Kolicini");

            if (tipKorisnika == TipKorisnika.Prodavac)
            {
                Dodaj.Visibility = Visibility.Collapsed;
            }
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
            //dgPrikaz.ItemsSource = Projekat.Instance.UslugeProdaje;
            trenutnoAktivan = "Tip";
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.TipoviNamestaja);
            view.Filter = TipFilter;
            dgPrikaz.ItemsSource = view;

            cbSort.Items.Clear();
            cbSort.Items.Add("Nazivu");

            if (tipKorisnika == TipKorisnika.Prodavac)
            {
                Dodaj.Visibility = Visibility.Collapsed;
            }

            /*if(cbSort.SelectedIndex > -1)
            {
                //string orderby = cbSort.SelectedItem.ToString();
                string orderby = cbSort.SelectionBoxItem.ToString();
                if (orderby == "Nazivu")
                {
                    view = CollectionViewSource.GetDefaultView(TipNamestaja.Search(tbSearch.Text, "Naziv"));
                    view.Filter = TipFilter;
                    dgPrikaz.ItemsSource = view;
                }
            }*/
        }

        private void UslugePrikaz(object sender, RoutedEventArgs e)
        {
            trenutnoAktivan = "Usluge";
            //dgPrikaz.ItemsSource = Projekat.Instance.DodatnaUsluga;
            //dgPrikaz.SelectedItem = IzabranaUsluga;
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.DodatneUsluge);
            view.Filter = UslugeFilter;
            dgPrikaz.ItemsSource = view;

            cbSort.Items.Clear();
            cbSort.Items.Add("Nazivu");
            cbSort.Items.Add("Ceni");

            if (tipKorisnika == TipKorisnika.Prodavac)
            {
                Dodaj.Visibility = Visibility.Collapsed;
            }
        }

        private void AkcijePrikaz(object sender, RoutedEventArgs e)
        {
            trenutnoAktivan = "Akcije";
            //dgPrikaz.ItemsSource = Projekat.Instance.Akcije;
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Akcije);
            view.Filter = AkcijeFilter;
            dgPrikaz.ItemsSource = view;

            cbSort.Items.Clear();
            cbSort.Items.Add("Nazivu");
            cbSort.Items.Add("Pocetku akcije");
            cbSort.Items.Add("Kraju akcije");
            cbSort.Items.Add("Popustu");
            if (tipKorisnika == TipKorisnika.Prodavac)
            {
                Dodaj.Visibility = Visibility.Collapsed;
            }
        }
        
        private void ProdajePrikaz(object sender, RoutedEventArgs e)
        {
            trenutnoAktivan = "Prodaja";
            dgPrikaz.ItemsSource = Projekat.Instance.ProdajeNamestaja;

            cbSort.Items.Clear();
            cbSort.Items.Add("Datumu prodaje");
            cbSort.Items.Add("Kupcu");
            cbSort.Items.Add("Ukupnom iznosu");

            if (tipKorisnika == TipKorisnika.Prodavac)
            {
                Dodaj.Visibility = Visibility.Visible;
            }
            //dgPrikaz.SelectedItem = IzabranaProdaja;
            //view = CollectionViewSource.GetDefaultView(Projekat.Instance.ProdajaNamestaja);
            //view.Filter = ProdajeFilter;
            //dgPrikaz.ItemsSource = view;
        }

        private void KorisniciPrikaz(object sender, RoutedEventArgs e)
        {
            trenutnoAktivan = "Korisnici";
            //dgPrikaz.ItemsSource = Projekat.Instance.Korisnik;
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Korisnici);
            view.Filter = KorisniciFilter;
            dgPrikaz.ItemsSource = view;

            cbSort.Items.Clear();
            cbSort.Items.Add("Imenu");
            cbSort.Items.Add("Prezimenu");
            cbSort.Items.Add("Korisnickom imenu");
        }


        #region Dodavanje
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

        private void DodajAkciju()
        {
            var novaAkcija = new Akcija()
            {
                Naziv = "bazz",
                Popust = 11,
                PocetakAkcije = DateTime.Today,
                KrajAkcije = DateTime.Now,
                //IdNamestaja = new ObservableCollection<int>()
            };
            Akcija.Create(novaAkcija);
            var prozor = new AkcijeWindow(novaAkcija, NamestajWindow.Operacija.Dodavanje);
            prozor.ShowDialog();
            view.Refresh();
        }

        private void DodajProdaju()
        {
            novaProdaja = new ProdajaNamestaja()
            {
                DatumProdaje = DateTime.Now,
                Kupac = "proba za bazu",
                BrojRacuna = 123
                //IdUsluga = new ObservableCollection<int>()
            };
            ProdajaNamestaja.Create(novaProdaja);
            var prozor = new ProdajeWindow(novaProdaja, NamestajWindow.Operacija.Dodavanje);
            prozor.ShowDialog();
            //view.Refresh();
        }

        private void DodajKorisnika()
        {
            var noviKorisnik = new Korisnik()
            {
                Ime = "",
                Prezime = "",
                Lozinka = "",
                KorisnickoIme = ""
            };
            var prozor = new KorisniciWindow(noviKorisnik, NamestajWindow.Operacija.Dodavanje);
            prozor.ShowDialog();
        }
        #endregion

        #region Izmena
        private void IzmeniSalon()
        {
            Salon oznacen = dgPrikaz.SelectedItem as Salon;
            Salon kopija = (Salon)oznacen.Clone();
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
        #endregion

        #region Brisanje
        private void ObrisiNamestaj()
        {
            var IzabraniNamestaj = (Namestaj)dgPrikaz.SelectedItem;
            var lista = Projekat.Instance.Namestaji;
            MessageBoxResult potvrda = MessageBox.Show($"Da li ste sigurni da zelite da obrisete {IzabraniNamestaj.Naziv}?", "Brisanje", MessageBoxButton.YesNo);

            if(potvrda == MessageBoxResult.Yes)
            {
                foreach (var n in lista)
                {
                    if (n.Id == IzabraniNamestaj.Id)
                    {
                        //n.Obrisan = true;
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
            var listaNamestaja = Projekat.Instance.Namestaji;
            var lista = Projekat.Instance.TipoviNamestaja;
            MessageBoxResult potvrda = MessageBox.Show($"Da li ste sigurni da zelite da obrisete {izabraniTip.Naziv}?", "Brisanje", MessageBoxButton.YesNo);

            if (potvrda == MessageBoxResult.Yes)
            {
                foreach (var t in lista)
                {
                    if(t.Id == izabraniTip.Id)
                    {
                        TipNamestaja.Delete(t);
                        foreach (var nam in listaNamestaja)
                        {
                            if (t.Id == nam.IdTipaNamestaja)
                            {
                                Namestaj.Delete(nam);
                            }
                        }
                        view.Refresh();
                        break;
                    }
                }
            }
        }

        private void ObrisiUslugu()
        {
            var izabraniTip = (DodatnaUsluga)dgPrikaz.SelectedItem;
            var lista = Projekat.Instance.DodatneUsluge;
            MessageBoxResult potvrda = MessageBox.Show($"Da li ste sigurni da zelite da obrisete {izabraniTip.Usluga}?", "Brisanje", MessageBoxButton.YesNo);

            if (potvrda == MessageBoxResult.Yes)
            {
                foreach (var t in lista)
                {
                    if (t.Id == izabraniTip.Id)
                    {
                        DodatnaUsluga.Delete(t);
                        view.Refresh();
                        break;
                    }
                }
            }
        }

        private void ObrisiAkciju()
        {
            var izabranaAkcija = (Akcija)dgPrikaz.SelectedItem;
            var lista = Projekat.Instance.Akcije;
            MessageBoxResult potvrda = MessageBox.Show("Da li ste sigurni da zelite da obrisete?", "Brisanje", MessageBoxButton.YesNo);

            if(potvrda == MessageBoxResult.Yes)
            {
                foreach (var a in lista)
                {
                    if(a.Id == izabranaAkcija.Id)
                    {
                        //a.Obrisan = true;
                        //POSLE BAZA NE RADI

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
            var lista = Projekat.Instance.Korisnici;
            MessageBoxResult potvrda = MessageBox.Show("Da li ste sigurni da zelite da obrisete?", "Brisanje", MessageBoxButton.YesNo);

            if (potvrda == MessageBoxResult.Yes)
            {
                foreach (var a in lista)
                {
                    if (a.Id == izabraniKorisnik.Id)
                    {
                        Korisnik.Delete(a);
                        view.Refresh();
                        break;
                    }
                }
            }
        }
        #endregion

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

        private void DugmeSearch(object sender, RoutedEventArgs e)
        {
            switch (trenutnoAktivan)
            {
                case "Salon":
                    break;
                case "Namestaj":
                    view = CollectionViewSource.GetDefaultView(Namestaj.Search(tbSearch.Text, "Id"));
                    view.Filter = NamestajFilter;
                    dgPrikaz.ItemsSource = view;
                    break;
                case "Tip":
                    view = CollectionViewSource.GetDefaultView(TipNamestaja.Search(tbSearch.Text, "Id"));
                    view.Filter = TipFilter;
                    dgPrikaz.ItemsSource = view;
                    break;
                case "Usluge":
                    view = CollectionViewSource.GetDefaultView(DodatnaUsluga.Search(tbSearch.Text, "Id"));
                    view.Filter = UslugeFilter;
                    dgPrikaz.ItemsSource = view;
                    break;
                case "Akcije":
                    dgPrikaz.ItemsSource = Akcija.Search(tbSearch.Text, "Id");
                    break;
                case "Prodaja":
                    dgPrikaz.ItemsSource = ProdajaNamestaja.Search(tbSearch.Text, "Id");
                    break;
                case "Korisnici":
                    view = CollectionViewSource.GetDefaultView(Korisnik.Search(tbSearch.Text, "Id"));
                    view.Filter = KorisniciFilter;
                    dgPrikaz.ItemsSource = view;
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
                    //MessageBoxResult obavestenjeP = MessageBox.Show("Nije moguce obrisati prodaju", "Obavestenje", MessageBoxButton.OK);

                    SelektovanaProdaja = dgPrikaz.SelectedItem as ProdajaNamestaja;

                    var propro = new DetaljiProdajeWindow(SelektovanaProdaja);
                    propro.ShowDialog();

                    break;
                default:
                    break;
            }
        }

        
        //i sve u try catch
        

        private void ZatvoriSalon(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgPrikaz_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if((string)e.Column.Header == "Id" || (string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "PIB"
                || (string)e.Column.Header == "PDV" || (string)e.Column.Header == "IdTipaNamestaja" || (string)e.Column.Header == "IdAkcije")
            {
                e.Cancel = true;
            } 
        }

        private void dgPrikaz_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()+1).ToString();
            //+1 je da krene da broji od 1
        }


        private void Sort(object sender, RoutedEventArgs e)
        {
            string orderby = cbSort.SelectionBoxItem.ToString();
            switch (trenutnoAktivan)
            {
                case "Salon":
                    break;
                case "Namestaj":
                    if (orderby == "Nazivu" && opadajuce.IsChecked==true)
                    {
                        view = CollectionViewSource.GetDefaultView(Namestaj.Search(tbSearch.Text, "Naziv DESC"));
                    }
                    else if (orderby == "Nazivu" && rastuce.IsChecked == true)
                    {
                        view = CollectionViewSource.GetDefaultView(Namestaj.Search(tbSearch.Text, "Naziv"));
                    }
                    else if (orderby == "Ceni" && opadajuce.IsChecked == true)
                    {
                        view = CollectionViewSource.GetDefaultView(Namestaj.Search(tbSearch.Text, "Cena DESC"));
                    }
                    else if (orderby == "Ceni" && rastuce.IsChecked == true)
                    {
                        view = CollectionViewSource.GetDefaultView(Namestaj.Search(tbSearch.Text, "Cena"));
                    }
                    else if (orderby == "Kolicini" && opadajuce.IsChecked == true)
                    {
                        view = CollectionViewSource.GetDefaultView(Namestaj.Search(tbSearch.Text, "Kolicina DESC"));
                    }
                    else if (orderby == "Kolicini" && rastuce.IsChecked == true)
                    {
                        view = CollectionViewSource.GetDefaultView(Namestaj.Search(tbSearch.Text, "Kolicina"));
                    }
                    view.Filter = NamestajFilter;
                    dgPrikaz.ItemsSource = view;
                    break;
                case "Tip":
                    if (orderby == "Nazivu" && opadajuce.IsChecked == true)
                    {
                        view = CollectionViewSource.GetDefaultView(TipNamestaja.Search(tbSearch.Text, "Naziv DESC"));
                    }
                    else if (orderby == "Nazivu" && rastuce.IsChecked == true)
                    {
                        view = CollectionViewSource.GetDefaultView(TipNamestaja.Search(tbSearch.Text, "Naziv"));
                    }
                    view.Filter = TipFilter;
                    dgPrikaz.ItemsSource = view;
                    break;
                case "Usluge":
                    if (orderby == "Nazivu" && opadajuce.IsChecked == true)
                    {
                        view = CollectionViewSource.GetDefaultView(DodatnaUsluga.Search(tbSearch.Text, "Naziv DESC"));
                    }
                    else if (orderby == "Nazivu" && rastuce.IsChecked == true)
                    {
                        view = CollectionViewSource.GetDefaultView(DodatnaUsluga.Search(tbSearch.Text, "Naziv"));
                    }
                    else if (orderby == "Ceni" && rastuce.IsChecked == true)
                    {
                        view = CollectionViewSource.GetDefaultView(DodatnaUsluga.Search(tbSearch.Text, "Cena"));
                    }
                    else if (orderby == "Ceni" && opadajuce.IsChecked == true)
                    {
                        view = CollectionViewSource.GetDefaultView(DodatnaUsluga.Search(tbSearch.Text, "Cena DESC"));
                    }
                    view.Filter = UslugeFilter;
                    dgPrikaz.ItemsSource = view;
                    break;
                case "Akcije":
                    if (orderby == "Nazivu" && rastuce.IsChecked == true)
                    {
                        dgPrikaz.ItemsSource = Akcija.Search(tbSearch.Text, "Naziv");
                    }
                    else if (orderby == "Nazivu" && opadajuce.IsChecked == true)
                    {
                        dgPrikaz.ItemsSource = Akcija.Search(tbSearch.Text, "Naziv DESC");
                    }
                    else if (orderby == "Popustu" && rastuce.IsChecked == true)
                    {
                        dgPrikaz.ItemsSource = Akcija.Search(tbSearch.Text, "Popust");
                    }
                    else if (orderby == "Popustu" && opadajuce.IsChecked == true)
                    {
                        dgPrikaz.ItemsSource = Akcija.Search(tbSearch.Text, "Popust DESC");
                    }
                    else if (orderby == "Pocetku akcije" && rastuce.IsChecked == true)
                    {
                        dgPrikaz.ItemsSource = Akcija.Search(tbSearch.Text, "PocetakAkcije");
                    }
                    else if (orderby == "Pocetku akcije" && opadajuce.IsChecked == true)
                    {
                        dgPrikaz.ItemsSource = Akcija.Search(tbSearch.Text, "PocetakAkcije DESC");
                    }
                    else if (orderby == "Kraju akcije" && rastuce.IsChecked == true)
                    {
                        dgPrikaz.ItemsSource = Akcija.Search(tbSearch.Text, "KrajAkcije");
                    }
                    else if (orderby == "Kraju akcije" && opadajuce.IsChecked == true)
                    {
                        dgPrikaz.ItemsSource = Akcija.Search(tbSearch.Text, "KrajAkcije DESC");
                    }
                    break;
                case "Prodaja":
                    if (orderby == "Datumu prodaje" && rastuce.IsChecked == true)
                    {
                        dgPrikaz.ItemsSource = ProdajaNamestaja.Search(tbSearch.Text, "DatumProdaje");
                    }
                    else if (orderby == "Datumu prodaje" && opadajuce.IsChecked == true)
                    {
                        dgPrikaz.ItemsSource = ProdajaNamestaja.Search(tbSearch.Text, "DatumProdaje DESC");
                    }
                    else if (orderby == "Kupcu" && rastuce.IsChecked == true)
                    {
                        dgPrikaz.ItemsSource = ProdajaNamestaja.Search(tbSearch.Text, "Kupac");
                    }
                    else if (orderby == "Kupcu" && opadajuce.IsChecked == true)
                    {
                        dgPrikaz.ItemsSource = ProdajaNamestaja.Search(tbSearch.Text, "Kupac DESC");
                    }
                    else if (orderby == "Ukupnom iznosu" && rastuce.IsChecked == true)
                    {
                        dgPrikaz.ItemsSource = ProdajaNamestaja.Search(tbSearch.Text, "UkupanIznos");
                    }
                    else if (orderby == "Ukupnom iznosu" && opadajuce.IsChecked == true)
                    {
                        dgPrikaz.ItemsSource = ProdajaNamestaja.Search(tbSearch.Text, "UkupanIznos DESC");
                    }
                    break;
                case "Korisnici":
                    if (orderby == "Imenu" && rastuce.IsChecked == true)
                    {
                        view = CollectionViewSource.GetDefaultView(Korisnik.Search(tbSearch.Text, "Ime"));
                    }
                    else if (orderby == "Imenu" && opadajuce.IsChecked == true)
                    {
                        view = CollectionViewSource.GetDefaultView(Korisnik.Search(tbSearch.Text, "Ime DESC"));
                    }
                    else if (orderby == "Prezimenu" && rastuce.IsChecked == true)
                    {
                        view = CollectionViewSource.GetDefaultView(Korisnik.Search(tbSearch.Text, "Prezime"));
                    }
                    else if (orderby == "Prezimenu" && opadajuce.IsChecked == true)
                    {
                        view = CollectionViewSource.GetDefaultView(Korisnik.Search(tbSearch.Text, "Prezime DESC"));
                    }
                    else if (orderby == "Korisnickom imenu" && rastuce.IsChecked == true)
                    {
                        view = CollectionViewSource.GetDefaultView(Korisnik.Search(tbSearch.Text, "KorisnickoIme"));
                    }
                    else if (orderby == "Korisnickom imenu" && opadajuce.IsChecked == true)
                    {
                        view = CollectionViewSource.GetDefaultView(Korisnik.Search(tbSearch.Text, "KorisnickoIme DESC"));
                    }
                    view.Filter = KorisniciFilter;
                    dgPrikaz.ItemsSource = view;
                    break;
                default:
                    break;
            }
        }
    }
}
