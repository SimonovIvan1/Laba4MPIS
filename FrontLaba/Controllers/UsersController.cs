using Laba4MPIS.Models.Tables;
using Laba4MPIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laba4MPIS.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ILogger<WeatherForecastController> _logger;

        public UsersController(ILogger<WeatherForecastController> logger, DbContextOptions<AppDbContext> db)
        {
            _logger = logger;
            _db = new AppDbContext(db);
        }

        public IActionResult GetAll()
        {
            return View(_db.Users.ToList());
        }

        public IActionResult Create(Users newItem)
        {
            _db.Users.Add(newItem);
            _db.SaveChanges();
            return Redirect("https://localhost:7049/Users/GetAll");
        }

        public IActionResult Delete(int id)
        {
            var item = _db.Users.FirstOrDefault(x => x.Id == id);
            if (item == null) return null;
            _db.Users.Remove(item);
            _db.SaveChanges();
            return Redirect("https://localhost:7049/Users/GetAll");
        }
        /*
        public Users Update(Users item)
        {
            var itemBase = _db.Users.FirstOrDefault(x => x.Id == item.Id);
            if (itemBase == null) return Create(item);
            _db.Users.Update(item);
            _db.SaveChanges();
            return item;
        }*/
    }
}
