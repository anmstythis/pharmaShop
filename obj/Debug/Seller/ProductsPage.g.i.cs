﻿#pragma checksum "..\..\..\Seller\ProductsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "568F2C8CE2CC232CE9DE25F9DC9EB0FA24C28256CFED7E9D79C48ED669155728"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using pharmaShop.Seller;


namespace pharmaShop.Seller {
    
    
    /// <summary>
    /// ProductsPage
    /// </summary>
    public partial class ProductsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\Seller\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid prodDgr;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Seller\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addButton;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Seller\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button changeButton;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Seller\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deletebutton;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Seller\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox product;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Seller\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox price;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Seller\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox amountRem;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Seller\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox typeCbx;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Seller\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox departCbx;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/pharmaShop;component/seller/productspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Seller\ProductsPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.prodDgr = ((System.Windows.Controls.DataGrid)(target));
            
            #line 29 "..\..\..\Seller\ProductsPage.xaml"
            this.prodDgr.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.prodDgr_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.addButton = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Seller\ProductsPage.xaml"
            this.addButton.Click += new System.Windows.RoutedEventHandler(this.addButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.changeButton = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Seller\ProductsPage.xaml"
            this.changeButton.Click += new System.Windows.RoutedEventHandler(this.changeButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.deletebutton = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\Seller\ProductsPage.xaml"
            this.deletebutton.Click += new System.Windows.RoutedEventHandler(this.deletebutton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.product = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.price = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.amountRem = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.typeCbx = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.departCbx = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

