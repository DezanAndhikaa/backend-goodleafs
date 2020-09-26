using System;

namespace Application.Common.Dtos {
    public class OrderCustomerDto {
        public Guid IdProducts { get; set; }
        public int TotalProducts { get; set; }
    }
}