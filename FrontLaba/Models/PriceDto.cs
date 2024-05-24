using Laba4MPIS.Models.Tables;

namespace FrontLaba.Models
{
    public class PriceDto
    {
        public int GoodId { get; set; }
        public int price { get; set; }
        public List<PriceAudit> PriceAudits { get; set;}
    }
}
