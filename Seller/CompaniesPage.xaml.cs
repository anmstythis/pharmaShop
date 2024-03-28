using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для CompaniesPage.xaml
    /// </summary>
    public partial class CompaniesPage : Page
    {
        pharmaShopEntities pharmaDB = new pharmaShopEntities();
        public CompaniesPage()
        {
            InitializeComponent();
            typeDgr.ItemsSource = pharmaDB.ProductTypes.ToList();

            compCbx.ItemsSource = pharmaDB.Companies.ToList();
            compCbx.DisplayMemberPath = "company_name";
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductTypes typeinfo = new ProductTypes();
                typeinfo.type_label = typeName.Text;
                typeinfo.product_description = typeDescr.Text;
                foreach (var item in pharmaDB.Companies.ToList())
                {
                    if (item.Equals(compCbx.SelectedItem))
                    {
                        typeinfo.company_ID = item.ID_company;
                    }
                }

                pharmaDB.ProductTypes.Add(typeinfo);

                pharmaDB.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Введены не все данные!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                typeDgr.ItemsSource = pharmaDB.ProductTypes.ToList();
            }
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            if (typeDgr.SelectedItem != null)
            {
                var selected = typeDgr.SelectedItem as ProductTypes;
                if (compCbx.SelectedItem != null)
                {
                    foreach (var item in pharmaDB.Companies.ToList())
                    {
                        if (item.Equals(compCbx.SelectedItem))
                        {
                            selected.company_ID = item.ID_company;
                        }
                    }
                }

                pharmaDB.SaveChanges();
                typeDgr.ItemsSource = pharmaDB.ProductTypes.ToList();
            }
        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            if (typeDgr.SelectedItem != null)
            {
                pharmaDB.ProductTypes.Remove(typeDgr.SelectedItem as ProductTypes);
                pharmaDB.SaveChanges();
                typeDgr.ItemsSource = pharmaDB.ProductTypes.ToList();
            }
        }

        private void importbutton_Click(object sender, RoutedEventArgs e)
        {
            List<ProductTypes> importFile = ConvertToJson.DeserializeObject<List<ProductTypes>>();
            foreach (var item in importFile)
            {
                ProductTypes type = new ProductTypes();
                type.type_label = item.type_label;
                type.product_description = item.product_description;

                pharmaDB.ProductTypes.Add(type);
                pharmaDB.SaveChanges();
            }
            typeDgr.ItemsSource = pharmaDB.ProductTypes.ToList();
        }

        private void typeDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = typeDgr.SelectedItem as ProductTypes;
            typeName.Text = selected.type_label;
            typeDescr.Text = selected.product_description;
            try
            {
                compCbx.Text = selected.Companies.company_name;
            }
            catch
            {
                compCbx.Text = string.Empty;
            }
        }
    }
}
