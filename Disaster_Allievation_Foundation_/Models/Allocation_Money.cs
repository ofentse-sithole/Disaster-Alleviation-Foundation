using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disaster_Allievation_Foundation_.Models
{
    public class Allocation_Money
    {
        [Key]
        public int All_MoneyID { get; set; }

        public int Disaster_id { get; set; }

        public int Money_allocate { get; set; }

        public DateTime Allocate_Date { get; set; }

        // Define the relationships with other tables
        //[ForeignKey("DisasterId")]
        //public virtual disaster? disaster { get; set; }


    }
}
