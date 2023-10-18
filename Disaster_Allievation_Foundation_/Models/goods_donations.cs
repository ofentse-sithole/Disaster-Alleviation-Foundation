using System.ComponentModel.DataAnnotations;

namespace Disaster_Allievation_Foundation_.Models
{
    public class goods_donations
    {
        [Key]

        public int GoodID { get; set; }

        public String Donor { get; set; }

        public String num_items { get; set; }

        public String category { get; set; }

        public String description { get; set; }

    }
}
