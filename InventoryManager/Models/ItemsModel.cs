using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Models
{
    public class ItemsModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Manufacturer { get; set; }


        public float Price { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
