using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Web_Project.Data;
using Web_Project.Models;

namespace Web_Project.Controllers
{
    public class CategoryController : Controller
    {
       private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            List<Category> ObjectCategoryList = _db.Categories.ToList();   
            return View(ObjectCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        
         {
            if (obj.Name == obj.DesplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The dispaly order cannot exactely match the name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Ctegory created successfully";
            return RedirectToAction("Index");
            }

            return View();
            
        }

        public IActionResult Edit(int? id)
        {
            if (id == null  || id == 0) {
                return  NotFound();
            }
            Category? categoryfromDb = _db.Categories.Find(id);
            if(categoryfromDb == null )
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Ctegory updeted successfully";

                return RedirectToAction("Index");
            }

            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryfromDb = _db.Categories.Find(id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null) 
                {
                return NotFound();
                }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Ctegory deleted successfully";

            return RedirectToAction("Index");
   
        }
    }
}
