﻿using POP_SF38_2016GUI.UI;
using POP_SF382016.Model;
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
        public MainWindow()
        {
            InitializeComponent();

            lbPrikaz.Items.Clear();
            /*
            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if (!namestaj.Obrisan)
                {
                    lbPrikaz.Items.Add(namestaj);
                }
            }
            lbPrikaz.SelectedIndex = 0;
            */
            //Dugmici();

            /*
            if (Namestaj)
            {
                Console.WriteLine("radiiii");
            }
            */
            //OsveziPrikaz();
            //prikaz();
        }


        string trenutnoAktivan = "";


        private void OsveziPrikaz(object sender, RoutedEventArgs e)
        {
            trenutnoAktivan = "Namestaj";
            //Prikaz();

            lbPrikaz.Items.Clear();

            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if (!namestaj.Obrisan)
                {
                    lbPrikaz.Items.Add(namestaj);
                }
            }
            lbPrikaz.SelectedIndex = 0;
            
            //bool namestajWasClicked = true;
            /*
            Button btn = Dodaj;
            btn.Name = "Dodaj";
            btn.Click += DodajNamestaj;

            Button btnI = Izmeni;
            btnI.Name = "Izmeni";
            btnI.Click += IzmeniNamestaj;

            Button btnD = Obrisi;
            btnD.Name = "Obrisi";
            btnD.Click += ObrisiNamestaj;*/
        }

        private void TipPrikaz(object sender, RoutedEventArgs e)
        {
            trenutnoAktivan = "Tip";
            //Prikaz();

            lbPrikaz.Items.Clear();

            foreach (var tip in Projekat.Instance.Tip)
            {
                if (!tip.Obrisan)
                {
                    lbPrikaz.Items.Add(tip);
                }
            }
            lbPrikaz.SelectedIndex = 0;
            /*
            //Dodaj.Visibility = Visibility.Hidden;
            Button btn = Dodaj;
            btn.Content = "novooo";
            btn.Name = "Dodaj";
            btn.Click += DodajTipNamestaja;

            Button btnI = Izmeni;
            btnI.Name = "Izmeni";
            btnI.Click += IzmeniTipNamestaja;

            Button btnD = Obrisi;
            btnD.Name = "Obrisi";
            btnD.Click += ObrisiTipNamestaja;*/
        }

        private void UslugePrikaz(object sender, RoutedEventArgs e)
        {
            trenutnoAktivan = "Usluge";

            lbPrikaz.Items.Clear();
            foreach (var usluga in Projekat.Instance.DodatnaUsluga)
            {
                if (!usluga.Obrisan)
                {
                    lbPrikaz.Items.Add(usluga);
                }
            }
            lbPrikaz.SelectedIndex = 0;
            /*
            Button btn = Dodaj;
            btn.Name = "Dodaj";
            btn.Click += DodajUslugu;

            Button btnI = Izmeni;
            btnI.Content = "aaaaa";
            btnI.Name = "Izmeni";
            btnI.Click += IzmeniUslugu;

            Button btnD = Obrisi;
            btnD.Name = "Obrisi";
            btnD.Click += ObrisiUslugu;*/
        }

        private void AkcijePrikaz(object sender, RoutedEventArgs e)
        {
            trenutnoAktivan = "Akcije";

            lbPrikaz.Items.Clear();
            foreach (var usluga in Projekat.Instance.Akcija)
            {
                if (!usluga.Obrisan)
                {
                    lbPrikaz.Items.Add(usluga);
                }
            }
            lbPrikaz.SelectedIndex = 0;
            /*
            Button btn = Dodaj;
            btn.Name = "Dodaj";
            btn.Click += DodajAkciju;*/
        }
        


        private void DodajNamestaj()
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = ""
            };
            var namestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.Dodavanje);
            namestajProzor.ShowDialog();
            //OsveziPrikaz();
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
                Popust = 0
            };
            var prozor = new AkcijeWindow(novaAkcija, NamestajWindow.Operacija.Dodavanje);
            prozor.ShowDialog();
        }



        private void IzmeniNamestaj()
        {
            var izabraniNamestaj = (Namestaj) lbPrikaz.SelectedItem;

            var namestajProzor = new NamestajWindow(izabraniNamestaj, NamestajWindow.Operacija.Izmena);
            namestajProzor.Show();
            //ili moze ovde da ne ide show nego showdialog, samo sto onda mora posle svake
        }

        private void IzmeniTipNamestaja()
        {
            var izabraniTip = (TipNamestaja)lbPrikaz.SelectedItem;

            var prozor = new TipNamestajaWindow(izabraniTip, TipNamestajaWindow.Operacija.Izmena);
            prozor.ShowDialog();
        }

        private void IzmeniUslugu()
        {
            var izabranaUsluga = (DodatnaUsluga)lbPrikaz.SelectedItem;

            var prozor = new UslugeWindow(izabranaUsluga, NamestajWindow.Operacija.Izmena);
            prozor.ShowDialog();
        }

        private void IzmeniAkciju()
        {
            var izabranaAkcija = (Akcija)lbPrikaz.SelectedItem;

            var prozor = new AkcijeWindow(izabranaAkcija, NamestajWindow.Operacija.Izmena);
            prozor.ShowDialog();
        }
        


        private void ObrisiNamestaj()
        {
            var izabraniNamestaj = (Namestaj)lbPrikaz.SelectedItem;
            var lista = Projekat.Instance.Namestaj;
            MessageBoxResult potvrda = MessageBox.Show("Da li ste sigurni da zelite da obrisete?", "Brisanje", MessageBoxButton.YesNo);

            if(potvrda == MessageBoxResult.Yes)
            {
                foreach (var n in lista)
                {
                    if (n.Id == izabraniNamestaj.Id)
                    {
                        n.Obrisan = true;
                    }
                }
            }
            Projekat.Instance.Namestaj = lista;
        }

        private void ObrisiTipNamestaja()
        {
            var izabraniTip = (TipNamestaja)lbPrikaz.SelectedItem;
            var lista = Projekat.Instance.Tip;
            MessageBoxResult potvrda = MessageBox.Show("Da li ste sigurni da zelite da obrisete?", "Brisanje", MessageBoxButton.YesNo);

            if (potvrda == MessageBoxResult.Yes)
            {
                foreach (var t in lista)
                {
                    if(t.Id == izabraniTip.Id)
                    {
                        t.Obrisan = true;
                    }
                }
            }
            Projekat.Instance.Tip = lista;
        }

        private void ObrisiUslugu()
        {
            var izabraniTip = (DodatnaUsluga)lbPrikaz.SelectedItem;
            var lista = Projekat.Instance.DodatnaUsluga;
            MessageBoxResult potvrda = MessageBox.Show("Da li ste sigurni da zelite da obrisete?", "Brisanje", MessageBoxButton.YesNo);

            if (potvrda == MessageBoxResult.Yes)
            {
                foreach (var t in lista)
                {
                    if (t.Id == izabraniTip.Id)
                    {
                        t.Obrisan = true;
                    }
                }
            }
            Projekat.Instance.DodatnaUsluga = lista;
        }

        private void ObrisiAkciju()
        {
            var izabranaAkcija = (Akcija)lbPrikaz.SelectedItem;
            var lista = Projekat.Instance.Akcija;
            MessageBoxResult potvrda = MessageBox.Show("Da li ste sigurni da zelite da obrisete?", "Brisanje", MessageBoxButton.YesNo);

            if(potvrda == MessageBoxResult.Yes)
            {
                foreach (var a in lista)
                {
                    if(a.Id == izabranaAkcija.Id)
                    {
                        a.Obrisan = true;
                    }
                }
            }
            Projekat.Instance.Akcija = lista;
        }


        

        private void DugmeDodaj(object sender, RoutedEventArgs e)
        {
            switch (trenutnoAktivan)
            {
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
                default:
                    break;
            }
        }

        private void DugmeIzmeni(object sender, RoutedEventArgs e)
        {
            switch (trenutnoAktivan)
            {
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





        /*
        private void Prikaz()
        {
            switch (trenutnoAktivan)
            {
                case "Namestaj":
                    lbPrikaz.Items.Clear();
                    foreach (var namestaj in Projekat.Instance.Namestaj)
                    {
                        if (!namestaj.Obrisan)
                        {
                            lbPrikaz.Items.Add(namestaj);
                        }
                    }
                    lbPrikaz.SelectedIndex = 0;


                    Button btn = Dodaj;
                    btn.Name = "Dodaj";
                    btn.Click += DodajNamestaj;

                    Button btnI = Izmeni;
                    btnI.Name = "Izmeni";
                    btnI.Click += IzmeniNamestaj;
                    break;
                case "Tip":
                    lbPrikaz.Items.Clear();

                    foreach (var tip in Projekat.Instance.Tip)
                    {
                        if (!tip.Obrisan)
                        {
                            lbPrikaz.Items.Add(tip);
                        }
                    }
                    lbPrikaz.SelectedIndex = 0;


                    Button btnTip = Dodaj;
                    btnTip.Content = "novooo";
                    btnTip.Name = "Dodaj";
                    btnTip.Click += DodajTipNamestaja;

                    Button btnIzmeniTip = Izmeni;
                    btnIzmeniTip.Name = "Izmeni";
                    btnIzmeniTip.Click += IzmeniTipNamestaja;
                    break;
                default:
                    break;
            }
        }
        */

        private void ZatvoriSalon(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void Window_Activated (object sender, EventArgs e)
        {
            //OsveziPrikaz();
        }

        private void TipNamestajaPrikaz(object sender, RoutedEventArgs e)
        {
            string tip = "TipPrikaz";
            //MainWindow(tip);
        }

        
    }
}
