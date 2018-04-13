using System.Collections.Generic;

namespace OnLineStore.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

        public List<ProductSupplier> ProductSuppliers { get; set; }
        

        // public int SupplierId { get; set; }
        // public Supplier Supplier { get; set; }

    }
}
