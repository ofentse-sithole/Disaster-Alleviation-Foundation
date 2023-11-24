using Disaster_Allievation_Foundation_.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disaster_Allievation_Foundation_.Models
{
    public class Allocation_Goods
    {
        [Key]
        public int All_GoodsID { get; set; }

        public int Disaster_ID { get; set; }

        public int GoodsDonation_ID { get; set; }

        public  int Goods_Items { get; set; }

        public DateTime Allocate_Date { get; set; }

        // Define the relationships with other tables
        //[ForeignKey("DisasterId")]
        //public virtual disaster? disaster { get; set; }

    }
}
