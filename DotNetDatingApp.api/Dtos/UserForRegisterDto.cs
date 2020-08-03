using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetDatingApp.api.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage="You Must specify Password between 4 and 8 charactors")]
        public string password { get; set; }

        [Required]
        public string gender { get; set; }

        [Required]
        public string knownAs { get; set; }

        [Required]
        public DateTime dob { get; set; }

        [Required]
        public string city { get; set; }
        
        [Required]
        public string country { get; set; }

        public DateTime created { get; set; }
        
        public DateTime lastActive { get; set; }

        public UserForRegisterDto() 
        {
            created = DateTime.Now;
            lastActive = DateTime.Now;
        }
    }
}