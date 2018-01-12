using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstDB.Models {
    public class Employee {
        
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(100)]
        public string Lastname { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Salary { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0: yyy / MM / dd }")]
        public DateTime HiredDate { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<EmpSupJunction> EmpSupJunctions { get; set; }
    }
}