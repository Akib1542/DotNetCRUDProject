using BulkyBookWeb.Data;
using BulkyBookWeb.Interfaces;
using BulkyBookWeb.Models;
using BulkyBookWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulkyBookWeb.Controllers;

    public class CatagoryController : Controller
    {
       
        private readonly ICatagory catService;

        #region ctor

        public CatagoryController(ICatagory catService)
        {
            this.catService = catService;

        }
    #endregion

        #region Search

    public async Task<IActionResult> Index(string? search)
        {
       
            var data = await catService.GetCatBySearch(search);
            return View(data);
       
        }
    #endregion


        #region Create Get

    public IActionResult Create()
        {                                              
            return View();
        }
    #endregion

        #region Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Catagory obj)
        {
            if(obj.Name==obj.DisplayOrder.ToString())
            {
                 ModelState.AddModelError("name","The DisplayOrder cannot exactly match the name!");

            }
            if (ModelState.IsValid)
            {

                var data =  await catService.CreateCatagoryAsync(obj);
                
                if(data!=null)
                {
                    TempData["success"] = "Catagory Created Successfully!";
                    return RedirectToAction("Index");
                }

            }
            return View(obj);  

        }
    #endregion


        #region Edit GET
        public async Task<IActionResult> Edit(int id = 0) {

            try
            {
                var data = await catService.GetCatagoryAsync(id);
                return View(data);
            }
            catch
            {
                 return NotFound();
            }

        }
    #endregion


        #region Edit POST
    //Post Action Method
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Catagory obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the name!");

        }
        if (ModelState.IsValid)
        {

            try
            {
                await catService.UpdateCatagoryAsync(obj);
                TempData["success"] = "Catagory Edited Successfully!";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(obj);
            }
           

            return RedirectToAction("Index");
        }
        return View(obj);

    }
    #endregion


        #region Delete GET
    public async Task<IActionResult> Delete(int id=0)
    {

        if (id == null || id == 0)
        {
            return NotFound();
        }

        try
        {
            var data = await catService.GetCatagoryAsync(id);
            return View(data);
        }
        catch(Exception ex)
        {
            return NotFound();
        }

    }
    #endregion

        #region Delete POST

    //Post Action Method
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePOST (int id=0)
    {
            if(id == 0)
            {
               return NotFound();
            }
            try
            {
             
                var data = await catService.DeleteCatagoryAsync(id);
                TempData["success"] = "Catagory Deleted Successfully!";
                return RedirectToAction("Index");
       
            }
            catch(Exception ex)
            {
               return NotFound();
            }
            
    }
    #endregion

}

