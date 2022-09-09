namespace BorusanCase.Models.ViewModel
{
    public class UpdateOrderStatusResponse
    {
        public string CustomerOrderNo { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}