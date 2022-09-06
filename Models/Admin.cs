using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Admin
    {
        public string?UserName { get; set; }
        [Key]
        public string? Password { get; set; }
    }
}
