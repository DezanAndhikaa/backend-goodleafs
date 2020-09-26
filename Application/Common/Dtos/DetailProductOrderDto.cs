using System;

namespace Application.Common.Dtos {
    public class DetailProductOrderDto {
        public Guid IdProducts { get; set; }
        public string ProductName { get; set; }
        public int TotalProducts {get;set;}
    }
}