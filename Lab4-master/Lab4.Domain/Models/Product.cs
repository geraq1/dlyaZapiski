﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Domain
{
   
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Count { get; set; }

        public decimal? Price { get; set; }

        public decimal? TotalCost { get; set; }
        

    }
    
}

        


