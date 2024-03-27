//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pharmaShop
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    public partial class Accounts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Accounts()
        {
            this.Customers = new HashSet<Customers>();
            this.Staff = new HashSet<Staff>();
        }
    
        public int ID_account { get; set; }

        private string _login;
        public string user_login
        {
            get
            {
                return _login;
            }
            set
            {
                if (value != string.Empty)
                {
                    _login = value;
                }
            }
        }

        private string _password;
        public string user_password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value != string.Empty)
                {
                    if (value.Length < 4)
                    {
                        MessageBox.Show("Введите как минимум 4 символа!", "Слишком слабый пароль!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        _password = value;
                    }
                }
            }
        }
        public int role_ID { get; set; }
    
        public virtual Roles Roles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customers> Customers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Staff> Staff { get; set; }
    }
}