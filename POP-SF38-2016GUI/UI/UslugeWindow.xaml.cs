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
    /// Interaction logic for UslugeWindow.xaml
    /// </summary>
    public partial class UslugeWindow : Window
    {
        private DodatnaUsluga usluga;
        private Operacija operacija;

        public UslugeWindow(DodatnaUsluga usluga, Operacija operacija)
        {
            InitializeComponent();

            InicijalizujVrednosti(usluga, operacija);
        }

        private void InicijalizujVrednosti(DodatnaUsluga usluga, Operacija operacija)
        {
            this.usluga = usluga;
            this.operacija = operacija;

            this.tbUsluga.Text = usluga.Usluga;
            this.tbCena.Text = usluga.Cena.ToString();
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.DodatnaUsluga;

            switch (operacija)
            {
                case Operacija.Dodavanje:
                    var novaUsluga = new DodatnaUsluga()
                    {
                        Id = lista.Count + 1,
                        Usluga = this.tbUsluga.Text,
                        Cena = int.Parse(this.tbCena.Text)
                    };
                    lista.Add(novaUsluga);
                    break;
                case Operacija.Izmena:
                    foreach (var n in lista)
                    {
                        if (n.Id == usluga.Id)
                        {
                            n.Usluga = this.tbUsluga.Text;
                            n.Cena = int.Parse(this.tbCena.Text);
                            break;
                        }
                    }
                    break;
            }
            Projekat.Instance.DodatnaUsluga = lista;
            Close();
        }

        private void ZatvoriUslugeWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
