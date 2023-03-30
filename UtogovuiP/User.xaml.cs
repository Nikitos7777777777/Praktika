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
using System.Windows.Shapes;

namespace UtogovuiP
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
        }

       

        private void Laevpet_Click(object sender, RoutedEventArgs e)
        {
            LeavePet windLP= new LeavePet();
            windLP.ShowDialog();
        }

        private void Care_Click(object sender, RoutedEventArgs e)
        {
            Yslygi windY = new Yslygi();
            windY.ShowDialog();
        }
    }
}
