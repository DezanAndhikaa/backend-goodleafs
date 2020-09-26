using System;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Common.Dtos {
    public class CourierDto : IMapFrom<Courier> {

        public Guid IdCourier { get; set; }
        public string CourierName { get; set; }
        public string CourierPhoneNumber { get; set; }

        /// <summary>
        /// Courier status, 0 = Waiting Order, 1 = On Order
        /// </summary>
        /// <value></value>
        public int CourierStatus { get; set; }
        public string CourierPlateNumber { get; set; }
        public string CourierArea { get; set; }

    }
}