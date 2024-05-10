using BulkyBookWeb.Data;
using Microsoft.AspNetCore.Mvc;
using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }   

        public IActionResult Index()
        {
            IEnumerable<Products>productList=_db.Product;
            return View(productList);
        }

        public IActionResult Create()
        {
            ViewBag.Cats = new SelectList(_db.Catagories, "Id", "Name");

            return View();
        }

        //Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Products obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the name!");

            }
            if (ModelState.IsValid)
            {


                _db.Product.Add(obj);
                _db.SaveChanges();
               
                TempData["success"] = "Catagory Created Successfully!";
                return RedirectToAction("Index");
            }
            ViewBag.Cats = new SelectList(_db.Catagories, "Id", "Name");
            return View(obj);

        }

        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var productFromDb = _db.Product.Find(id);
            //var catagoryFromDbFirst = _db.Catagories.FirstOrDefault(c => c.Id == id);
            //var catagoryFromDbSingle = _db.Catagories.SingleOrDefault(c => c.Id == id);

            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);

        }


        //Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Products obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the name!");

            }
            if (ModelState.IsValid)
            {


                _db.Product.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Catagory Edited Successfully!";

                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //GET

        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var productFromDb = _db.Product.Find(id);
            //var catagoryFromDbFirst = _db.Catagories.FirstOrDefault(c => c.Id == id);
            //var catagoryFromDbSingle = _db.Catagories.SingleOrDefault(c => c.Id == id);

            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);

        }



        //Post Action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Product.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Product.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Catagory Deleted Successfully!";

            return RedirectToAction("Index");
        }

    }
}
