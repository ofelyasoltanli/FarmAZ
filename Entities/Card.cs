namespace FarmAZ.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public List<CardItem> Items { get; set; } = new();
    }
}