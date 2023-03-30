using System;
using System.Collections.Generic;
using System.Data;
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
using UtogovuiP.PitomnikDataSetTableAdapters;
namespace UtogovuiP
{
    /// <summary>
    /// Логика взаимодействия для Breed.xaml
    /// </summary>
    
    internal class BreedModel
    {
        public string Name { get; set; }
    }

    public partial class Breed : Window
    {
        public string clos;
        BreedTableAdapter b = new BreedTableAdapter();
        public Breed()
        {
            InitializeComponent();
            GridBreed.ItemsSource = b.GetData();
        }

        private void Creat_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(breed.Text, out int resylt))
            {
                MessageBox.Show("Вы вели неверные данные!");
            }
            else
            {
                if (breed.Text == "")
                {
                    MessageBox.Show("Вы вели неверные данные!");
                }
                else
                {
                    b.Insert(breed.Text);
                    GridBreed.ItemsSource = b.GetData();
                }
            }
        }

        private void Uptat_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(breed.Text, out int resylt))
            {
                MessageBox.Show("Вы вели неверные данные!");
            }
            else
            {
                if (breed.Text == "" )
                {
                    MessageBox.Show("Вы вели неверные данные!");
                }

                else
                {
                    var ubted = (GridBreed.SelectedItem as DataRowView).Row[0];
                    b.Update1(breed.Text,Convert.ToInt32(ubted));
                    GridBreed.ItemsSource = b.GetData();
                }

            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var ubted = (GridBreed.SelectedItem as DataRowView).Row[0];
            b.Delete1(Convert.ToInt32(ubted));
            GridBreed.ItemsSource = b.GetData();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            clos = "Закрыть";
            DialogResult = true;
        }

        private void Umport_Click(object sender, RoutedEventArgs e)
        {
            List<BreedModel> breedModels = JsonDes.DeserializeObject<List<BreedModel>>();
            foreach(var model in breedModels)
            {
                b.Insert(model.Name);
            }
            GridBreed.ItemsSource = b.GetData();
        }

        private void GridBreed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((GridBreed.SelectedItem as DataRowView) != null)
            {
                breed.Text = (GridBreed.SelectedItem as DataRowView).Row[1].ToString();           
            }
        }
    }
}
