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
            _db.Price.Add(newItem);
            _db.SaveChanges();
            return newItem;
        }

        [HttpDelete]
        public Price? Update(int id)
        {
            var item = _db.Price.FirstOrDefault(x => x.Id == id);
            if (item == null) return null;
            _db.Price.Remove(item);
            return item;
        }

        [HttpPut]
        public Price Update(Price item)
        {
            var itemBase = _db.Price.FirstOrDefault(x => x.Id == item.Id);
            if (itemBase == null) return Create(item);
            _db.Price.Update(item);
            return item;
        }
    }
}
