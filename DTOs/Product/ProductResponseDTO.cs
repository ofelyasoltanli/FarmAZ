namespace FarmAZ.DTOs.Product{

public class ProductResponseDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public double Price { get; set; }
    public required string City { get; set; }
    public required string Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public required string ImageUrl { get; set; }
    public required string FarmerName { get; set; }
}
}