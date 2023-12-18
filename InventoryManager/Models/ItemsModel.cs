using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Models
{
    public class ItemsModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Brand { get; set; }

        public string? Category { get; set; }//footwear, apparel, equipment, bags, misc

        public float Price { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
