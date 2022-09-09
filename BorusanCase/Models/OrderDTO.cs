namespace BorusanCase.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int CustomerOrderNumber { get; set; }
        public string DepartureAddress { get; set; } = null!;
        public string ArrivalAddress { get; set; } = null!;
        public decimal Quantity { get; set; }
        public string PiecesTypeName { get; set; }
        public decimal Weight { get; set; }
        public string WeightTypeName { get; set; }
        public string ItemCode { get; set; } = null!;
        public string ItemName { get; set; } = null!;
        public string Not { get; set; } = null!;
        public string OrderStatusName { get; set; }
    }
}
