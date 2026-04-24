namespace FarmAZ.Entities
{
    public class CardItem
    {
        public int Id { get; set; }

        public int CardId { get; set; }       
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Card Card { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}