using Domain.Enums;

namespace WebAPI.Dtos
{
    
    public class OrderGET_Dto
    {
        public int Id { get; set; }
        public List<OrderItemDto> Items { get; set; }

        public DateTime Date { get; set; }
        public double TotalCost { get; set; }
        public double FinalCost { get; set; }
        public UserDto User { get; set; }

        public string TelephoneNr { get; set; }
        public string Address { get; set; }

        public Payment? Pay { get; set; }

        public Status? Status { get; set; }

        public string Name { get; set; }
    }
}
