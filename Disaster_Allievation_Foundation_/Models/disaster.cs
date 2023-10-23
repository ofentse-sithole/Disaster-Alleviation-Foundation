using System.ComponentModel.DataAnnotations;

namespace Disaster_Allievation_Foundation_.Models
{
    public class disaster
    {
        [Key]

        public int Disaster_ID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public String Location { get; set; }

        public String Description { get; set; }

        public String RequiredAid { get; set; }
    }
}
