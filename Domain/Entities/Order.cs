using System;

namespace Domain.Entities {
    public class Order {
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
    }
}