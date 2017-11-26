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
    /// Interaction logic for AkcijeWindow.xaml
    /// </summary>
    public partial class AkcijeWindow : Window
    {
        private Akcija akcija;
        private Operacija operacija;

        public AkcijeWindow(Akcija akcija, Operacija operacija)
        {
            InitializeComponent();

            this.akcija = akcija;
            this.operacija = operacija;

            tbPopust.DataContext = akcija;
            dtPocetka.DataContext = akcija;
            dtKraj.DataContext = akcija;

            dgPopustNamestaj.IsSynchronizedWithCurrentItem = true;
            dgPopustNamestaj.DataContext = this;
            dgPopustNamestaj.ItemsSource = Projekat.Instance.Namestaj;
        }
        

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.Akcija;

            switch (operacija)
            {
                case Operacija.Dodavanje:
                    akcija.Id = lista.Count + 1;
                    akcija.Popust = Double.Parse(tbPopust.Text);
                    akcija.PocetakAkcije = DateTime.Parse(dtPocetka.Text);
                    akcija.KrajAkcije = DateTime.Parse(dtKraj.Text);
                    //PocetakAkcije = this.DatumPocetka.Text
                    lista.Add(akcija);
                    break;
                case Operacija.Izmena:
                    foreach (var n in lista)
                    {
                        if (n.Id == akcija.Id)
                        {
                            n.Popust = akcija.Popust;
                            n.PocetakAkcije = akcija.PocetakAkcije;
                            n.KrajAkcije = akcija.KrajAkcije;
                            break;
                        }
                    }
                    break;
            }
            GenericSerializer.Serialize("akcija.xml", lista);
            Close();
        }

        private void ZatvoriAkcijeWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
