using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net.Http.Json;

namespace ReceptWpf
{
    public partial class RandomWindow : Window
    {
        public RandomWindow() { InitializeComponent(); }

        private async void Random_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var r = await Api.Client.GetFromJsonAsync<Recept>("foetel/random");
                lblName.Text = r.Nev;
                lblTime.Text = "Elkészítési idő: " + r.ElkeszitesiIdoPerc + " perc";
                lblIngredients.Text = "Hozzávalók: " + string.Join(", ", r.Hozzavalok.Select(h => h.Szoveg));
                lblDescription.Text = r.Leiras;
            }
            catch
            {
                MessageBox.Show("Nincs főétel az adatbázisban, vagy nem érhető el az API!");
            }
        }
    }
}