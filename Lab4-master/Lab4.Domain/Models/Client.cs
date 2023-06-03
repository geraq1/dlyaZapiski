using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Domain
{

    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public int? PhoneNumber { get; set; }

        public string Address { get; set; }
        

    }
    
}
