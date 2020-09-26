using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities {
    public class Category {
        public Guid IdCategory { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}