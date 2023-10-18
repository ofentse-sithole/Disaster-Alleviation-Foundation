using System.ComponentModel.DataAnnotations;

namespace Disaster_Allievation_Foundation_.Models
{
    public class monetary_donations
    {
        [Key]

        public int Monetary_ID { get; set; }

        public String Donor { get; set; }

        public DateTime Date { get; set; }

        public int Amount { get; set; }
    }
}
