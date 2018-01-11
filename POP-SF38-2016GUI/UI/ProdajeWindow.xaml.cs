﻿using POP_SF382016.Model;
using POP_SF382016.utill;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ProdajaNamestaja prodaja;
        private UslugaProdaje uslugaProdaje;
        private StavkaProdaje SelektovaniNamestaj;
        private UslugaProdaje SelektovanaUsluga;
        private ObservableCollection<UslugaProdaje> SelektovanaUslugaProdaje;
        private Operacija operacija;
        public double cenaBezPDV;
        public ObservableCollection<Namestaj> listaNamestaja;
        public ObservableCollection<StavkaProdaje> listaStavki;
        public ObservableCollection<UslugaProdaje> listaUsluga;

        public ProdajeWindow(ProdajaNamestaja prodaja, Operacija operacija)
        {
            InitializeComponent();
            
            this.prodaja = prodaja;
            this.operacija = operacija;
            this.listaNamestaja = new ObservableCollection<Namestaj>();
            this.listaStavki = new ObservableCollection<StavkaProdaje>();
            this.listaUsluga = new ObservableCollection<UslugaProdaje>();

            uslugaProdaje = new UslugaProdaje();
            SelektovanaUsluga = new UslugaProdaje();

            
            tbUkupanIznos.DataContext = prodaja;
            tbKupac.DataContext = prodaja;
            dgProdajaNamestaj.DataContext = prodaja;
            dgProdajaUsluga.DataContext = prodaja;

            //var listaStavki = Projekat.Instance.StavkeProdaje;
            

            foreach (var i in Projekat.Instance.StavkeProdaje)
            {
                if (i.IdProdaje == prodaja.Id)
                {
                    listaStavki.Add(i);
                }
            }
            dgProdajaNamestaj.ItemsSource = listaStavki;

            foreach (var up in Projekat.Instance.UslugeProdaje)
            {
                if(up.IdProdaje == prodaja.Id)
                {
                    listaUsluga.Add(up);
                }
            }
            dgProdajaUsluga.ItemsSource = listaUsluga;

            //lbUsluge.ItemsSource = Projekat.Instance.DodatneUsluge;

            cenaBezPDV = 0;
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaProdaja = Projekat.Instance.ProdajeNamestaja;
            var listaStavki = Projekat.Instance.StavkeProdaje;
            var listaUslugaProdaja = Projekat.Instance.UslugeProdaje;
            var listaAkcija = Projekat.Instance.Akcije;
            var listaNaAkciji = Projekat.Instance.NaAkcijama;

            //SelektovanaUslugaProdaje.Add((UslugaProdaje)lbUsluge.SelectedItems);// = (UslugaProdaje)lbUsluge.SelectedItems;

            //SelektovanaUsluga.Add((DodatnaUsluga)lbUsluge.SelectedItem);
            
            switch (operacija)
            {
                case Operacija.Dodavanje:

                    Random random = new Random();
                    int randomNumber = random.Next(0, 100);
                    prodaja.BrojRacuna = int.Parse(prodaja.Id.ToString() + randomNumber.ToString() + DateTime.Now.Minute.ToString());

                    /*foreach (var a in SelektovanaUsluga)
                    {
                        if (a != null)
                        {
                            uslugaProdaje.IdProdaje = prodaja.Id;
                            uslugaProdaje.IdUsluge = a.Id;
                            UslugaProdaje.Create(uslugaProdaje);
                        }
                        
                    }*/
                    
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

                    foreach (var item in listaUslugaProdaja)
                    {
                        if (item.IdProdaje == prodaja.Id)
                        {
                            cenaBezPDV += item.DodatnaUsluga.Cena;
                        }
                    }
                    
                    //cenaBezPDV += SelektovanaUsluga.Cena;


                    //NEMAM SOLUTION!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    
                    prodaja.UkupanIznos = cenaBezPDV + cenaBezPDV * prodaja.PDV;
                    
                    ProdajaNamestaja.Update(prodaja);
                    break;
                case Operacija.Izmena:
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
                                    n.UkupanIznos += i.Namestaj.Cena * i.Kolicina;
                                }
                            }

                            //lbUsluge.SelectedIndex = prodaja.

                            //n.UkupanIznos += SelektovanaUsluga.Cena;

                            foreach (var item in listaUslugaProdaja)
                            {
                                if (UslugaProdaje.GetById(item.Id).IdProdaje == prodaja.Id)
                                {
                                    //lbUsluge.SelectedIndex = item.IdUsluge;
                                    cenaBezPDV += item.DodatnaUsluga.Cena;
                                }
                            }
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
            SelektovaniNamestaj = dgProdajaNamestaj.SelectedItem as StavkaProdaje;
            //listaStavki.Remove(SelektovaniNamestaj);
            StavkaProdaje.Delete(SelektovaniNamestaj);
            listaStavki.Remove(SelektovaniNamestaj);
        }

        private void UkloniUslugu(object sender, RoutedEventArgs e)
        {
            SelektovanaUsluga = dgProdajaUsluga.SelectedItem as UslugaProdaje;
            UslugaProdaje.Delete(SelektovanaUsluga);
            listaUsluga.Remove(SelektovanaUsluga);
        }
    }
}
