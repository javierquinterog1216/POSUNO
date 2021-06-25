﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POSUNO.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
      
        public string Email { get; set; }
      
        public string Password { get; set; }
        public string FullName => $"{FirstName} {LastName}";

    }
}
