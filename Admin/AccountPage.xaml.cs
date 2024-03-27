using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        pharmaShopEntities pharmaDB = new pharmaShopEntities();
        public AccountPage()
        {
            InitializeComponent();
            accDgr.ItemsSource = pharmaDB.Accounts.ToList();

            staffCbx.ItemsSource = pharmaDB.Staff.ToList();
            staffCbx.DisplayMemberPath = "last_name";

            roleCbx.ItemsSource = pharmaDB.Roles.ToList();
            roleCbx.DisplayMemberPath = "role_label";
        }
 
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Accounts accinfo = new Accounts();
                accinfo.user_login = login.Text;
                accinfo.user_password = password.Password;
                foreach (var item in pharmaDB.Roles.ToList())
                {
                    if (item.Equals(roleCbx.SelectedItem))
                    {
                        accinfo.role_ID = item.ID_role;
                    }
                }
                pharmaDB.Accounts.Add(accinfo);

                pharmaDB.SaveChanges();
            }
            catch
            {
                if (login.Text == string.Empty || password.Password == string.Empty)
                {
                    MessageBox.Show("Введены не все данные!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (roleCbx.SelectedItem == null)
                {
                    MessageBox.Show("Не выбрана роль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            finally
            {
                accDgr.ItemsSource = pharmaDB.Accounts.ToList();
            }
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            if (accDgr.SelectedItem != null && staffCbx.SelectedItem != null)
            {
                var selected = accDgr.SelectedItem as Accounts;
                foreach (var item in pharmaDB.Staff.ToList())
                {
                    if (item.last_name == staffCbx.Text)
                    {
                        if (item.account_ID != null)
                        {
                            var result = MessageBox.Show("У данного пользователя уже есть аккаунт. Вы точно хотите изменить его?", "Предупреждение!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            if (result == MessageBoxResult.Yes)
                            {
                                item.account_ID = selected.ID_account;
                            }
                        }
                        else
                        {
                            item.account_ID = selected.ID_account;
                        }
                    }
                }
                pharmaDB.SaveChanges();
                accDgr.ItemsSource = pharmaDB.Accounts.ToList();
            }
        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            if (accDgr.SelectedItem != null)
            {
                pharmaDB.Accounts.Remove(accDgr.SelectedItem as Accounts);
                pharmaDB.SaveChanges();
             
                accDgr.ItemsSource = pharmaDB.Accounts.ToList();
            }
        }

        private void accDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (accDgr.SelectedItem != null)
            {
                var selected = accDgr.SelectedItem as Accounts;

                login.Text = selected.user_login;
                password.Password = selected.user_password;
                roleCbx.SelectedItem = selected.Roles;
            }
        }
    }
}
