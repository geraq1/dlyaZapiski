using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Lab4.Domain

{
    public class Service
    {
        [Key]
        public int kod { get; set; }

        public string nazvanie { get; set; }

        public string dlitelnost { get; set; }

        public string opisanie_uslugi { get; set; }

        public string type { get; set; }

        public int? price { get; set; }
        
    }
    
}
