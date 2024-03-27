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

namespace pharmaShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        pharmaShopEntities pharmaDB = new pharmaShopEntities();
        bool loginSuccess = false;

        public static string Login;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void authButton_Click(object sender, RoutedEventArgs e)
        {
            var allAccounts = pharmaDB.Accounts.ToList();
            for (int i = 0; i < allAccounts.Count; i++)
            {
                if (allAccounts[i].user_login.ToString() == loginTxt.Text &&
                    allAccounts[i].user_password.ToString() == passwordTxt.Password)
                {
                    loginSuccess = true;

                    Login = loginTxt.Text;

                    int roleID = (int)allAccounts[i].role_ID;

                    switch(roleID)
                    {
                        case 1:
                            AdminWindow adminRole = new AdminWindow();
                            adminRole.Show();
                            Close();
                            break;
                        case 2:
                            SellerWindow sellerRole = new SellerWindow();
                            sellerRole.Show();
                            Close();
                            break;
                        case 3:
                            BuyerWindow buyerRole = new BuyerWindow();
                            buyerRole.Show();
                            Close();
                            break;
                    }

                }
            }

            if (!loginSuccess)
            {
                MessageBox.Show("Введен неверный логин и/или пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
