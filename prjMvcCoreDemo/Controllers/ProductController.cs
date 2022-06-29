using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjMvcCoreDemo.Models;
using prjMvcCoreDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace prjMvcCoreDemo.Controllers
{
    public class ProductController : Controller
    {
        private IWebHostEnvironment _enviroment;
        public ProductController(IWebHostEnvironment p)
        {
            _enviroment = p;
        }
        dbDemoContext db = new dbDemoContext();
        //public IActionResult List(string txtkeyword)
        //{
        //    IEnumerable<TProduct> list;
        //    if (txtkeyword == null)
        //        list = db.TProducts;
        //    else
        //        list = db.TProducts.Where(t => t.FName.Contains(txtkeyword));
        //    return View(list);
        //}
        public IActionResult List(CKeywordViewModel vModel)
        {
            IEnumerable<TProduct> list;
            if (string.IsNullOrEmpty(vModel.txtkeyword))
                list = db.TProducts;
            else
                list = db.TProducts.Where(t => t.FName.Contains(vModel.txtkeyword));
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TProduct p)
        {
            db.TProducts.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }       
        public IActionResult Delete(int? id)
        {
            TProduct p = db.TProducts.FirstOrDefault(t => t.FId == id);
            if (p != null)
            {
                db.TProducts.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        public IActionResult Edit(int? id)
        {
            TProduct p = db.TProducts.FirstOrDefault(t => t.FId == id);
            if (p == null)
                return RedirectToAction("List");
            return View(p);
        }
        [HttpPost]
        public IActionResult Edit(CProductViewModel p)
        {
            TProduct prod = db.TProducts.FirstOrDefault(t => t.FId == p.FId);
            if (prod != null)
            {
                if (p.photo != null)
                {
                    string pName = Guid.NewGuid().ToString() + ".jpg";
                    p.photo.CopyTo(new FileStream(_enviroment.WebRootPath + "/Images/" + pName, FileMode.Create));
                    prod.FImagePath = pName;
                }
                prod.FName = p.FName;
                prod.FCost = p.FCost;
                prod.FQty = p.FQty;
                prod.FPrice = p.FPrice;
            }
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
