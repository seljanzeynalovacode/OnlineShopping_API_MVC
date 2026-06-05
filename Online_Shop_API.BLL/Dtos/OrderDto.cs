using Online_Shop_API.DAL.Enums;

namespace Online_Shop_API.BLL.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Status Status { get; set; }
        public int CustomerId { get; set; }
    }
}
