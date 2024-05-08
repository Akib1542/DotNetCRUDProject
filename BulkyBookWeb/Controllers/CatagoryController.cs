using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulkyBookWeb.Controllers;

    public class CatagoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CatagoryController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index(string search)
        {
            IEnumerable<Catagory> objCatagoryList = _db.Catagories; //easy peasy
                                                                    //var objCatagoryList = _db.Catagories.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                // Filter the categories based on the search string
                objCatagoryList = objCatagoryList.Where(c => c.Name.Contains(search));
            }

            return View(objCatagoryList);
        }

        //Get Action Method

        public IActionResult Create()
        {
                                                                   
            return View();
        }

         //Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Catagory obj)
        {
            if(obj.Name==obj.DisplayOrder.ToString())
            {
                 ModelState.AddModelError("name","The DisplayOrder cannot exactly match the name!");

            }
            if (ModelState.IsValid)
            {


                _db.Catagories.Add(obj);
                _db.SaveChanges();
            // since we are in the same controller
            // if we needed to redirect to another controller then we should do this "RedirectToAction("Index","ControllerName");"
            // but we need to validate some actions as we know this is a NOTNULL portion so if we put any NULL values then it won't work and send us and exception
            TempData["success"] = "Catagory Created Successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);  

        }

        //GET

        public IActionResult Edit(int? id) { 
        
            if(id==null || id==0)
            {
                return NotFound();
            }

            var catagoryFromDb = _db.Catagories.Find(id);
            //var catagoryFromDbFirst = _db.Catagories.FirstOrDefault(c => c.Id == id);
            //var catagoryFromDbSingle = _db.Catagories.SingleOrDefault(c => c.Id == id);

            if(catagoryFromDb==null)
            {
                return NotFound();
            }
            return View(catagoryFromDb);

        }



    //Post Action Method
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Catagory obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the name!");

        }
        if (ModelState.IsValid)
        {


            _db.Catagories.Update(obj);
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

        var catagoryFromDb = _db.Catagories.Find(id);
        //var catagoryFromDbFirst = _db.Catagories.FirstOrDefault(c => c.Id == id);
        //var catagoryFromDbSingle = _db.Catagories.SingleOrDefault(c => c.Id == id);

        if (catagoryFromDb == null)
        {
            return NotFound();
        }
        return View(catagoryFromDb);

    }



    //Post Action Method
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST (int? id)
    {
            var obj = _db.Catagories.Find(id);
            if(obj == null)
            {
               return NotFound();
            }

            _db.Catagories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Catagory Deleted Successfully!";

            return RedirectToAction("Index");
    }

}

