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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Primes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PrimeCounter prCounter;
        public MainWindow()
        {
            InitializeComponent();

            prCounter = new PrimeCounter();
            FillComboBoxs();
        }

        private void FillComboBoxs()
        {
            foreach (var item in prCounter.KrArr) { cbFirstCriterium.Items.Add(item.Method.Name); }
            foreach (var item in prCounter.KrArr) { cbSecondCriterium.Items.Add(item.Method.Name); }
            foreach (var item in prCounter.KrArr) { cbThirdCriterium.Items.Add(item.Method.Name); }
        }

        private async void butFirst_Click(object sender, RoutedEventArgs e)
        {
            Button but = (sender as Button);

            int vybranaMetoda = cbFirstCriterium.SelectedIndex;
            string parametr = tbFirstCriteriumParameter.Text == "" ? "2" : tbFirstCriteriumParameter.Text;
            string vysledek;

            but.IsEnabled = false;

            tbFirstOut.Text = "Probíhá výpočet...";

            vysledek = await prCounter.GetRequestPrimeAsync(vybranaMetoda, parametr);

            tbFirstOut.Text = vysledek;
            cbFirstCriterium.SelectedIndex = 0;
            tbFirstCriteriumParameter.Text = "";
            but.IsEnabled = true;
        }

        private async void butsecond_Click(object sender, RoutedEventArgs e)
        {
            Button but = (sender as Button);

            int vybranaMetoda = cbSecondCriterium.SelectedIndex;
            string parametr = tbSeconfCriteriumParameter.Text == "" ? "2" : tbSeconfCriteriumParameter.Text;
            string vysledek;

            but.IsEnabled = false;

            tbSecondOut.Text = "Probíhá výpočet...";

            vysledek = await prCounter.GetRequestPrimeAsync(vybranaMetoda, parametr);

            tbSecondOut.Text = vysledek;
            cbSecondCriterium.SelectedIndex = 0;
            tbSeconfCriteriumParameter.Text = "";
            but.IsEnabled = true;
        }

        private async void butThird_Click(object sender, RoutedEventArgs e)
        {
            Button but = (sender as Button);

            int vybranaMetoda = cbThirdCriterium.SelectedIndex;
            string parametr = tbThirdCriteriumParameter.Text == "" ? "2" : tbThirdCriteriumParameter.Text;
            string vysledek;

            but.IsEnabled = false;

            tbThirdOut.Text = "Probíhá výpočet...";

            vysledek = await prCounter.GetRequestPrimeAsync(vybranaMetoda, parametr);

            tbThirdOut.Text = vysledek;
            cbThirdCriterium.SelectedIndex = 0;
            tbThirdCriteriumParameter.Text = "";
            but.IsEnabled = true;
        }
    }
}
