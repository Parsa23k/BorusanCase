namespace BorusanCase.Models.ViewModel
{
    public class OrderResponseModel
    {
        public string CustomerOrderNo { get; set; }
        public string OrderNo { get; set; }
        public string PortAddress { get; set; }
        public string ArrivalAddress { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public string Weight { get; set; }
        public string WeightUnit { get; set; }
        public string MaterialCode { get; set; }
        public string Note { get; set; }
        public string OrderStatus { get; set; }
        public int OrderStatusId { get; set; }
        public int Id { get; set; }
        
    }
}
