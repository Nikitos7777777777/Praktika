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
    /// Логика взаимодействия для Owner.xaml
    /// </summary>
    public partial class Owner : Window
    {
        public string clos;
        Owner_PetTableAdapter OwnerPet = new Owner_PetTableAdapter();
        public Owner()
        {
            InitializeComponent();
            GridOwner.ItemsSource = OwnerPet.GetData();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            clos = "Закрыть";
            DialogResult = true;
        }
        private void Creat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(FullName.Text, out int resylt) || int.TryParse(Adres.Text, out int resyl))
                {
                    MessageBox.Show("Вы вели неверные данные!");
                }
                else
                {
                    if (FullName.Text != "" || Adres.Text != "" || Phon.Text != "" || int.TryParse(Phon.Text, out int resy))
                    {
                        OwnerPet.InsertQuery(FullName.Text, Adres.Text,Phon.Text);
                        GridOwner.ItemsSource = OwnerPet.GetData();
                    }
                    else
                    {
                        MessageBox.Show("Вы вели неверные данные!");
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Вы вели неверные данные!");
            }
           
        }

        private void Uptat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(FullName.Text, out int resylt) || int.TryParse(Adres.Text, out int resyl))
                {
                    MessageBox.Show("Вы вели неверные данные!");
                }
                else
                {
                    if (FullName.Text != "" || Adres.Text != "" || Phon.Text != "" || int.TryParse(Phon.Text, out int resy))
                    {
                        var ubted = (GridOwner.SelectedItem as DataRowView).Row[0];
                        OwnerPet.UpdateQuery(FullName.Text, Adres.Text, Phon.Text, Convert.ToInt32(ubted));
                        GridOwner.ItemsSource = OwnerPet.GetData();
                    }
                    else
                    {
                        MessageBox.Show("Вы вели неверные данные!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Вы вели неверные данные!");
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var ubted = (GridOwner.SelectedItem as DataRowView).Row[0];
            OwnerPet.DeleteQuery(Convert.ToInt32(ubted));
            GridOwner.ItemsSource = OwnerPet.GetData();
        }

        private void GridOwner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((GridOwner.SelectedItem as DataRowView) != null)
            {
                FullName.Text = (GridOwner.SelectedItem as DataRowView).Row[1].ToString();
                Adres.Text = (GridOwner.SelectedItem as DataRowView).Row[2].ToString();
                Phon.Text = (GridOwner.SelectedItem as DataRowView).Row[3].ToString();
                
            }
        }
    }
}
