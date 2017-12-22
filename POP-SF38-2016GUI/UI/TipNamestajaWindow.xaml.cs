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

            this.tip = tip;
            this.operacija = operacija;

            tbNaziv.DataContext = tip;
        }
        

        private void DodajTipNamestaja(object sender, RoutedEventArgs e)
        {
            var listaTipova = Projekat.Instance.TipoviNamestaja;

            switch (operacija)
            {
                case Operacija.Dodavanje:
                    //tip.Id = listaTipova.Count + 1;
                    tip.Naziv = tbNaziv.Text;
                    TipNamestaja.Create(tip);
                    /*tip.Id = listaTipova.Count + 1;
                    tip.Naziv = tbNaziv.Text;
                    listaTipova.Add(tip);*/
                    break;
                case Operacija.Izmena:
                    foreach (var n in listaTipova)
                    {
                        if (n.Id == tip.Id)
                        {
                            n.Naziv = tip.Naziv;
                            TipNamestaja.Update(n);
                            //n.Naziv = this.tbNaziv.Text;
                            break;
                        }
                    }
                    break;
            }
            //GenericSerializer.Serialize("tip.xml", listaTipova);
            Close();
        }

        private void ZatvoriTipNamestajaWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
