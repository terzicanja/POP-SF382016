using POP_SF382016.Model;
using POP_SF382016.utill;
using System;
using System.Collections.Generic;
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

namespace POP_SF38_2016GUI.UI
{
    /// <summary>
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        public enum Operacija
        {
            Dodavanje,
            Izmena
        };

        ICollectionView view;

        private Namestaj namestaj;
        private Operacija operacija;

        public NamestajWindow(Namestaj namestaj, Operacija operacija)
        {
            InitializeComponent();

            this.namestaj = namestaj;
            this.operacija = operacija;

            var listaTipova = Projekat.Instance.TipoviNamestaja;

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.TipoviNamestaja);
            view.Filter = TipFilter;

            tbNaziv.DataContext = namestaj;
            tbSifra.DataContext = namestaj;
            tbCena.DataContext = namestaj;
            tbKolicina.DataContext = namestaj;
            cbTipNamestaja.DataContext = namestaj;
            cbTipNamestaja.ItemsSource = Projekat.Instance.TipoviNamestaja;
            /*for (int i=0; i<cbTipNamestaja.Items.Count; i++)
            {
                //if((ComboBoxItem)(cbTipNamestaja.Items[i]))
            }


            foreach (var t in listaTipova)
            {
                if(t.Obrisan == true)
                {
                    cbTipNamestaja.ItemsSource = Projekat.Instance.TipoviNamestaja;
                }
            }*/
            //cbTipNamestaja.ItemsSource = Projekat.Instance.TipoviNamestaja;
            cbAkcija.DataContext = namestaj;
            cbAkcija.ItemsSource = Projekat.Instance.Akcija;
        }

        private bool TipFilter(object obj)
        {
            return !((TipNamestaja)obj).Obrisan;
        }


        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaNamestaja = Projekat.Instance.Namestaji;
            var listaAkcija = Projekat.Instance.Akcija;
            var izabraniTipNamestaja = (TipNamestaja)cbTipNamestaja.SelectedItem;
            var izabranaAkcija = (Akcija)cbAkcija.SelectedItem;

            switch (operacija)
            {
                case Operacija.Dodavanje:
                    //namestaj.Id = listaNamestaja.Count + 1;
                    namestaj.Naziv = tbNaziv.Text;
                    namestaj.Sifra = tbSifra.Text;
                    namestaj.Cena = Double.Parse(tbCena.Text);
                    namestaj.KolicinaUMagacinu = int.Parse(tbKolicina.Text);
                    namestaj.IdTipaNamestaja = izabraniTipNamestaja.Id;
                    //namestaj.IdAkcije = izabranaAkcija.Id;

                    if(izabranaAkcija != null)
                    {
                        foreach (var ak in listaAkcija)
                        {
                            if(ak.Id == izabranaAkcija.Id)
                            {
                                ak.IdNamestaja.Add(namestaj.Id);
                            }
                        }
                    }

                    /*
                    foreach (var ak in listaAkcija)
                    {
                        if (izabranaAkcija != null)
                        {
                            ak.IdNamestaja.Add(namestaj.Id);
                        }
                    }*/

                    /*foreach (var ak in listaAkcija)
                    {
                        if (ak.Id == izabranaAkcija.Id)
                        {
                            ak.IdNamestaja.Add(namestaj.Id);
                        }
                    }*/

                    Namestaj.Create(namestaj);
                    //listaNamestaja.Add(namestaj);
                    break;
                case Operacija.Izmena:
                    foreach (var n in listaNamestaja)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.Naziv = namestaj.Naziv;
                            n.TipNamestaja = namestaj.TipNamestaja; //i ovako za sve
                            n.Sifra = namestaj.Sifra;
                            n.Cena = namestaj.Cena;
                            n.KolicinaUMagacinu = namestaj.KolicinaUMagacinu;
                            //n.Akcija = namestaj.Akcija;

                            if (izabranaAkcija != null)
                            {
                                foreach (var ak in listaAkcija)
                                {
                                    if (ak.Id == izabranaAkcija.Id)
                                    {
                                        ak.IdNamestaja.Add(namestaj.Id);
                                    }
                                }
                            }
                            Namestaj.Update(n);

                            /*
                            foreach (var ak in listaAkcija)
                            {
                                if (izabranaAkcija != null)
                                {
                                    ak.IdNamestaja.Add(namestaj.Id);
                                }
                            }
                            */
                            /*
                            foreach (var ak in listaAkcija)
                            {
                                if(ak.Id == n.IdAkcije)
                                {
                                    ak.IdNamestaja.Add(n.Id);
                                }
                            }*/

                            //n.Sifra = this.tbSifra.Text;
                            //n.Cena = Double.Parse(this.tbCena.Text);
                            //n.KolicinaUMagacinu = int.Parse(this.tbKolicina.Text);
                            //n.IdTipaNamestaja = izabraniTipNamestaja.Id;
                            break;
                        }
                    }
                    break;
            }
            //GenericSerializer.Serialize("namestaj.xml", listaNamestaja);
            GenericSerializer.Serialize("akcija.xml", listaAkcija);
            Close();
        }

        private void ZatvoriNamestajWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
