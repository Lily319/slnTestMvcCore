using Microsoft.AspNetCore.Mvc;
using prjMvcCoreDemo.Models;
using prjMvcCoreDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjMvcCoreDemo.Controllers
{
    public class CustomerController : Controller
    {
        dbDemoContext db = new dbDemoContext();
        public IActionResult List(CKeywordViewModel vModel)
        {
            IEnumerable<TCustomer> list;
            if (string.IsNullOrEmpty(vModel.txtkeyword))
                list = db.TCustomers;
            else
                list = db.TCustomers.Where(t => t.FName.Contains(vModel.txtkeyword) ||
                t.FPhone.Contains(vModel.txtkeyword) ||
                t.FEmail.Contains(vModel.txtkeyword) ||
                t.FAddress.Contains(vModel.txtkeyword));
            return View(list);
        }
    }
}
