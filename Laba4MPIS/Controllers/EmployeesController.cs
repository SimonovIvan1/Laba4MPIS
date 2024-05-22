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
        public List<Employees> Get(string department)
        {
            return Procedur2(department);
        }

        [HttpPost]
        public Employees Create(Employees newItem)
        {
            _db.Employees.Add(newItem);
            _db.SaveChanges();
            return newItem;
        }

        [HttpDelete]
        public List<Employees> Update(string name)
        {
            return Procedur3(name);
        }

        [HttpPut]
        public List<Employees> Update(string departmentName, int salary)
        {
            var itemBase = _db.Employees.Where(x => x.department == departmentName).ToList();
            return Procedur1(itemBase, salary);
        }

        private List<Employees> Procedur1(List<Employees> itemBase, int salary)
        {
            foreach (var item in itemBase)
            {
                item.salary += salary;
                _db.Employees.Update(item);
                _db.SaveChanges();
            }
            return itemBase;
        }
        private List<Employees> Procedur2(string department)
        {
            return _db.Employees.Where(x => x.department == department).ToList();
        }
        private List<Employees> Procedur3(string name)
        {
            var items = _db.Employees.Where(x => x.name == name).ToList();
            _db.Employees.RemoveRange(items);
            _db.SaveChanges();
            return items;
        }
    }
}
