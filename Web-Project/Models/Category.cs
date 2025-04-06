using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web_Project.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Dispaly Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage ="Despaly order must be between 1-100")]
        public  int DesplayOrder { get; set; }
    }
}
