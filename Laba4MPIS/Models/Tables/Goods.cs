namespace Laba4MPIS.Models.Tables
{
    public class Goods
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public int PriceId { get; set; }
        public List<Price> Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}
