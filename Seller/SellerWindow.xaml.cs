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
using pharmaShop.Seller;

namespace pharmaShop
{
    /// <summary>
    /// Логика взаимодействия для SellerWindow.xaml
    /// </summary>
    public partial class SellerWindow : Window
    {
        public SellerWindow()
        {
            InitializeComponent();
            PageFrame.Content = new ProductsPage();
        }

        private void prodButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ProductsPage();
        }

        private void departButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new DepartmentsPage();
        }

        private void compButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new CompaniesPage();
        }
    }
}
