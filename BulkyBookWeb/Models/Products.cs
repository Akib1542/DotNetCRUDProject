using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
