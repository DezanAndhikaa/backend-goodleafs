using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities {
    public class ProductGL {
        public Guid IdProduct { get; set; }
        public string ProductName { get; set; }
        public string VariantName { get; set; }
        public string CategoryName { get; set; }
        public int Cost { get; set; }
        public int ConstAmount { get; set; }
        public string ImageUrl { get; set; }
        public string BaseColor { get; set; }
        public bool IsAvailable { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public bool IsDealoftheDay { get; set; }
    }
}