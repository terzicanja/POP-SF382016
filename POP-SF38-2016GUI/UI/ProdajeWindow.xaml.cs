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
        private DodatnaUsluga SelektovanaUsluga;
        private Operacija operacija;

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

            dgProdajaNamestaj.ItemsSource = prodaja.IdStavki;
            //dgProdajaUsluge.ItemsSource = Projekat.Instance.DodatnaUsluga;
            lbUsluge.ItemsSource = Projekat.Instance.DodatnaUsluga;
            cbUsluge.Content = Projekat.Instance.DodatnaUsluga;

            
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaProdaja = Projekat.Instance.ProdajaNamestaja;
            var listaStavki = Projekat.Instance.StavkaProdaje;
            //var izabraniKorisnik = (Korisnik)cbKorisnik.SelectedItem;

            SelektovanaUsluga = (DodatnaUsluga)lbUsluge.SelectedItem;

            switch (operacija)
            {
                case Operacija.Dodavanje:
                    prodaja.Id = listaProdaja.Count + 1;
                    prodaja.DatumProdaje = DateTime.Parse(dtProdaje.Text);
                    prodaja.BrojRacuna = int.Parse(tbBrRacuna.Text);
                    prodaja.Kupac = tbKupac.Text;
                    prodaja.IdStavki = prodaja.IdStavki;
                    prodaja.IdUsluga.Add(SelektovanaUsluga.Id);
                    //prodaja.IdKupca = izabraniKorisnik.Id;
                    //prodaja.UkupanIznos = 
                    

                    listaProdaja.Add(prodaja);
                    break;
                case Operacija.Izmena:
                    foreach (var n in listaProdaja)
                    {
                        if(n.Id == prodaja.Id)
                        {
                            n.DatumProdaje = prodaja.DatumProdaje;
                            n.BrojRacuna = prodaja.BrojRacuna;
                            n.Kupac = prodaja.Kupac;
                            n.IdUsluga = prodaja.IdUsluga;
                            //n.Korisnik = prodaja.Korisnik;
                        }
                    }
                    break;
            }
            GenericSerializer.Serialize("prodaja.xml", listaProdaja);
            Close();
        }

        private void ZatvoriProdajeWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SviNamestajiZaProdaju(object sender, RoutedEventArgs e)
        {
            SviNamestajiWindow prozor = new SviNamestajiWindow(SviNamestajiWindow.Radnja.Sacuvaj);
            prozor.ShowDialog();
            //if(prozor.ShowDialog() == true)
            //{
                prodaja.IdStavki.Add(prozor.SelektovanaStavka.Id);
            //}
        }
    }
}
