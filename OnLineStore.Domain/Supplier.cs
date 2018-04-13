using System.Collections.Generic;

namespace OnLineStore.Domain
{
    public class Supplier
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Adress { get; set; }

        public ICollection<ProductSupplier> ProductSuppliers { get; set; }


    }
}
