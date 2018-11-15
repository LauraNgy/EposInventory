using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EposInventory.DAL;
using EposInventory.ViewModels;
using System.Web.UI;

namespace EposInventory.Controllers
{
    public class HomeController : Controller
    {
        public InventoryContext db = new InventoryContext();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report()
        {
            IQueryable<LowestStockGroup> itemData = from item in db.Items
                                                    where (item.Stock <= item.WarningLevel)
                                                    orderby item.Stock ascending
                                                    select new LowestStockGroup()
                                                    {
                                                        Description = item.Description,
                                                        ProviderName = item.Provider.Name,
                                                        ProviderPhone = item.Provider.PhoneNumber,
                                                        Stock = item.Stock
                                                    };

            return View(itemData.ToList());
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult PoS()
        {
            IQueryable<POSGroup> itemData = from item in db.Items
                                                    orderby item.Category ascending
                                                    select new POSGroup()
                                                    {
                                                        Description = item.Description,
                                                        Category = item.Category,
                                                        SellingPrice = item.SellingPrice,
                                                        Stock = item.Stock
                                                    };

            return Json(itemData, JsonRequestBehavior.AllowGet);
        }
    }
}