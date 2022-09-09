using System;
using System.Collections.Generic;

namespace BorusanCase.Models
{
    public partial class PiecesType
    {
        public PiecesType()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
