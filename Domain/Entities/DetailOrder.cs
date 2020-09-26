using System;

namespace Domain.Entities {
    public class DetailOrder {
        public Guid IdDetailOrder { get; set; }
        public Guid IdOrder { get; set; }
        public Guid IdProducts { get; set; }
        public int TotalProducts { get; set; }
    }
}