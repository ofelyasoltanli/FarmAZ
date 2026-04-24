namespace FarmAZ.Entities
{
    public class Order
    {
        public int Id{get;set;}
        public int UserId{get;set;}
        public required User User{get;set;}
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public required List<OrderItem> Items{get;set;}=new();

    }
}