using Domain.Enums;

namespace WebAPI.Dtos
{
    public class UpdateOrderDTO
    {
        public int Id { get; set; }
        
        public Status? Status { get; set; }

        public string Message { get; set; }

        
    }
}
