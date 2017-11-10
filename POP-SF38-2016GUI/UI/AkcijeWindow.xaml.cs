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

            //this.t.Text = usluga.Usluga;
            //this.tbCena.Text = usluga.Cena.ToString();
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
                        //PocetakAkcije = this.DatumPocetka.Text
                    };
                    lista.Add(novaAkcija);
                    break;
                case Operacija.Izmena:
                    foreach (var n in lista)
                    {
                        if (n.Id == akcija.Id)
                        {
                            //n.Usluga = this.tbUsluga.Text;
                            //n.Cena = int.Parse(this.tbCena.Text);
                            break;
                        }
                    }
                    break;
            }
            Projekat.Instance.Akcija = lista;
            Close();
        }


    }
}
