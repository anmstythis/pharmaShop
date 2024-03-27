using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
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

namespace pharmaShop.Buyer
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        pharmaShopEntities pharmaDB = new pharmaShopEntities();
        List<DepartmentProduct> goods = new List<DepartmentProduct>();
        decimal price;
        string text;
        List<string> orders = new List<string>();
        public OrdersPage()
        {
            InitializeComponent();
            goodDgr.ItemsSource = pharmaDB.DepartmentProduct.ToList();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (goodDgr.SelectedItem != null)
            {
                goods.Add(goodDgr.SelectedItem as DepartmentProduct);
                orderDgr.ItemsSource = goods;

                price = goods[0].Products.price;
                for(int i = 0; i < goods.Count - 1; i++)
                {
                    price += goods[i + 1].Products.price;
                }
                finalPrice.Text = "Цена: " + price;
            }
            orderDgr.Items.Refresh();
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (orderDgr.SelectedItem != null)
            {
                price -= (orderDgr.SelectedItem as DepartmentProduct).Products.price;
                finalPrice.Text = "Цена: " + price;
                goods.Remove(orderDgr.SelectedItem as DepartmentProduct);
                orderDgr.ItemsSource = goods;
            }
            orderDgr.Items.Refresh();
        }

        private int LoginCheck()
        {
            int accID = 0;
            foreach (var item in pharmaDB.Accounts.ToList())
            {
                if (item.user_login == MainWindow.Login)
                {
                    accID = item.ID_account;
                }
            }
            return accID;
        }

        private int CustomerCheck(int id)
        {
            int custID = 0;
            foreach (var item in pharmaDB.Customers.ToList())
            {
                if (item.account_ID == id)
                {
                    custID = item.ID_customer;
                }
            }
            return custID;
        }

        private void AddInfoCustoms(int id_customer, int id_product)
        {
            Customs custominfo = new Customs();
            custominfo.customer_ID = id_customer;
            custominfo.product_ID = id_product;
            pharmaDB.Customs.Add(custominfo);
            pharmaDB.SaveChanges();
        }

        private int GetBillNumber()
        {
            int allCustoms = pharmaDB.Customs.Count();
            int thisCustom = goods.Count();

            return allCustoms - thisCustom;
        }

        private void saveBillButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(clientSumm.Text) < price)
                {
                    MessageBox.Show("У Вас не хватает денег!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    int id = LoginCheck();
                    int customer = CustomerCheck(id);
                    for (int i = 0; i < goods.Count; i++)
                    {
                        AddInfoCustoms(customer, goods[i].Products.ID_product);
                    }

                    int billNum = GetBillNumber();

                    string path = $"C:\\Users\\My\\OneDrive\\Документы\\конспекты\\учебная практика\\Чек №{billNum}.txt";
                    if (!File.Exists(path))
                    {
                        File.Create(path).Close();
                    }
                    for (int i = 0; i < goods.Count; i++)
                    {
                        orders.Add($"\r\n\t{goods[i].Products.product_name}\t-\t{goods[i].Products.price}");
                    }
                    File.WriteAllText(path, $" Фармацевтический магазин\r\n\t  Кассовый чек №{billNum}\n");
                    foreach (var item in orders)
                    {
                        File.AppendAllText(path, item.ToString());
                    }
                    File.AppendAllText(path, $"\r\n\r\nИтого к оплате: {price}\r\nВнесено: {clientSumm.Text}\r\nСдача: {Convert.ToDecimal(clientSumm.Text) - price}");
                    Process.Start(new ProcessStartInfo { FileName = path, UseShellExecute = true });

                }
            }
            catch
            {
                MessageBox.Show("Цена может быть только в цифрах!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
