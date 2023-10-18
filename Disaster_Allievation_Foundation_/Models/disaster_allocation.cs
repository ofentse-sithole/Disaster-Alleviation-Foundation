using System.ComponentModel.DataAnnotations;

namespace Disaster_Allievation_Foundation_.Models
{
    public class disaster_allocation
    {
        [Key]

        public int Inventory_ID { get; set; }

        public String Allocate_Disaster { get; set; }

        public int Allocate_Money { get; set; }

        public int Purchase_Amount { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
