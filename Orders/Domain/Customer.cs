namespace Orders.Domain
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}