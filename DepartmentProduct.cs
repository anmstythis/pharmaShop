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
    
    public partial class DepartmentProduct
    {
        public int ID { get; set; }
        public int department_ID { get; set; }
        public int product_ID { get; set; }
    
        public virtual Departments Departments { get; set; }
        public virtual Products Products { get; set; }
    }
}
