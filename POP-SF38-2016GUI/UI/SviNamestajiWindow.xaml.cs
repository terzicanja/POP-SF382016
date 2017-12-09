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
        private StavkaProdaje stavka;
        private Radnja radnja;
        
        public SviNamestajiWindow(Radnja radnja = Radnja.Sacuvaj)
        {
            InitializeComponent();

            SelektovaniNamestaj = new Namestaj();
            this.DataContext = SelektovaniNamestaj;
            this.radnja = radnja;
            this.stavka = new StavkaProdaje();
            

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

            //dgSviNamestaji.SelectedValue = selectedna

            dgSviNamestaji.DataContext = this;
            dgSviNamestaji.ItemsSource = Projekat.Instance.Namestaj;
        }

        private void PickNamestaj(object sender, RoutedEventArgs e)
        {
            SelektovaniNamestaj = dgSviNamestaji.SelectedItem as Namestaj;
            this.DialogResult = true;
            this.Close();
        }

        private void SacuvajStavku(object sender, RoutedEventArgs e)
        {
            var listaStavki = Projekat.Instance.StavkaProdaje;
            SelektovaniNamestaj = dgSviNamestaji.SelectedItem as Namestaj;

            /*foreach (var s in listaStavki)
            {
                if(s.IdNamestaja == SelektovaniNamestaj.Id && s.Kolicina == int.Parse(tbKoliko.Text))
                {
                    SelektovanaStavka = s;
                }
                else
                {
                    stavka.Id = listaStavki.Count + 1;
                    stavka.IdNamestaja = SelektovaniNamestaj.Id;
                    stavka.Kolicina = int.Parse(tbKoliko.Text);

                    listaStavki.Add(stavka);

                    SelektovanaStavka = stavka;
                    GenericSerializer.Serialize("stavka.xml", listaStavki);
                }
            }*/
            
            stavka.Id = listaStavki.Count+1;
            stavka.IdNamestaja = SelektovaniNamestaj.Id;
            stavka.Kolicina = int.Parse(tbKoliko.Text);

            listaStavki.Add(stavka);

            SelektovanaStavka = stavka;
            GenericSerializer.Serialize("stavka.xml", listaStavki);
            this.Close();
        }
        
    }
}
