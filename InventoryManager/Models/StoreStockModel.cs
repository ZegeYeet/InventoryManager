using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManager.Models
{
    public class StoreStockModel
    {
        [ForeignKey("Id")]
        public int ItemId { get; set; }

        public int CurrentStock { get; set; }
        [Required]
        public int ReplenishLevel { get; set; }//wwhen current stock is below this then order more
    }
}
