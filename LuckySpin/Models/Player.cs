using System;
using System.ComponentModel.DataAnnotations;

namespace LuckySpin.Models
{
    public class Player
    {
        [Required(ErrorMessage ="Please enter your name in order to play.")]
        public string FirstName { get; set; }

        [Range(1,9, ErrorMessage ="You MUST select a lucky number!")]
        public int Luck { get; set; }
    }
}