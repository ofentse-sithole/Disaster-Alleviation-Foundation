namespace Disaster_Allievation_Foundation_.Models
{
    public class HomeViewModel
    {
        
        public List<disaster> disaster { get; set; }
        public List<Allocation_Goods> Allocation_Goods { get; set; }
        public List<Allocation_Money> Allocation_Money { get; set; }
        public List<monetary_donations> monetary_donations { get; set; }
        public List<goods_donations> goods_donations { get; set; }

        public int monetaryDonations { get; set; }



        public int totalAllocatedMoney { get; set; }

        public int totalMoney { get; set; }
           
        
    }
}

