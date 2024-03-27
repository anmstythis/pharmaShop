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
    /// Логика взаимодействия для StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {
        pharmaShopEntities pharmaDB = new pharmaShopEntities();
        public StaffPage()
        {
            InitializeComponent();
            staffDgr.ItemsSource = pharmaDB.Staff.ToList();
            postCbx.ItemsSource = pharmaDB.StaffPosts.ToList();
            postCbx.DisplayMemberPath = "post_name";
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Staff staffinfo = new Staff();
                staffinfo.last_name = surname.Text;
                staffinfo.first_name = name.Text;
                staffinfo.middle_name = midname.Text;

                foreach (var item in pharmaDB.StaffPosts.ToList())
                {
                    if (item.post_name == postCbx.Text)
                    {
                        staffinfo.post_ID = item.ID_post;
                    }
                }

                pharmaDB.Staff.Add(staffinfo);
                pharmaDB.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                staffDgr.ItemsSource = pharmaDB.Staff.ToList();
            }
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            if (staffDgr.SelectedItem != null)
            {
                var selected = (Staff)staffDgr.SelectedItem;

                foreach (var item in pharmaDB.StaffPosts.ToList())
                {
                    if (item.post_name == postCbx.Text)
                    {
                        selected.post_ID = item.ID_post;
                    }
                }

                pharmaDB.SaveChanges();

                staffDgr.ItemsSource = pharmaDB.Staff.ToList();
            }
        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            if (staffDgr.SelectedItem != null)
            {
                pharmaDB.Staff.Remove(staffDgr.SelectedItem as Staff);

                pharmaDB.SaveChanges();

                staffDgr.ItemsSource = pharmaDB.Staff.ToList();
            }
        }

        private void staffDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (staffDgr.SelectedItem != null)
            {
                var selected = (Staff)staffDgr.SelectedItem;
                surname.Text = selected.last_name;
                name.Text = selected.first_name;
                midname.Text = selected.middle_name;
                postCbx.Text = selected.StaffPosts.post_name;
            }
        }
    }
}
