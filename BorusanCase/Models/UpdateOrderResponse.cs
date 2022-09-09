namespace BorusanCase.Models
{
    public class UpdateOrderResponse
    {
        public int CustomerOrderNumber { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public String? OrderNumber { get; set; }
    }
}
