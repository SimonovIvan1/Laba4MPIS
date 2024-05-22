using Laba4MPIS.Models.Tables;
using Laba4MPIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laba4MPIS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ILogger<WeatherForecastController> _logger;

        public UsersController(ILogger<WeatherForecastController> logger, DbContextOptions<AppDbContext> db)
        {
            _logger = logger;
            _db = new AppDbContext(db);
        }

        [HttpGet]
        public List<Users> Get()
        {
            return _db.Users.ToList();
        }

        [HttpPost]
        public Users Create(Users newItem)
        {
            _db.Users.Add(newItem);
            _db.SaveChanges();
            return newItem;
        }

        [HttpDelete]
        public Users? Update(int id)
        {
            var item = _db.Users.FirstOrDefault(x => x.Id == id);
            if (item == null) return null;
            _db.Users.Remove(item);
            return item;
        }

        [HttpPut]
        public Users Update(Users item)
        {
            var itemBase = _db.Users.FirstOrDefault(x => x.Id == item.Id);
            if (itemBase == null) return Create(item);
            _db.Users.Update(item);
            return item;
        }
    }
}
