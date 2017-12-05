using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.Assignments.Models {
    public class Fever {

        [Required(ErrorMessage = " a value is required")]
        [Range(20, 50, ErrorMessage = "valid range is 20 to 50")]
        public int Temperature { get; set; }

        public Fever() {}

        public string CheckTemp()
        {
            if(Temperature >= 38)
            {
                return "You have a fever";
            }
            else if(Temperature <= 35)
            {
                return "hypothermia!!!";
            }

            return "you do not have a fever";
        }
    }
}