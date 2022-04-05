using Microsoft.AspNetCore.Mvc;
using sample_application.Data;
using sample_application.Models;

namespace sample_application.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly CatagoryContext _db;
        public CatagoryController(CatagoryContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Catagory> ObjCatagory = _db.Catagories;
            return View(ObjCatagory);
        }

        //get
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Catagory obj)
        {
            if(ModelState.IsValid)
            {
                _db.Catagories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //CREATE
        //get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catagoryFromDb = _db.Catagories.Find(id);
            //var categooryFromDbFirst = _db.Catagories.FirstOrDefault(u=>u.Id == id);
            //var categooryFromDbSingle = _db.Catagories.SingleOrDefault(u => u.Id == id);

            if(catagoryFromDb == null)
            {
                return NotFound();
            }
            return View(catagoryFromDb);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Catagory obj)
        {
            if (ModelState.IsValid)
            {
                _db.Catagories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }


        //Delete
        //get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catagoryFromDb = _db.Catagories.Find(id);
            //var categooryFromDbFirst = _db.Catagories.FirstOrDefault(u=>u.Id == id);
            //var categooryFromDbSingle = _db.Catagories.SingleOrDefault(u => u.Id == id);

            if (catagoryFromDb == null)
            {
                return NotFound();
            }
            return View(catagoryFromDb);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Catagory obj)
        {
            if (ModelState.IsValid)
            {
                _db.Catagories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
