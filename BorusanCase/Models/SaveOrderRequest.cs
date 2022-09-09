namespace BorusanCase.Models
{
    public class SaveOrderRequest
    {
        public int CustomerOrderNumber { get; set; }
        public string DepartureAddress { get; set; } = null!;
        public string ArrivalAddress { get; set; } = null!;
        public int Quantity { get; set; }
        public int PiecesTypeId { get; set; }
        public decimal Weight { get; set; }
        public int WeightTypeId { get; set; }
        public string ItemCode { get; set; } = null!;
        public string ItemName { get; set; } = null!;
        public string Not { get; set; } = null!;
    }
}
