namespace WebAPI.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Category { get; set; }   
        public double Discount { get; set; }
        public int Quantity { get; set; }
    }
}
