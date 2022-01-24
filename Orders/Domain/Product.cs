using Orders.ValueObjects;

namespace Orders.Domain
{
    public class Product
    {
        public long Id { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public bool Active { get; set; }
    }
}