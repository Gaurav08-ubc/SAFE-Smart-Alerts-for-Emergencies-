using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace SAFE.DTO
{
    public class AdminDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
