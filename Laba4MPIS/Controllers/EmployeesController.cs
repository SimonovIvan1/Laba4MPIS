using Laba4MPIS.Models.Tables;
using Laba4MPIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laba4MPIS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ILogger<WeatherForecastController> _logger;

        public EmployeesController(ILogger<WeatherForecastController> logger, DbContextOptions<AppDbContext> db)
        {
            _logger = logger;
            _db = new AppDbContext(db);
        }

        [HttpGet]
        public List<Employees> Get()
        {
            return _db.Employees.ToList();
        }

        [HttpPost]
        public Employees Create(Employees newItem)
        {
            _db.Employees.Add(newItem);
            _db.SaveChanges();
            return newItem;
        }

        [HttpDelete]
        public Employees? Update(int id)
        {
            var item = _db.Employees.FirstOrDefault(x => x.Id == id);
            if (item == null) return null;
            _db.Employees.Remove(item);
            _db.SaveChanges();
            return item;
        }

        [HttpPut]
        public Employees Update(Employees item)
        {
            var itemBase = _db.Goods.FirstOrDefault(x => x.Id == item.Id);
            if (itemBase == null) return Create(item);
            _db.Employees.Update(item);
            _db.SaveChanges();
            return item;
        }
    }
}
