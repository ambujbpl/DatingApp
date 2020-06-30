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
    }
}