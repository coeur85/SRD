using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStore.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int RelaseYear { get; set; }
    }
}