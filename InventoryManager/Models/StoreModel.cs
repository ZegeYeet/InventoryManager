using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Models
{
    public class StoreModel
    {
        [Key]
        public int Id { get; set; }
        //public string? Address { get; set; }
        public virtual ICollection<StoreStockModel>? ProductsCarried{ get; set; }


    }
}
