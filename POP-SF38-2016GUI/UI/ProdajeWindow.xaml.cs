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
using System.Windows.Shapes;
using static POP_SF38_2016GUI.UI.NamestajWindow;

namespace POP_SF38_2016GUI.UI
{
    /// <summary>
    /// Interaction logic for ProdajeWindow.xaml
    /// </summary>
    public partial class ProdajeWindow : Window
    {
        ICollectionView viewStavka;
        private ProdajaNamestaja prodaja;
        private StavkaProdaje SelektovanaStavka;
        private UslugaProdaje SelektovanaUsluga;
        private Operacija operacija;
        public double cenaBezPDV;
        public ObservableCollection<StavkaProdaje> listaStavki;
        public ObservableCollection<UslugaProdaje> listaUsluga;
        public ObservableCollection<StavkaProdaje> listaStavkiZaBrisanje;
        public ObservableCollection<UslugaProdaje> listaUslugaZaBrisanje;

        public ProdajeWindow(ProdajaNamestaja prodaja, Operacija operacija)
        {
            InitializeComponent();
            
            this.prodaja = prodaja;
            this.operacija = operacija;

            listaStavki = new ObservableCollection<StavkaProdaje>();
            listaUsluga = new ObservableCollection<UslugaProdaje>();
            listaStavkiZaBrisanje = new ObservableCollection<StavkaProdaje>();
            listaUslugaZaBrisanje = new ObservableCollection<UslugaProdaje>();

            SelektovanaUsluga = new UslugaProdaje();

            tbKupac.DataContext = prodaja;
            dgProdajaNamestaj.DataContext = prodaja;
            dgProdajaUsluga.DataContext = prodaja;


            foreach (var i in Projekat.Instance.StavkeProdaje)
            {
                if (i.IdProdaje == prodaja.Id)
                {
                    listaStavki.Add(i);
                }
            }
            //dgProdajaNamestaj.ItemsSource = listaStavki;

            viewStavka = CollectionViewSource.GetDefaultView(listaStavki);
            viewStavka.Filter = StavkeFilter;
            dgProdajaNamestaj.ItemsSource = viewStavka;


            foreach (var up in Projekat.Instance.UslugeProdaje)
            {
                if(up.IdProdaje == prodaja.Id)
                {
                    listaUsluga.Add(up);
                }
            }
            dgProdajaUsluga.ItemsSource = listaUsluga;

            cenaBezPDV = 0;
        }


        private bool StavkeFilter(object obj)
        {
            StavkaProdaje sp = obj as StavkaProdaje;
            return (sp.Id > 1);
        }


        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaProdaja = Projekat.Instance.ProdajeNamestaja;
            //var listaStavki = Projekat.Instance.StavkeProdaje;
            //var listaUslugaProdaja = Projekat.Instance.UslugeProdaje;
            var listaNaAkciji = Projekat.Instance.NaAkcijama;

            if (ForceValidation() == true)
            {
                return;
            }

            switch (operacija)
            {
                case Operacija.Dodavanje:
                    foreach (var st in listaStavkiZaBrisanje)
                    {
                        StavkaProdaje.Delete(st);
                        st.Namestaj.KolicinaUMagacinu += st.Kolicina;
                        Namestaj.Update(st.Namestaj);
                    }
                    viewStavka.Refresh();

                    foreach (var us in listaUslugaZaBrisanje)
                    {
                        UslugaProdaje.Delete(us);
                    }

                    Random random = new Random();
                    int randomNumber = random.Next(0, 100);
                    prodaja.BrojRacuna = int.Parse(prodaja.Id.ToString() + randomNumber.ToString() + DateTime.Now.Minute.ToString());

                    
                    foreach (var i in listaStavki)
                    {
                        if(i.IdProdaje == prodaja.Id)
                        {
                            cenaBezPDV += i.Namestaj.Cena * i.Kolicina;
                            
                            foreach (var na in listaNaAkciji)
                            {
                                if (na.IdNamestaja == i.IdNamestaja && na.Akcija.PocetakAkcije < DateTime.Today && na.Akcija.KrajAkcije > DateTime.Today)
                                {
                                    cenaBezPDV = cenaBezPDV - ((cenaBezPDV * na.Akcija.Popust) / 100); //* na.Akcija.Popust); //- cenaBezPDV*(na.Akcija.Popust / 100);
                                }
                            }
                        }
                    }

                    foreach (var item in listaUsluga)
                    {
                        if (item.IdProdaje == prodaja.Id)
                        {
                            cenaBezPDV += item.DodatnaUsluga.Cena;
                        }
                    }
                    

                    //NEMAM SOLUTION!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    
                    prodaja.UkupanIznos = cenaBezPDV + cenaBezPDV * prodaja.PDV;
                    
                    ProdajaNamestaja.Update(prodaja);
                    break;
                case Operacija.Izmena:
                    foreach (var st in listaStavkiZaBrisanje)
                    {
                        StavkaProdaje.Delete(st);
                        //st.Namestaj.KolicinaUMagacinu += st.Kolicina;
                        //Namestaj.Update(st.Namestaj);
                    }
                    viewStavka.Refresh();

                    foreach (var us in listaUslugaZaBrisanje)
                    {
                        UslugaProdaje.Delete(us);
                    }

                    foreach (var n in listaProdaja)
                    {
                        if(n.Id == prodaja.Id)
                        {
                            n.DatumProdaje = prodaja.DatumProdaje;
                            n.BrojRacuna = prodaja.BrojRacuna;
                            n.Kupac = prodaja.Kupac;

                            foreach (var i in listaStavki)
                            {
                                if (i.IdProdaje == prodaja.Id)
                                {
                                    //n.UkupanIznos += i.Namestaj.Cena * i.Kolicina;
                                    cenaBezPDV += i.Namestaj.Cena * i.Kolicina;
                                    foreach (var na in listaNaAkciji)
                                    {
                                        if (na.IdNamestaja == i.IdNamestaja && na.Akcija.PocetakAkcije < DateTime.Today && na.Akcija.KrajAkcije > DateTime.Today)
                                        {
                                            cenaBezPDV = cenaBezPDV - ((cenaBezPDV * na.Akcija.Popust) / 100); //* na.Akcija.Popust); //- cenaBezPDV*(na.Akcija.Popust / 100);
                                        }
                                    }
                                }
                            }

                            foreach (var item in listaUsluga)
                            {
                                if (UslugaProdaje.GetById(item.Id).IdProdaje == prodaja.Id)
                                {
                                    //lbUsluge.SelectedIndex = item.IdUsluge;
                                    cenaBezPDV += item.DodatnaUsluga.Cena;
                                }
                            }

                            n.UkupanIznos = cenaBezPDV + cenaBezPDV * prodaja.PDV;

                            ProdajaNamestaja.Update(n);
                        }
                    }
                    break;
            }
            Close();
        }
        

        private void ZatvoriProdajeWindow(object sender, RoutedEventArgs e)
        {
            var listaStavki = Projekat.Instance.StavkeProdaje;
            switch (operacija)
            {
                case Operacija.Dodavanje:
                    
                    foreach (var i in listaStavki)
                    {
                        if (i.IdProdaje == prodaja.Id)
                        {
                            StavkaProdaje.Delete(i);
                        }
                    }
                    foreach (var u in Projekat.Instance.UslugeProdaje)
                    {
                        if (u.IdProdaje == prodaja.Id)
                        {
                            UslugaProdaje.Delete(u);
                        }
                    }
                    ProdajaNamestaja.Delete(prodaja);

                    this.Close();
                    break;
                case Operacija.Izmena:
                    this.Close();
                    break;
                default:
                    break;
            }
            
        }

        private void SviNamestajiZaProdaju(object sender, RoutedEventArgs e)
        {
            SviNamestajiWindow prozor = new SviNamestajiWindow(SviNamestajiWindow.Radnja.Sacuvaj);
            prozor.ShowDialog();
            
            if (prozor.SelektovanaStavka != null || prozor.SelektovanaStavka.Id != 0)
            {
                var stavkaa = prozor.SelektovanaStavka;
                stavkaa.IdNamestaja = stavkaa.IdNamestaja;
                stavkaa.IdProdaje = prodaja.Id;
                stavkaa.Kolicina = stavkaa.Kolicina;
                StavkaProdaje.Update(stavkaa);

                prozor.SelektovaniNamestaj.KolicinaUMagacinu = prozor.SelektovaniNamestaj.KolicinaUMagacinu - stavkaa.Kolicina;
                Namestaj.Update(prozor.SelektovaniNamestaj);

                /*foreach (var i in Projekat.Instance.StavkeProdaje)
                {
                    if (i.IdProdaje == prodaja.Id)
                    {
                        listaNamestaja.Add(i.Namestaj);

                    }
                    //dgProdajaNamestaj.ItemsSource = i;
                }*/
                //listaNamestaja.Add(stavkaa);
                listaStavki.Add(stavkaa);
            }
            //var stavkaa = prozor.SelektovanaStavka;
            
            //dgProdajaNamestaj.ItemsSource = listaStavki;

        }

        private void SveUslugeZaProdaju(object sender, RoutedEventArgs e)
        {
            SveUslugeWindow uslugeProzor = new SveUslugeWindow();
            uslugeProzor.ShowDialog();
            var uslugaa = uslugeProzor.SelektovanaUslugaZaProdaju;
            uslugaa.IdUsluge = uslugaa.IdUsluge;
            uslugaa.IdProdaje = prodaja.Id;
            UslugaProdaje.Update(uslugaa);
            listaUsluga.Add(uslugaa);
        }

        private void UkloniNamestaj(object sender, RoutedEventArgs e)
        {
            SelektovanaStavka = dgProdajaNamestaj.SelectedItem as StavkaProdaje;
            //listaStavki.Remove(SelektovaniNamestaj);

            listaStavkiZaBrisanje.Add(SelektovanaStavka);
            //StavkaProdaje.Delete(SelektovanaStavka);
            listaStavki.Remove(SelektovanaStavka);
        }

        private void UkloniUslugu(object sender, RoutedEventArgs e)
        {
            SelektovanaUsluga = dgProdajaUsluga.SelectedItem as UslugaProdaje;
            listaUslugaZaBrisanje.Add(SelektovanaUsluga);
            UslugaProdaje.Delete(SelektovanaUsluga);
            listaUsluga.Remove(SelektovanaUsluga);
        }


        private bool ForceValidation()
        {
            BindingExpression be1 = tbKupac.GetBindingExpression(TextBox.TextProperty);
            be1.UpdateSource();

            if (Validation.GetHasError(tbKupac) == true)
            {
                return true;
            }
            return false;
        }
    }
}
