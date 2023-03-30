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
    /// Логика взаимодействия для InitialAdminw.xaml
    /// </summary>
    public partial class InitialAdminw : Window
    {
        PositionTableAdapter Rol = new PositionTableAdapter();
        EmployeeTableAdapter Employee = new EmployeeTableAdapter();
        WarehouseTableAdapter Warehouse = new WarehouseTableAdapter();
        FoodTableAdapter Food = new FoodTableAdapter();
        public InitialAdminw()
        {
            InitializeComponent();
            GridR.ItemsSource = Rol.GetData();
            GridE.ItemsSource = Employee.GetData();
            GridW.ItemsSource = Warehouse.GetData();

            IdP.ItemsSource = Rol.GetData();
            IdP.DisplayMemberPath = "PositionID";

            IdE.ItemsSource = Employee.GetData();
            IdE.DisplayMemberPath = "EmployeeID";

            IdF.ItemsSource = Food.GetData();
            IdF.DisplayMemberPath = "FoodID";

        }

        private void Creat_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Login.Text, out int resylt) || int.TryParse(Role.Text, out int resyl))
            {
                MessageBox.Show("Вы вели неверные данные!");
            }
            else
            {
                try
                {
                    Rol.InsertCreat(Login.Text, Convert.ToInt32(Password.Password), Role.Text);
                    GridR.ItemsSource = Rol.GetData();
                    IdP.ItemsSource = Rol.GetData();
                    IdE.ItemsSource = Employee.GetData();
                }
                catch
                {
                    MessageBox.Show("Вы вели неверные данные!");
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var id_del = (GridR.SelectedItem as DataRowView).Row[0];
            Rol.DeleteDelet(Convert.ToInt32(id_del));
            GridR.ItemsSource = Rol.GetData();
            IdP.ItemsSource = Rol.GetData();
            IdE.ItemsSource = Employee.GetData();

        }

        private void Сhange_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Login.Text, out int resylt) || int.TryParse(Role.Text, out int resyl))
            {
                MessageBox.Show("Вы вели неверные данные!");
            }
            else
            {
                try
                {
                    var id_d = (GridR.SelectedItem as DataRowView).Row[0];
                    Rol.UpdateChang(Login.Text, Convert.ToInt32(Password.Password), Role.Text, Convert.ToInt32(id_d));
                    GridR.ItemsSource = Rol.GetData();
                    IdP.ItemsSource = Rol.GetData();
                    IdE.ItemsSource = Employee.GetData();
                }
                catch
                {
                    MessageBox.Show("Вы вели неверные данные!");
                }
            }
        }

        
        private void C_Click(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(FIO.Text, out int resylt))
            {
                MessageBox.Show("Вы вели неверные данные!");
            }
            else
            {
                try
                {
                    int Salar = Convert.ToInt32(Salary.Text);
                    if (Salar > 0)
                    {
                        var r = Rol.GetData().Rows;
                        for (int i = 0; i < r.Count; i++)
                            if (IdP.Text == Convert.ToString(r[i][0]))
                            {
                                var ro = Rol.GetData().Rows[i][3];
                                if (Convert.ToString(ro) == "User")
                                {
                                    MessageBox.Show("Пользователь не может быть сотрудником");
                                }
                                else
                                {
                                    int id_P = Convert.ToInt32(IdP.Text);
                                    Employee.InsertC(id_P, FIO.Text, Convert.ToInt32(Salary.Text));
                                    GridE.ItemsSource = Employee.GetData();
                                    IdP.ItemsSource = Rol.GetData();                                    
                                    IdE.ItemsSource = Employee.GetData();
                                }
                            }
                    }
                    else
                    {
                        MessageBox.Show("Вы вели неверные данные!");
                    }
                }
                catch
                {
                    MessageBox.Show("Вы вели неверные данные!");
                }
            }
        }
        private void D_Click(object sender, RoutedEventArgs e)
        {
            var idd = (GridE.SelectedItem as DataRowView).Row[0];
            Employee.DeleteD(Convert.ToInt32(idd));
            GridE.ItemsSource = Employee.GetData();
            IdP.ItemsSource = Rol.GetData();
            IdE.ItemsSource = Employee.GetData();
        }

        private void U_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(FIO.Text, out int resylt))
            {
                MessageBox.Show("Вы вели неверные данные!");
            }
            else
            {
                try
                {
                    int Salar = Convert.ToInt32(Salary.Text);
                    if (Salar > 0)
                    {
                        var r = Rol.GetData().Rows;
                        for (int i = 0; i < r.Count; i++)
                            if (IdP.Text == Convert.ToString(r[i][0]))
                            {
                                var ro = Rol.GetData().Rows[i][3];
                                if (Convert.ToString(ro) == "User")
                                {
                                    MessageBox.Show("Пользователь не может быть сотрудником");
                                }
                                else
                                {
                                    var id_U = (GridE.SelectedItem as DataRowView).Row[0];
                                    int id_u = Convert.ToInt32(IdP.Text);
                                    Employee.UpdateU(id_u, FIO.Text, Convert.ToInt32(Salary.Text), Convert.ToInt32(id_U));
                                    GridE.ItemsSource = Employee.GetData();
                                    IdP.ItemsSource = Rol.GetData();
                                    IdE.ItemsSource = Employee.GetData();
                                }
                            }
                    }
                    else
                    {
                        MessageBox.Show("Вы вели неверные данные!");
                    }
                }
                catch
                {
                    MessageBox.Show("Вы вели неверные данные!");
                }
            }
        }

        
        private void creat_Click_1(object sender, RoutedEventArgs e)
        {

            var employ = Rol.GetData().Rows;
            for (int i = 0; i < employ.Count; i++)
            {
                if (IdE.Text == employ[i][0].ToString())
                {
                    var ro = Rol.GetData().Rows[i][3];
                    if (ro.ToString() == "Admin")
                    {
                        MessageBox.Show("Админ не может работать на складе");
                    }
                    else
                    {
                        int idE = Convert.ToInt32(IdE.Text);
                        int idF = Convert.ToInt32(IdF.Text);
                        Warehouse.InsertQ(idE, idF);
                        GridW.ItemsSource = Warehouse.GetData();
                        IdP.ItemsSource = Rol.GetData();
                        IdE.ItemsSource = Employee.GetData();
                    }

                }
            }

        }
        private void delete_Click_1(object sender, RoutedEventArgs e)
        {
            var del = (GridW.SelectedItem as DataRowView).Row[0];
            Warehouse.DeleteQ(Convert.ToInt32(del));
            GridW.ItemsSource = Warehouse.GetData();
            IdP.ItemsSource = Rol.GetData();
            IdE.ItemsSource = Employee.GetData();
        }

        private void uptad_Click(object sender, RoutedEventArgs e)
        {
            var employ = Rol.GetData().Rows;
            for (int i = 0; i < employ.Count; i++)
            {
                if (IdE.Text == employ[i][0].ToString())
                {
                    var ro = Rol.GetData().Rows[i][3];
                    if (ro.ToString() == "Admin")
                    {
                        MessageBox.Show("Админ не может работать на складе");
                    }
                    else
                    {
                        if ((GridW.SelectedItem as DataRowView) != null)
                        {
                            var del = (GridW.SelectedItem as DataRowView).Row[0];
                            int idE = Convert.ToInt32(IdE.Text);
                            int idF = Convert.ToInt32(IdF.Text);
                            Warehouse.UpdateQ(idF, idE, Convert.ToInt32(del));
                            GridW.ItemsSource = Warehouse.GetData();
                            IdP.ItemsSource = Rol.GetData();
                            IdE.ItemsSource = Employee.GetData();
                        }
                    }
                }
            }
        }


        private void GridR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((GridR.SelectedItem as DataRowView) != null)
            {
                Login.Text = (GridR.SelectedItem as DataRowView).Row[1].ToString();
                Password.Password = (GridR.SelectedItem as DataRowView).Row[2].ToString();
                Role.Text = (GridR.SelectedItem as DataRowView).Row[3].ToString();

            }
        }

        private void GridE_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((GridE.SelectedItem as DataRowView) != null)
            {
                IdP.Text = (GridE.SelectedItem as DataRowView).Row[1].ToString();
                FIO.Text = (GridE.SelectedItem as DataRowView).Row[2].ToString();
                Salary.Text = (GridE.SelectedItem as DataRowView).Row[3].ToString();

            }
        }

        private void GridW_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((GridW.SelectedItem as DataRowView) != null)
            {
                IdE.Text = (GridW.SelectedItem as DataRowView).Row[1].ToString();
                IdF.Text = (GridW.SelectedItem as DataRowView).Row[2].ToString();
            }
        }



        private void food_Click(object sender, RoutedEventArgs e)
        {
            FOOD windf = new FOOD();
            windf.ShowDialog();
        }

        private void Breed_Click(object sender, RoutedEventArgs e)
        {
            Breed windb = new Breed();
            windb.ShowDialog();
        }

        private void Pokypku_Click(object sender, RoutedEventArgs e)
        {
            Kassa windK = new Kassa();
            windK.ShowDialog();
        }

        private void Owner_Click(object sender, RoutedEventArgs e)
        {
            Owner windW = new Owner();
            windW.ShowDialog();
        }

        private void Pet_Click(object sender, RoutedEventArgs e)
        {
            PET WindP = new PET();
            WindP.ShowDialog();
        }

        
    }
}
