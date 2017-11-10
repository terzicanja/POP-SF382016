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

namespace POP_SF38_2016GUI.UI
{
    /// <summary>
    /// Interaction logic for TipNamestajaWindow.xaml
    /// </summary>
    public partial class TipNamestajaWindow : Window
    {
        public enum Operacija
        {
            Dodavanje,
            Izmena
        };

        private TipNamestaja tip;
        private Operacija operacija;

        public TipNamestajaWindow(TipNamestaja tip, Operacija operacija)
        {
            InitializeComponent();

            InicijalizujVrednosti(tip, operacija);
        }

        private void InicijalizujVrednosti(TipNamestaja tip, Operacija operacija)
        {
            this.tip = tip;
            this.operacija = operacija;

            this.tbNaziv.Text = tip.Naziv;
        }

        private void DodajTipNamestaja(object sender, RoutedEventArgs e)
        {
            var listaTipova = Projekat.Instance.Tip;

            switch (operacija)
            {
                case Operacija.Dodavanje:
                    var noviTip = new TipNamestaja()
                    {
                        Id = listaTipova.Count + 1,
                        Naziv = this.tbNaziv.Text
                    };
                    listaTipova.Add(noviTip);
                    break;
                case Operacija.Izmena:
                    foreach (var n in listaTipova)
                    {
                        if (n.Id == tip.Id)
                        {
                            n.Naziv = this.tbNaziv.Text;
                            break;
                        }
                    }
                    break;
            }
            Projekat.Instance.Tip = listaTipova;
            Close();
        }

        private void ZatvoriTipNamestajaWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
