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

namespace POP_SF38_2016GUI.UI
{
    /// <summary>
    /// Interaction logic for SviNamestajiWindow.xaml
    /// </summary>
    public partial class SviNamestajiWindow : Window
    {
        public enum Radnja
        {
            Sacuvaj,
            Preuzmi
        };

        public Namestaj SelektovaniNamestaj = null;
        public StavkaProdaje SelektovanaStavka = null;
        public NaAkciji SelektovanNaAkciji = null;
        private StavkaProdaje stavka;
        private NaAkciji naAkciji;
        private Radnja radnja;
        
        public SviNamestajiWindow(Radnja radnja = Radnja.Sacuvaj)
        {
            InitializeComponent();

            SelektovaniNamestaj = new Namestaj();
            this.DataContext = SelektovaniNamestaj;
            this.radnja = radnja;
            this.stavka = new StavkaProdaje();
            this.naAkciji = new NaAkciji();
            

            if(radnja == Radnja.Preuzmi)
            {
                dgSviNamestaji.Columns[3].Visibility = Visibility.Collapsed;
                PickSave.Click += PickNamestaj;
            }
            else
            {
                PickSave.Click += SacuvajStavku;
            }

            koliko.ItemsSource = new List<int> { 1, 2, 3, 4 };

            //int idNamestajaZaProdaju = SelektovaniNamestaj.Id;
            //int kolicinaN = koliko.ToString()
            SelektovanaStavka = new StavkaProdaje();
            SelektovanNaAkciji = new NaAkciji();

            //dgSviNamestaji.SelectedValue = selectedna

            dgSviNamestaji.DataContext = this;
            dgSviNamestaji.ItemsSource = Projekat.Instance.Namestaji;
        }

        private void PickNamestaj(object sender, RoutedEventArgs e)
        {
            var listaNamNaAkciji = Projekat.Instance.NaAkcijama;
            SelektovaniNamestaj = dgSviNamestaji.SelectedItem as Namestaj;

            naAkciji.IdNamestaja = SelektovaniNamestaj.Id;
            naAkciji.IdAkcije = 1;

            NaAkciji.Create(naAkciji);

            SelektovanNaAkciji = naAkciji;
            
            this.DialogResult = true;
            this.Close();
        }

        private void SacuvajStavku(object sender, RoutedEventArgs e)
        {
            var listaStavki = Projekat.Instance.StavkeProdaje;
            SelektovaniNamestaj = dgSviNamestaji.SelectedItem as Namestaj;


            //var novaProdaja = new ProdajaNamestaja();
            //ProdajeWindow prodajeWindow = new ProdajeWindow(novaProdaja, NamestajWindow.Operacija.Dodavanje);


            /*SelektovaniNamestaj.KolicinaUMagacinu = SelektovaniNamestaj.KolicinaUMagacinu - stavka.Kolicina;
            Namestaj.Update(SelektovaniNamestaj);*/

            /*stavka.Namestaj.KolicinaUMagacinu = stavka.Namestaj.KolicinaUMagacinu - stavka.Kolicina;
            Namestaj.Update(stavka.Namestaj);*/

            
            stavka.Id = listaStavki.Count+1;
            stavka.IdNamestaja = SelektovaniNamestaj.Id;
            //stavka.IdProdaje = novaProdaja.Id;
            stavka.IdProdaje = 1;
            stavka.Kolicina = int.Parse(tbKoliko.Text);

            //StavkaProdaje.Update(stavka);
            StavkaProdaje.Create(stavka);
            //listaStavki.Add(stavka);

            SelektovanaStavka = stavka;
            //GenericSerializer.Serialize("stavka.xml", listaStavki);
            this.Close();
        }
        
    }
}
