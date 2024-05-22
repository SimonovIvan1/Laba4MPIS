using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laba4MPIS.Models.Tables
{
    [Table("price_audits")]
    public class PriceAudit
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("book_id")]
        public int GoodId { get; set; }
        [Column("entry_date")]
        public string Date { get; set; }
    }
}
