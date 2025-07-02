namespace productservice.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public required String Name { get; set; }
        public required String CreatedBy { get; set; }
        public Decimal Price { get; set; }
    }
}
