namespace BorusanCase.Models
{
    public class SaveOrderResponse
    {
        public int CustomerOrderNumber { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public String? OrderNumber { get; set; }
    }
}
