using FarmAZ.Entities;

namespace FarmAZ.DTOs.Order{
    public class CreatOrderDTO
{
    public  List<OrderItem> Items{get; set;}=new();
}

public class OrderItem
    {
        public int ProductId{get; set;}

        public int Quantity{get; set;}
    }
}