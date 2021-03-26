using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CLModelLayer
{
    public class EmployeeModel
    {
       
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int? Salary { get; set; }

        public int? AddressId { get; set; }
        [Required]
        public string Gender { get; set; }

        public AddressModel Address { get; set; }

    }
}
