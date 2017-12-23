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

            //dgProdajaNamestaj.ItemsSource = prodaja.IdStavki;
            //OVO POSLE BAZA NE RADI PREPRAVITI


            //dgProdajaUsluge.ItemsSource = Projekat.Instance.DodatnaUsluga;
            lbUsluge.ItemsSource = Projekat.Instance.DodatneUsluge;
            cbUsluge.Content = Projekat.Instance.DodatneUsluge;


            prodaja.Id = Projekat.Instance.ProdajeNamestaja.Count + 1;
            prodaja.BrojRacuna = 1;
            prodaja.Kupac = "a";
            prodaja.UkupanIznos = 0;
            ProdajaNamestaja.Create(prodaja);


        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaProdaja = Projekat.Instance.ProdajeNamestaja;
            var listaStavki = Projekat.Instance.StavkeProdaje;
            //var izabraniKorisnik = (Korisnik)cbKorisnik.SelectedItem;

            SelektovanaUsluga = (DodatnaUsluga)lbUsluge.SelectedItem;


            


            switch (operacija)
            {
                case Operacija.Dodavanje:
                    //prodaja.Id = listaProdaja.Count + 1;


                    //prodaja.DatumProdaje = DateTime.Parse(dtProdaje.Text);


                    prodaja.BrojRacuna = int.Parse(tbBrRacuna.Text);
                    prodaja.Kupac = tbKupac.Text;


                    //prodaja.IdStavki = prodaja.IdStavki;
                    //prodaja.IdUsluga.Add(SelektovanaUsluga.Id);
                    //prodaja.IdKupca = izabraniKorisnik.Id;
                    //prodaja.UkupanIznos = 
                    foreach (var i in listaStavki)
                    {
                        if(i.IdProdaje == prodaja.Id)
                        {
                            prodaja.UkupanIznos += i.Namestaj.Cena * i.Kolicina;
                        }
                    }

                    prodaja.UkupanIznos += SelektovanaUsluga.Cena;
                    //prodaja.UkupanIznos = listaStavki.Sum(item => item.Namestaj.Cena);

                    ProdajaNamestaja.Update(prodaja);
                    //ProdajaNamestaja.Create(prodaja);

                    //listaProdaja.Add(prodaja);
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

                            n.UkupanIznos += SelektovanaUsluga.Cena;



                            ProdajaNamestaja.Update(n);
                        }
                    }
                    break;
            }
            //GenericSerializer.Serialize("prodaja.xml", listaProdaja);
            Close();
        }

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
