using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using System.Xml.Linq;
using UtogovuiP.PitomnikDataSetTableAdapters;
namespace UtogovuiP
{
    /// <summary>
    /// Логика взаимодействия для FOOD.xaml
    /// </summary>
    
    internal class FoodModel
    {
        public string Nam { get; set; }
        public string Description { get; set; }

    }

    public partial class FOOD : Window
    {
        public string clos;
        FoodTableAdapter f = new FoodTableAdapter();
        public FOOD()
        {
            InitializeComponent();
            GridFood.ItemsSource = f.GetData();
        }

        private void Creat_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Name.Text,out int resylt) || int.TryParse(Descriptio.Text, out int resyl))
            {
                MessageBox.Show("Вы вели неверные данные!");
            }
            else
            {
                if (Name.Text == "" || Descriptio.Text == "")
                {
                    MessageBox.Show("Вы вели неверные данные!");
                }
                else
                {
                    f.InsertQuery(Name.Text, Descriptio.Text);
                    GridFood.ItemsSource = f.GetData();
                }
            }           
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            clos = "Закрыть";
            DialogResult = true;
        }

        private void Uptat_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Name.Text,out int resylt) || int.TryParse(Descriptio.Text, out int resyl))
            {
                MessageBox.Show("Вы вели неверные данные!");
            }
            else
            {
                if (Name.Text == "" || Descriptio.Text == "")
                {
                    MessageBox.Show("Вы вели неверные данные!");
                }
            
                else
                {
                    var ubted = (GridFood.SelectedItem as DataRowView).Row[0];
                    f.UpdateQuery(Name.Text, Descriptio.Text, Convert.ToInt32(ubted));
                    GridFood.ItemsSource = f.GetData();
                }
               
            }
           
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var ubted = (GridFood.SelectedItem as DataRowView).Row[0];
            f.DeleteQuery(Convert.ToInt32(ubted));
            GridFood.ItemsSource = f.GetData();
        }

        private void Umport_Click(object sender, RoutedEventArgs e)
        {
            List<FoodModel> foodModels= JsonDes.DeserializeObject<List<FoodModel>>();
            foreach(var item in foodModels)
            {
                f.InsertQuery(item.Nam,item.Description);
            }
            GridFood.ItemsSource = f.GetData();
        }
    }
}
