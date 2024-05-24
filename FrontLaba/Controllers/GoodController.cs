using Laba4MPIS.Models;
using Laba4MPIS.Models.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontLaba.Controllers
{
    public class GoodController : Controller
    {
        private readonly AppDbContext _db;

        public GoodController(DbContextOptions<AppDbContext> db)
        {
            _db = new AppDbContext(db);
        }

        public IActionResult GetAll()
        {
           return View(_db.Goods.ToList());
        }

        public IActionResult Create(string name)
        {
            var goods = _db.Goods.ToList();
            int lastId = 0;
            foreach(var good in goods)
            {
                if (lastId < good.Id) lastId = good.Id;
            }
            var newItem = new Goods()
            { 
                Id = lastId == 0 ? 1 : lastId + 1,
                Name = name,
                PriceId = 1,
                IsDeleted = false
            };

            _db.Goods.Add(newItem);
            _db.SaveChanges();
            return View(newItem);
        }

        public IActionResult Delete(int id)
        {
            var item = _db.Goods.FirstOrDefault(x => x.Id == id);
            if (item == null) return null;
            return View(Delete(item));
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