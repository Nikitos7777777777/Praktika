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
using UtogovuiP.PitomnikDataSetTableAdapters;
namespace UtogovuiP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PositionTableAdapter p = new PositionTableAdapter();
        public MainWindow()
        {
            InitializeComponent();

        }
        private void Avtoriz_Click(object sender, RoutedEventArgs e)
        {
            var Avtor = p.GetData().Rows;
            bool check = false;
            
            for (int i = 0; i < Avtor.Count; i++)
            {
                if (Convert.ToString(Avtor[i][1]) == Login.Text && Convert.ToString(Avtor[i][2]) == Password.Password)
                {
                    check = true;
                    var rol = p.GetData().Rows[i][3];
                    if (Convert.ToString(rol) == "Admin")
                    {
                        InitialAdminw adminw = new InitialAdminw();
                        adminw.ShowDialog();
                        break;

                    }
                    else if (Convert.ToString(rol) == "User")
                    {
                       User userw= new User();
                        userw.ShowDialog();
                        break;
                    }
                   
                }             
            }
            if(!check)
            {
                MessageBox.Show("Неверный логин или пароль");
            }


        }
    }
}
