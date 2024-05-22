using Laba4MPIS.Models;
using Laba4MPIS.Models.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laba4MPIS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoodController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ILogger<WeatherForecastController> _logger;

        public GoodController(ILogger<WeatherForecastController> logger, DbContextOptions<AppDbContext> db)
        {
            _logger = logger;
            _db = new AppDbContext(db);
        }

        [HttpGet]
        public List<Goods> Get()
        {
           return _db.Goods.ToList();
        }

        [HttpPost]
        public Goods Create(Goods newItem)
        {
            _db.Goods.Add(newItem);
            _db.SaveChanges();
            return newItem;
        }

        [HttpDelete]
        public Goods? Update(int id)
        {
            var item = _db.Goods.FirstOrDefault(x => x.Id == id);
            if (item == null) return null;
            return Delete(item);
        }

        [HttpPut]
        public Goods Update(Goods item)
        {
            var itemBase = _db.Goods.FirstOrDefault(x => x.Id == item.Id);
            if(itemBase == null) return Create(item);
            _db.Goods.Update(item);
            _db.SaveChanges();
            return item;
        }

        private Goods Delete(Goods good)
        {
            good.IsDeleted = true;
            _db.Goods.Update(good);
            _db.SaveChanges();
            return good;
        }
    }
}