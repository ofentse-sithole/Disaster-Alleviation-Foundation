using System.ComponentModel.DataAnnotations;

namespace Disaster_Allievation_Foundation_.Models
{
    public class capture_purchase
    {
        [Key]
        public int ID { get; set; }

        public int DisasterID { get; set; }

        public int GoodsDonationID { get; set; }

        public int MonetaryDonationID { get; set; }

        public DateTime PurchaseDate { get; set; }
        
        public int PurchaseAmount { get; set; }

    }
}
