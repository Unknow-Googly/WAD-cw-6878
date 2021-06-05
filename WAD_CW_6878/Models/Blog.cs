using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WAD_CW_6878.Models
{
    public class Blog
    {

        public int BlogId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public User User { get; set; }
    }
}
