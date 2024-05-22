using System.ComponentModel.DataAnnotations.Schema;

namespace Laba4MPIS.Models.Tables
{
    public class Price
    {
        [Column("id")]
        public int Id { get; set; }
        public int price { get; set; }

    }
}
