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
        private StavkaProdaje stavke;
        private DodatnaUsluga SelektovanaUsluga;
        private ObservableCollection<UslugaProdaje> SelektovanaUslugaProdaje;
        private ProdajaNamestaja prodajaNova;
        private Operacija operacija;
        private double cenaBezPDV;

        public ProdajeWindow(ProdajaNamestaja prodaja, Operacija operacija)
        {
            InitializeComponent();
            

            this.prodaja = prodaja;
            //this.usluga = usluga;
            this.operacija = operacija;

            //cbKorisnik.ItemsSource = Projekat.Instance.Korisnik;

            dtProdaje.DataContext = prodaja;
            tbBrRacuna.DataContext = prodaja;
            //tbKupac = prodaja;
            //cbKorisnik.DataContext = prodaja;
            tbUkupanIznos.DataContext = prodaja;
            tbKupac.DataContext = prodaja;
            lbUsluge.DataContext = prodaja;

            var listaStavki = Projekat.Instance.StavkeProdaje;



            dgProdajaNamestaj.ItemsSource = Projekat.Instance.StavkeProdaje;

            //dgProdajaNamestaj.ItemsSource = prodaja.IdStavki;
            //OVO POSLE BAZA NE RADI PREPRAVITI


            //dgProdajaUsluge.ItemsSource = Projekat.Instance.DodatnaUsluga;
            lbUsluge.ItemsSource = Projekat.Instance.DodatneUsluge;
            //cbUsluge.Content = Projekat.Instance.DodatneUsluge;

            cenaBezPDV = 0;
            /*prodaja.Id = Projekat.Instance.ProdajeNamestaja.Count + 1;
            prodaja.BrojRacuna = 1;
            prodaja.Kupac = "";
            prodaja.UkupanIznos = 0;
            ProdajaNamestaja.Create(prodaja);*/

            /*var listaNaAkciji = Projekat.Instance.NaAkcijama;
            foreach (var i in listaStavki)
            {
                //if(i.IdProdaje == prodajaNova.Id)
                if (i.IdProdaje == prodaja.Id)
                {
                    cenaBezPDV += i.Namestaj.Cena * i.Kolicina;
                    //prodaja.UkupanIznos += i.Namestaj.Cena * i.Kolicina;



                    foreach (var na in listaNaAkciji)
                    {
                        if (na.IdNamestaja == i.IdNamestaja && na.Akcija.PocetakAkcije < DateTime.Today && na.Akcija.KrajAkcije > DateTime.Today)
                        {
                            cenaBezPDV = cenaBezPDV - ((cenaBezPDV * na.Akcija.Popust) / 100); //* na.Akcija.Popust); //- cenaBezPDV*(na.Akcija.Popust / 100);
                        }
                    }
                }
            }

            prodaja.UkupanIznos = cenaBezPDV + cenaBezPDV * prodaja.PDV;*/


        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaProdaja = Projekat.Instance.ProdajeNamestaja;
            var listaStavki = Projekat.Instance.StavkeProdaje;
            var listaAkcija = Projekat.Instance.Akcije;
            var listaNaAkciji = Projekat.Instance.NaAkcijama;
            //var izabraniKorisnik = (Korisnik)cbKorisnik.SelectedItem;

            SelektovanaUslugaProdaje.Add((UslugaProdaje)lbUsluge.SelectedItems);// = (UslugaProdaje)lbUsluge.SelectedItems;

            


            switch (operacija)
            {
                case Operacija.Dodavanje:
                    //var prozorZaProdaju = new MainWindow((TipKorisnika)Enum.Parse(typeof(TipKorisnika), "Administrator"));
                    
                    //prodaja = prozorZaProdaju.novaProdaja;
                    //prozorZaProdaju.Close();

                    //prodaja.Id = prodaja.Id;


                    //prodaja.Id = listaProdaja.Count + 1;
                    


                    //NapraviProdaju();

                    //prodajaNova.BrojRacuna = int.Parse(tbBrRacuna.Text);
                    //prodajaNova.Kupac = tbKupac.Text;

                    //prodaja.BrojRacuna = int.Parse(tbBrRacuna.Text);
                    //prodaja.Kupac = tbKupac.Text;




                    //prodaja.IdStavki = prodaja.IdStavki;
                    //prodaja.IdUsluga.Add(SelektovanaUsluga.Id);


                    foreach (var i in listaStavki)
                    {
                        //if(i.IdProdaje == prodajaNova.Id)
                        if(i.IdProdaje == prodaja.Id)
                        {
                            cenaBezPDV += i.Namestaj.Cena * i.Kolicina;
                            //prodaja.UkupanIznos += i.Namestaj.Cena * i.Kolicina;

                            

                            foreach (var na in listaNaAkciji)
                            {
                                if (na.IdNamestaja == i.IdNamestaja && na.Akcija.PocetakAkcije < DateTime.Today && na.Akcija.KrajAkcije > DateTime.Today)
                                {
                                    cenaBezPDV = cenaBezPDV - ((cenaBezPDV * na.Akcija.Popust) / 100); //* na.Akcija.Popust); //- cenaBezPDV*(na.Akcija.Popust / 100);
                                }
                            }
                        }
                    }

                    foreach (var item in SelektovanaUslugaProdaje)
                    {
                        if (UslugaProdaje.GetById(item.Id).IdProdaje == prodaja.Id)
                        {
                            cenaBezPDV += item.DodatnaUsluga.Cena;
                        }
                    }



                    //cenaBezPDV += SelektovanaUsluga.Cena;


                    //NEMAM SOLUTION!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


                    //prodajaNova.UkupanIznos = cenaBezPDV + cenaBezPDV * prodajaNova.PDV;



                    prodaja.UkupanIznos = cenaBezPDV + cenaBezPDV * prodaja.PDV;
                    /*foreach (var i in listaProdaja)
                    {
                        if(i.Id == prodaja.Id)
                        {
                            ProdajaNamestaja.Update(prodaja);
                        }
                    }*/
                    ProdajaNamestaja.Update(prodaja);



                    //ProdajaNamestaja.Create(prodaja);
                    break;
                case Operacija.Izmena:
                    foreach (var n in listaProdaja)
                    {
                        if(n.Id == prodaja.Id)
                        {
                            n.DatumProdaje = prodaja.DatumProdaje;
                            n.BrojRacuna = prodaja.BrojRacuna;
                            n.Kupac = prodaja.Kupac;
                            //n.IdUsluga = prodaja.IdUsluga;
                            //n.Korisnik = prodaja.Korisnik;

                            foreach (var i in listaStavki)
                            {
                                if (i.IdProdaje == prodaja.Id)
                                {
                                    n.UkupanIznos += i.Namestaj.Cena * i.Kolicina;
                                }
                            }

                            //n.UkupanIznos += SelektovanaUsluga.Cena;



                            ProdajaNamestaja.Update(n);
                        }
                    }
                    break;
            }
            Close();
        }

        /*private void NapraviProdaju()
        {
            var novaProdaja = new ProdajaNamestaja()
            {
                DatumProdaje = DateTime.Now,
                Kupac = "proba za bazu",
                BrojRacuna = 123
            };
            ProdajaNamestaja.Create(novaProdaja);
            prodajaNova = novaProdaja;
        }*/

        private void ZatvoriProdajeWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SviNamestajiZaProdaju(object sender, RoutedEventArgs e)
        {
            /*prodaja.Id = Projekat.Instance.ProdajeNamestaja.Count + 1;
            prodaja.BrojRacuna = 1;
            prodaja.Kupac = "a";
            prodaja.UkupanIznos = 0;
            ProdajaNamestaja.Create(prodaja);*/

            SviNamestajiWindow prozor = new SviNamestajiWindow(SviNamestajiWindow.Radnja.Sacuvaj);
            prozor.ShowDialog();
            //if(prozor.ShowDialog() == true)
            //{
                var stavkaa = prozor.SelektovanaStavka;
                //stavkaa.Id = Projekat.Instance.StavkeProdaje.Count + 1;
            stavkaa.IdNamestaja = stavkaa.IdNamestaja;
            stavkaa.IdProdaje = prodaja.Id;
            stavkaa.Kolicina = stavkaa.Kolicina;
            StavkaProdaje.Update(stavkaa);

            //dgProdajaNamestaj.ItemsSource = (Namestaj)prozor.SelektovaniNamestaj;

                //StavkaProdaje.Create(stavkaa);
            //}
            /*prozor.SelektovanaStavka.Id = Projekat.Instance.StavkeProdaje.Count + 1;
            prozor.SelektovanaStavka.IdNamestaja = 1;
            prozor.SelektovanaStavka.IdProdaje = prodaja.Id;
            prozor.SelektovanaStavka.Kolicina = 1;
            StavkaProdaje.Create(prozor.SelektovanaStavka);*/
            //if(prozor.ShowDialog() == true)
            //{
                //prodaja.IdStavki.Add(prozor.SelektovanaStavka.Id);
            //}
        }
    }
}
