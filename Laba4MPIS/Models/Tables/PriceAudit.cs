using System.ComponentModel.DataAnnotations.Schema;

namespace Laba4MPIS.Models.Tables
{
    [Table("price_audits")]
    public class PriceAudit
    {
        [Column("book_id")]
        public int GoodId { get; set; }
        [Column("entry_date")]
        public string Date { get; set; }
    }
}
