using Laba4MPIS.Models.Tables;
using Laba4MPIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FrontLaba.Models;

namespace Laba4MPIS.Controllers
{
    public class PriceController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ILogger<WeatherForecastController> _logger;

        public PriceController(ILogger<WeatherForecastController> logger, DbContextOptions<AppDbContext> db)
        {
            _logger = logger;
            _db = new AppDbContext(db);
        }

        public IActionResult GetAll()
        {
            var prices = _db.Price.ToList();
            var pricesDtos = new List<PriceDto>();
            foreach(var price in prices)
            {
                var priceDto = new PriceDto
                {
                    GoodId = price.Id,
                    price = price.price,
                    PriceAudits = _db.PriceAudits.Where(x => x.GoodId == price.Id).ToList()
                };
                pricesDtos.Add(priceDto);
            }
            return View(pricesDtos);
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

        public IActionResult Update(int id, int price)
        {
            var itemBase = _db.Price.FirstOrDefault(x => x.Id == id);
            if (itemBase == null) return View();
            itemBase.price = price;
            _db.Price.Update(itemBase);
            _db.SaveChanges();
            return View();
        }

    }
}
