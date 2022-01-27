using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required] 
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range (1900, 2022)]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string Lent_To { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
