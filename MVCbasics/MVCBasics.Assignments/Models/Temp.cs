using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCBasics.Assignments.Models {
    public class Temp {

        [Required(ErrorMessage = "A value is required")]
        [Range(20, 110, ErrorMessage = "Valid range is 20 to 110")]
        public int Temperature { get; set; }

        [Required(ErrorMessage = "scale selection is required")]
        public string Scale { get; set; }

        public Temp() {}
    }
}