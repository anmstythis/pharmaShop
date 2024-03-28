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

namespace pharmaShop.Seller
{
    /// <summary>
    /// Логика взаимодействия для DepartmentsPage.xaml
    /// </summary>
    public partial class DepartmentsPage : Page
    {
        pharmaShopEntities pharmaDB = new pharmaShopEntities();
        public DepartmentsPage()
        {
            InitializeComponent();
            departDgr.ItemsSource = pharmaDB.Departments.ToList();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Departments departinfo = new Departments();

                departinfo.department_name = departName.Text;
                departinfo.address_name = departAddress.Text;

                pharmaDB.Departments.Add(departinfo);

                pharmaDB.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Введены не все данные!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                departDgr.ItemsSource = pharmaDB.Departments.ToList();
            }
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            if (departDgr.SelectedItem != null)
            {
                pharmaDB.SaveChanges();
                departDgr.ItemsSource = pharmaDB.Departments.ToList();
            }
        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            if (departDgr.SelectedItem != null)
            {
                pharmaDB.Departments.Remove(departDgr.SelectedItem as Departments);
                pharmaDB.SaveChanges();
                departDgr.ItemsSource = pharmaDB.Departments.ToList();
            }
        }

        private void importbutton_Click(object sender, RoutedEventArgs e)
        {
            var importFile = ConvertToJson.DeserializeObject<List<Departments>>();
            foreach (var item in importFile)
            {
                Departments depart = new Departments();
                depart.department_name = item.department_name;
                depart.address_name = item.address_name;

                pharmaDB.Departments.Add(depart);
                pharmaDB.SaveChanges();
            }
            departDgr.ItemsSource = pharmaDB.Departments.ToList();
        }

        private void departDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = departDgr.SelectedItem as Departments;
            departName.Text = selected.department_name;
            departAddress.Text = selected.address_name;
        }
    }
}
