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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        pharmaShopEntities pharmaDB = new pharmaShopEntities();
        public ProductsPage()
        {
            InitializeComponent();
            prodDgr.ItemsSource = pharmaDB.DepartmentProduct.ToList();

            typeCbx.ItemsSource = pharmaDB.ProductTypes.ToList();
            typeCbx.DisplayMemberPath = "type_label";

            departCbx.ItemsSource = pharmaDB.Departments.ToList();
            departCbx.DisplayMemberPath = "department_name";
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Products prodinfo = new Products();
                prodinfo.product_name = product.Text;
                prodinfo.price = Convert.ToDecimal(price.Text);
                prodinfo.amount = Convert.ToInt32(amountRem.Text);

                foreach (var item in pharmaDB.ProductTypes.ToList())
                {
                    if (item.Equals(typeCbx.SelectedItem))
                    {
                        prodinfo.productType_ID = item.ID_type;
                    }
                }

                pharmaDB.Products.Add(prodinfo);

                pharmaDB.SaveChanges();


                DepartmentProduct prodDepart = new DepartmentProduct();
                foreach (var prod in pharmaDB.Products.ToList())
                {
                    if (prod.product_name == product.Text && prod.price == Convert.ToDecimal(price.Text)
                        && prod.amount == Convert.ToInt32(amountRem.Text))
                    {
                        prodDepart.product_ID = prod.ID_product;
                    }
                }
                foreach (var depart in pharmaDB.Departments.ToList())
                {
                    if (depart.Equals(departCbx.SelectedItem))
                    {
                        prodDepart.department_ID = depart.ID_department;
                    }
                }
                pharmaDB.DepartmentProduct.Add(prodDepart);

                pharmaDB.SaveChanges();
            }
            catch
            {
                if (product.Text == string.Empty || price.Text == string.Empty || amountRem.Text == string.Empty)
                {
                    MessageBox.Show("Введены не все данные!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (typeCbx.SelectedItem == null)
                {
                    MessageBox.Show("Не выбран тип продукта!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (product.Text != string.Empty && price.Text != string.Empty && amountRem.Text != string.Empty && departCbx.SelectedItem != null)
                {
                    MessageBox.Show("Не все данные введены корректно!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (product.Text != string.Empty && price.Text != string.Empty && amountRem.Text != string.Empty && departCbx.SelectedItem == null)
                {
                    MessageBox.Show("Не выбран отдел!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            finally
            {
                prodDgr.ItemsSource = pharmaDB.DepartmentProduct.ToList();
            }
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            if (prodDgr.SelectedItem != null)
            {
                var selected = prodDgr.SelectedItem as DepartmentProduct;

                if (typeCbx != null)
                {
                    foreach (var type in pharmaDB.ProductTypes.ToList())
                    {
                        if (type.Equals(typeCbx.SelectedItem))
                        {
                            selected.Products.productType_ID = type.ID_type;
                        }
                    }
                }

                if (departCbx.SelectedItem != null)
                {
                    foreach (var comp in pharmaDB.Departments.ToList())
                    {
                        if (comp.Equals(departCbx.SelectedItem))
                        {
                            selected.department_ID = comp.ID_department;
                        }
                    }
                }

                pharmaDB.SaveChanges();

                prodDgr.ItemsSource = pharmaDB.DepartmentProduct.ToList();
            }
        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            if (prodDgr.SelectedItem != null)
            {
                pharmaDB.DepartmentProduct.Remove(prodDgr.SelectedItem as DepartmentProduct);

                pharmaDB.SaveChanges();

                prodDgr.ItemsSource = pharmaDB.DepartmentProduct.ToList();
            }
        }

        private void prodDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (prodDgr.SelectedItem != null)
            {
                var selected = prodDgr.SelectedItem as DepartmentProduct;
                product.Text = selected.Products.product_name;
                price.Text = Convert.ToString(selected.Products.price);
                amountRem.Text = Convert.ToString(selected.Products.amount);
                departCbx.Text = selected.Departments.department_name;
                typeCbx.Text = selected.Products.ProductTypes.type_label;
            }
        }
    }
}
