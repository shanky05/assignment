using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonateKartWebApi
{
    public class Campaign
    {
        public string code { get; set; }
        public string title { get; set; }
        public string featured { get; set; }
        public string priority { get; set; }
        public string shortDesc { get; set; }
        public string ImageSrc { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? EndDate { get; set; }
        public long? TotalAmount { get; set; }
        public long? ProcuredAmount { get; set; }
        public long? TotalProcured { get; set; }
        public long? BackersCount { get; set; }
        public int CategoryId { get; set; }
        public string Location { get; set; }
        public string NgoCode { get; set; }
        public string NgoName { get; set; }
        public int? DaysLeft { get; set; }
        public float? Percentage { get; set; }

    }

    public class CampaignShortData
    {
        public string title { get; set; }
        public DateTime? EndDate { get; set; }
        public long? TotalAmount { get; set; }
        public long? BackersCount { get; set; }

    }
}
