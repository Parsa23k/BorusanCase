namespace BorusanCase.Models
{
    public class UpdateOrderRequest
    {
        public int CustomerOrderNumber { get; set; }
        public int OrderStatusId { get; set; }
        public string Not { get; set; } = null!;
        public DateTime? UpdateDate { get; set; }
    }
}
