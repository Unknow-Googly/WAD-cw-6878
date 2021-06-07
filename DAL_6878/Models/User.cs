using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WAD_CW_6878.Models
{
    public class User
    {
        public int UserId { get; set; }
        
        [MinLength(2)]
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DoB { get; set; }
    }
}
