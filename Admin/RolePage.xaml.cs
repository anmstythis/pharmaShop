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

namespace pharmaShop.Admin
{
    /// <summary>
    /// Логика взаимодействия для RolePage.xaml
    /// </summary>
    public partial class RolePage : Page
    {
        pharmaShopEntities pharmaDB = new pharmaShopEntities();
        public RolePage()
        {
            InitializeComponent();
            roleDgr.ItemsSource = pharmaDB.Roles.ToList();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Roles roleinfo = new Roles();
                roleinfo.role_label = rolename.Text;
                pharmaDB.Roles.Add(roleinfo);

                pharmaDB.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                roleDgr.ItemsSource = pharmaDB.Roles.ToList();
            }
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            if (roleDgr.SelectedItem != null)
            {
                pharmaDB.SaveChanges();

                roleDgr.ItemsSource = pharmaDB.Roles.ToList();
            }
        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            if (roleDgr.SelectedItem != null)
            {
                pharmaDB.Roles.Remove(roleDgr.SelectedItem as Roles);

                pharmaDB.SaveChanges();

                roleDgr.ItemsSource = pharmaDB.Roles.ToList();
            }
        }

        private void roleDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (roleDgr.SelectedItem != null)
            {
                var selected = roleDgr.SelectedItem as Roles;
                rolename.Text = selected.role_label;
            }
        }
    }
}
