﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities {
    public class User {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Birthday { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Hobby { get; set; }
        public DateTime? LastOrder { get; set; }
        public int TotalOrder { get; set; }
        public string ImageUrl { get; set; }

    }
}