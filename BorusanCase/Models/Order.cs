using System;
using System.Collections.Generic;

namespace BorusanCase.Models
{
    public partial class Order
    {
        public int Id { get; set; }
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
        public int OrderStatusId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual OrderStatus OrderStatus { get; set; } = null!;
        public virtual PiecesType PiecesType { get; set; } = null!;
        public virtual WeightType WeightType { get; set; } = null!;
    }
}
