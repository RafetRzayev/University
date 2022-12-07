using System.ComponentModel.DataAnnotations;

namespace University.AuthenticationService.Models
{
    public class TokenRequestModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
