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
    /// Логика взаимодействия для PET.xaml
    /// </summary>
    public partial class PET : Window
    {
        public string clos;
        PetTableAdapter p = new PetTableAdapter();
        Owner_PetTableAdapter owner = new Owner_PetTableAdapter();
        public PET()
        {
            InitializeComponent();
            GridPet.ItemsSource = p.GetData();

            IdO.ItemsSource = owner.GetData();
            IdO.DisplayMemberPath = "Owner_PetID";
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
                if (int.TryParse(Name.Text, out int resylt) || int.TryParse(Typ.Text, out int resyl) || int.TryParse(Poll.Text, out int resy))
                {
                    MessageBox.Show(" вели неверные данные!");
                }
                else
                {
                    if (Name.Text != "" || Typ.Text != "" || Birthd.Text != "" || Poll.Text != "" || IdO.Text != "")
                    {
                        p.InsertQuery(Name.Text, Typ.Text, Poll.Text, Convert.ToInt32(Birthd.Text), Convert.ToInt32(IdO.Text));
                        GridPet.ItemsSource = p.GetData();
                        IdO.ItemsSource = owner.GetData();
                    }
                    else
                    {
                        MessageBox.Show(" неверные данные!");
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
                if (int.TryParse(Name.Text, out int resylt) || int.TryParse(Typ.Text, out int resyl) || int.TryParse(Poll.Text, out int resy))
                {
                    MessageBox.Show(" вели неверные данные!");
                }
                else
                {
                    if (Name.Text != "" || Typ.Text != "" || Birthd.Text != "" || Poll.Text != "" || IdO.Text != " ")
                    {
                        var ubted = (GridPet.SelectedItem as DataRowView).Row[0];
                        p.UpdateQuery(Name.Text, Typ.Text, Poll.Text, Convert.ToInt32(Birthd.Text), Convert.ToInt32(IdO.Text),Convert.ToInt32(ubted));
                        GridPet.ItemsSource = p.GetData();
                        IdO.ItemsSource = owner.GetData();
                    }
                    else
                    {
                        MessageBox.Show(" неверные данные!");
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
            var ubted = (GridPet.SelectedItem as DataRowView).Row[0];
            p.DeleteQuery(Convert.ToInt32(ubted));
            GridPet.ItemsSource = p.GetData();
            IdO.ItemsSource = owner.GetData();
        }

        private void GridPet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((GridPet.SelectedItem as DataRowView) != null)
            {
                Name.Text = (GridPet.SelectedItem as DataRowView).Row[1].ToString();
                Typ.Text = (GridPet.SelectedItem as DataRowView).Row[2].ToString();
                Poll.Text = (GridPet.SelectedItem as DataRowView).Row[3].ToString();
                Birthd.Text = (GridPet.SelectedItem as DataRowView).Row[4].ToString();
                IdO.Text = (GridPet.SelectedItem as DataRowView).Row[5].ToString();
            }
        }
    }
}
