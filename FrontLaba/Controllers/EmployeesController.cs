using Laba4MPIS.Models.Tables;
using Laba4MPIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laba4MPIS.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ILogger<WeatherForecastController> _logger;

        public EmployeesController(ILogger<WeatherForecastController> logger, DbContextOptions<AppDbContext> db)
        {
            _logger = logger;
            _db = new AppDbContext(db);
        }

        public IActionResult GetAll(string? department)
        {
            if (department == null) return View(_db.Employees.ToList());
            return View(Procedur2(department));
        }


        public Employees Create(Employees newItem)
        {
            _db.Employees.Add(newItem);
            _db.SaveChanges();
            return newItem;
        }

        public List<Employees> Delete(string name)
        {
            return Procedur3(name);
        }

        public List<Employees> Update(string departmentName, int salary)
        {
            return Procedur1(departmentName, salary);
        }

        private List<Employees> Procedur1(string departmentName, int salary)
        {
            var itemBase = _db.Employees.Where(x => x.department == departmentName).ToList();
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
