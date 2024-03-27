﻿using System;
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
using pharmaShop.Buyer;

namespace pharmaShop
{
    /// <summary>
    /// Логика взаимодействия для BuyerWindow.xaml
    /// </summary>
    public partial class BuyerWindow : Window
    {
        public BuyerWindow()
        {
            InitializeComponent();
            PageFrame.Content = new OrdersPage();
        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new OrdersPage();
        }
    }
}
