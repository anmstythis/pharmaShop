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
using pharmaShop.Admin;

namespace pharmaShop
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            PageFrame.Content = new StaffPage();
        }

        private void staffButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new StaffPage();
        }

        private void roleButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new RolePage();
        }

        private void accountButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new AccountPage();
        }
    }
}
