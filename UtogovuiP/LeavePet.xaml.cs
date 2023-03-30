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
    /// Логика взаимодействия для LeavePet.xaml
    /// </summary>
    public partial class LeavePet : Window
    {
        public string clos;
        LEAVE_PETTableAdapter lp = new LEAVE_PETTableAdapter();
        PetTableAdapter p = new PetTableAdapter();
        EmployeeTableAdapter empl = new EmployeeTableAdapter();
        public LeavePet()
        {
            InitializeComponent();
            GridLeavePet.ItemsSource = lp.GetData();

            IdPet.ItemsSource = p.GetData();
            IdPet.DisplayMemberPath = "Nam";

            IdEploy.ItemsSource = empl.GetData();
            IdEploy.DisplayMemberPath = "FIO";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            clos = "Закрыть";
            DialogResult = true;
        }

        private void Uptat_Click(object sender, RoutedEventArgs e)
        {
            var pet = p.GetData().Rows;
            var emp = empl.GetData().Rows;
            int r = 0;
            int id = 0;
            try
            {
                for (int i = 0; i < pet.Count; i++)
                {
                    var row = p.GetData().Rows[i][1];
                    if (IdPet.Text == row.ToString())
                    {
                        r = Convert.ToInt16(p.GetData().Rows[i][0]);

                    }

                }
                for (int i = 0; i < emp.Count; i++)
                {
                    var rows = empl.GetData().Rows[i][2];
                    if (IdEploy.Text == rows.ToString())
                    {
                        id = Convert.ToInt16(empl.GetData().Rows[i][0]);

                    }
                }
                var ubted = (GridLeavePet.SelectedItem as DataRowView).Row[0];
                lp.UpdateQuery(Convert.ToInt16(r), Convert.ToInt16(id), Convert.ToInt16(Pastime.Text),Convert.ToInt16(ubted));
                GridLeavePet.ItemsSource = lp.GetData();
                IdPet.ItemsSource = p.GetData();
                IdEploy.ItemsSource = empl.GetData();
            }
            catch
            {
                MessageBox.Show("Вы вели неверные данные!");
            }
           
        }

        private void Creat_Click(object sender, RoutedEventArgs e)
        {
            var pet = p.GetData().Rows;           
            var emp = empl.GetData().Rows;
            int r = 0;
            int id = 0;
            try
            {
                for (int i = 0; i < pet.Count; i++)
                {
                    var row = p.GetData().Rows[i][1];
                    if (IdPet.Text == row.ToString())
                    {
                        r = Convert.ToInt16(p.GetData().Rows[i][0]);

                    }

                }
                for (int i = 0; i < emp.Count; i++)
                {
                    var rows = empl.GetData().Rows[i][2];
                    if (IdEploy.Text == rows.ToString())
                    {
                        id = Convert.ToInt16(empl.GetData().Rows[i][0]);

                    }
                }
                lp.InsertQuery(Convert.ToInt16(r), Convert.ToInt16(id), Convert.ToInt16(Pastime.Text));
                GridLeavePet.ItemsSource = lp.GetData();
                IdPet.ItemsSource = p.GetData();
                IdEploy.ItemsSource = empl.GetData();
            }
            catch
            {
                MessageBox.Show("Вы вели неверные данные!");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var ubted = (GridLeavePet.SelectedItem as DataRowView).Row[0];
            lp.DeleteQuery(Convert.ToInt32(ubted));
            GridLeavePet.ItemsSource = lp.GetData();
            IdPet.ItemsSource = p.GetData();
            IdEploy.ItemsSource = empl.GetData();
        }

        private void GridLeavePet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((GridLeavePet.SelectedItem as DataRowView) != null)
            {
                IdPet.Text = (GridLeavePet.SelectedItem as DataRowView).Row[1].ToString();
                IdEploy.Text = (GridLeavePet.SelectedItem as DataRowView).Row[2].ToString();
                Pastime.Text = (GridLeavePet.SelectedItem as DataRowView).Row[3].ToString();

            }
        }
    }
}
