using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL
{
    [Table("SSUser")]
    public class SSUser : IdentityUser
    {
        [Required]
        public DateTime DOB { get; set; }
        public String? ProfilePicPath { get; set; }
        public IEnumerable<Story>? Stories { get; set; }
    }
}
