using Laba4MPIS.Models.Tables;
using Laba4MPIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laba4MPIS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ILogger<WeatherForecastController> _logger;

        public PriceController(ILogger<WeatherForecastController> logger, DbContextOptions<AppDbContext> db)
        {
            _logger = logger;
            _db = new AppDbContext(db);
        }

        [HttpGet]
        public List<Price> Get()
        {
            return _db.Price.ToList();
        }

        [HttpPost]
        public Price Create(Price newItem)
        {
            var priceDb = _db.Price.FirstOrDefault(x => x.Id == newItem.Id);
            if (priceDb == null) _db.Price.Add(newItem);
            else 
            {
                priceDb.price = newItem.price;
                _db.Price.Update(priceDb);
            } 
            _db.SaveChanges();

            var aud = new PriceAudit
            {
                GoodId = newItem.Id,
                Date = DateTime.Now.ToString()
            };
            _db.PriceAudits.Add(aud);
            _db.SaveChanges();
            return newItem;
        }

        [HttpDelete]
        public Price? Update(int id)
        {
            var item = _db.Price.FirstOrDefault(x => x.Id == id);
            if (item == null) return null;
            _db.Price.Remove(item);
            _db.SaveChanges();
            return item;
        }

        [HttpPut]
        public Price Update(Price item)
        {
            var itemBase = _db.Price.FirstOrDefault(x => x.Id == item.Id);
            if (itemBase == null) return Create(item);
            itemBase.price = item.price;
            _db.Price.Update(itemBase);
            _db.SaveChanges();
            return itemBase;
        }

    }
}
