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
    /// Interaction logic for UslugeWindow.xaml
    /// </summary>
    public partial class UslugeWindow : Window
    {
        private DodatnaUsluga usluga;
        private Operacija operacija;

        public UslugeWindow(DodatnaUsluga usluga, Operacija operacija)
        {
            InitializeComponent();

            this.usluga = usluga;
            this.operacija = operacija;

            tbUsluga.DataContext = usluga;
            tbCena.DataContext = usluga;
        }
        

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.DodatneUsluge;
            if (ForceValidation() == true)
            {
                return;
            }
            switch (operacija)
            {
                case Operacija.Dodavanje:
                    usluga.Id = lista.Count + 1;
                    usluga.Usluga = tbUsluga.Text;
                    usluga.Cena = int.Parse(tbCena.Text);

                    DodatnaUsluga.Create(usluga);
                    break;
                case Operacija.Izmena:
                    foreach (var n in lista)
                    {
                        if (n.Id == usluga.Id)
                        {
                            n.Usluga = usluga.Usluga;
                            n.Cena = usluga.Cena;
                            break;
                        }
                    }
                    break;
            }
            Close();
        }

        private void ZatvoriUslugeWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool ForceValidation()
        {
            BindingExpression be1 = tbUsluga.GetBindingExpression(TextBox.TextProperty);
            be1.UpdateSource();
            BindingExpression be2 = tbCena.GetBindingExpression(TextBox.TextProperty);
            be2.UpdateSource();

            if (Validation.GetHasError(tbUsluga) == true || Validation.GetHasError(tbCena) == true)
            {
                return true;
            }
            return false;
        }
    }
}
