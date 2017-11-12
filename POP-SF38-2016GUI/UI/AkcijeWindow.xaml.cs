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

            InicijalizujVrednosti(akcija, operacija);
        }

        private void InicijalizujVrednosti(Akcija akcija, Operacija operacija)
        {
            this.akcija = akcija;
            this.operacija = operacija;

            this.tbPopust.Text = akcija.Popust.ToString();
            this.dtPocetka.Text = akcija.PocetakAkcije.ToString();
            this.dtKraj.Text = akcija.KrajAkcije.ToString();
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.Akcija;

            switch (operacija)
            {
                case Operacija.Dodavanje:
                    var novaAkcija = new Akcija()
                    {
                        Id = lista.Count + 1,
                        Popust = Double.Parse(this.tbPopust.Text),
                        PocetakAkcije = DateTime.Parse(this.dtPocetka.Text),
                        KrajAkcije = DateTime.Parse(this.dtKraj.Text)
                        //PocetakAkcije = this.DatumPocetka.Text
                    };
                    lista.Add(novaAkcija);
                    break;
                case Operacija.Izmena:
                    foreach (var n in lista)
                    {
                        if (n.Id == akcija.Id)
                        {
                            n.Popust = Double.Parse(this.tbPopust.Text);
                            n.PocetakAkcije = DateTime.Parse(this.dtPocetka.Text);
                            n.KrajAkcije = DateTime.Parse(this.dtKraj.Text);
                            break;
                        }
                    }
                    break;
            }
            Projekat.Instance.Akcija = lista;
            Close();
        }

        private void ZatvoriAkcijeWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
