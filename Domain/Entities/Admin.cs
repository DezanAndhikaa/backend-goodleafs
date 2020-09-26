using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities {
    public class Admin {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}