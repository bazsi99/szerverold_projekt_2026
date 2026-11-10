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
    /// <summary>
    /// Interaction logic for EtelWindow.xaml
    /// </summary>
    public partial class EtelWindow : Window
    {
        string endpoint;
        public EtelWindow(string endpoint, string cim)
        {
            InitializeComponent();
            this.endpoint = endpoint;
            Title = cim;
            Load();
        }
        
        async void Load()
        {
            try
            {
                dg.ItemsSource = await Api.Client.GetFromJsonAsync<List<Recept>>(endpoint);
            }
            catch
            {
                MessageBox.Show("Az API nem érhető el. Elindítottad?");
            }
        }

        Recept ReadForm()
        {
            int ido;
            if (txtName.Text == "" || !int.TryParse(txtTime.Text, out ido))
            {
                MessageBox.Show("Add meg a nevet, és az időt (számként)!");
                return null;
            }
            return new Recept
            {
                Nev = txtName.Text,
                Leiras = txtDescription.Text,
                ElkeszitesiIdoPerc = ido
            };
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var x = dg.SelectedItem as Recept;
            if (x == null) return;
            txtName.Text = x.Nev;
            txtDescription.Text = x.Leiras;
            txtTime.Text = x.ElkeszitesiIdoPerc.ToString();
            lbHozzavalok.ItemsSource = x.Hozzavalok;
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            var x = ReadForm();
            if (x == null) return;
            await Api.Client.PostAsJsonAsync(endpoint, x);
            Load();
        }

        private async void Modify_Click(object sender, RoutedEventArgs e)
        {
            var kivalasztott = dg.SelectedItem as Recept;
            if (kivalasztott == null) { MessageBox.Show("Válassz ki egy sort!"); return; }
            var x = ReadForm();
            if (x == null) return;
            x.Id = kivalasztott.Id;
            await Api.Client.PutAsJsonAsync(endpoint + "/" + x.Id, x);
            Load();
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            var kivalasztott = dg.SelectedItem as Recept;
            if (kivalasztott == null) { MessageBox.Show("Válassz ki egy sort!"); return; }
            if (MessageBox.Show("Biztos törlöd?", "Törlés", MessageBoxButton.YesNo) == MessageBoxResult.No) return;
            await Api.Client.DeleteAsync(endpoint + "/" + kivalasztott.Id);
            lbHozzavalok.ItemsSource = null;
            Load();
        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = await Api.Client.GetFromJsonAsync<List<Recept>>(
                endpoint + "/kereses?szo=" + Uri.EscapeDataString(txtSearch.Text));
        }

        private void All_Click(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";
            Load();
        }
    }
}
