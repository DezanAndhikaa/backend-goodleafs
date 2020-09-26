using System;
using System.Collections.Generic;

namespace Application.Common.Dtos {
    public class DetailOrderDataDto {
        public Guid IdOrder { get; set; }
        public string EmailUser { get; set; }
        public DateTime TanggalOrder { get; set; }

        /// <summary>
        /// 0 = Waiting Confirmation
        /// 1 = Processing Order
        /// 2 = Order is on the way
        /// 3 = Order is complete
        /// </summary>
        /// <value></value>
        public int StatusOrder { get; set; }
        public Guid IdCourier { get; set; }
        public string NamaCourier { get; set; }
        public List<DetailProductOrderDto> ListProducts { get; set; }
    }
}