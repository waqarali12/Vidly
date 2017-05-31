﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        [Required]
        public int NumberInStock { get; set; }
    }
}