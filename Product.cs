//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Trade
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Product
    {
        private string productPhoto;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.OrderProduct = new HashSet<OrderProduct>();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnChange(object sender, PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(sender, e);
            }
        }

        public string ProductArticleNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductUnit { get; set; }
        public Nullable<decimal> ProductCost { get; set; }
        public Nullable<int> ProductDiscountMax { get; set; }
        public string ProductManufacturer { get; set; }
        public string ProductProvider { get; set; }
        public string ProductCategory { get; set; }
        public Nullable<byte> ProductDiscountAmount { get; set; }
        public Nullable<int> ProductQuantityInStock { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPhoto
        {
            get
            {
                if (productPhoto == null)
                {
                    return "materials/picture.png";
                }
                return productPhoto;
            }
            set
            {
                productPhoto = value;
                OnChange(this, new PropertyChangedEventArgs("ProductPhoto"));
            }
        }

        public virtual Category Category { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
        public virtual UnitProduct UnitProduct { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
