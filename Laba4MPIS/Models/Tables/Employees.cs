using System.ComponentModel.DataAnnotations.Schema;

namespace Laba4MPIS.Models.Tables
{
    [Table("employees")]
    public class Employees
    {
        [Column("id")]
        public int Id { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public int salary { get; set; }
    }
}
