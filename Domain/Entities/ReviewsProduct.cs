using System;

namespace Domain.Entities {
    public class ReviewsProduct {
        public Guid IdReviews { get; set; }
        public Guid IdProducts { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string EmailUser { get; set; }
    }
}