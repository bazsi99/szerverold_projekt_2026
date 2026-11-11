using System;
using System.Collections.Generic;
using System.Text;

namespace projektus2.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }
        public int PreptimeMin { get; set; }
        public int Servings {  get; set; }

    }
}
