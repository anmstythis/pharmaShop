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
    using Microsoft.Xaml.Behaviors.Media;
    using System;
    using System.Collections.Generic;
    
    public partial class ProductTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductTypes()
        {
            this.Products = new HashSet<Products>();
        }
    
        public int ID_type { get; set; }

        private string _label;
        public string type_label
        {
            get
            {
                return _label;
            }
            set
            {
                if (value != string.Empty)
                {
                    _label = value;
                }
            }
        }

        private string _description;
        public string product_description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value != string.Empty)
                {
                    _description = value;
                }
            }
        }
        public Nullable<int> company_ID { get; set; }
    
        public virtual Companies Companies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Products> Products { get; set; }
    }
}
