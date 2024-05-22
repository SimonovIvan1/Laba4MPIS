using System.ComponentModel.DataAnnotations.Schema;

namespace Laba4MPIS.Models.Tables
{
    [Table("users")]
    public class Users
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int age { get; set; }    
    }
}
