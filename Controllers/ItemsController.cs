using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EposInventory.DAL;
using EposInventory.Models;

namespace EposInventory.Controllers
{
    public class ItemsController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: Items
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.ProviderNameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DescriptionSortParam = String.IsNullOrEmpty(sortOrder) ? "description_desc" : "Description";
            ViewBag.PricePerUnitSortParam = sortOrder == "PricePerUnit" ? "pricePerUnit_desc" : "PricePerUnit";
            ViewBag.SellingPriceSortParam = sortOrder == "SellingPrice" ? "sellingPrice_desc" : "SellingPrice";
            ViewBag.MarkupSortParam = sortOrder == "Markup" ? "markup_desc" : "Markup";
            ViewBag.StockSortParam = sortOrder == "Stock" ? "stock_desc" : "Stock";
            ViewBag.WarningLevelSortParam = sortOrder == "WarningLevel" ? "warningLevel_desc" : "WarningLevel";

            var items = from item in db.Items
                            select item;

            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(item => item.Description.Contains(searchString) || item.Provider.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    items = items.OrderByDescending(item => item.Provider.Name);
                    break;
                case "Description":
                    items = items.OrderBy(item => item.Description);
                    break;
                case "address_desc":
                    items = items.OrderByDescending(item => item.Description);
                    break;
                case "PricePerUnit":
                    items = items.OrderBy(item => item.PricePerUnit);
                    break;
                case "pricePerUnit_desc":
                    items = items.OrderByDescending(item => item.PricePerUnit);
                    break;
                case "SellingPrice":
                    items = items.OrderBy(item => item.SellingPrice);
                    break;
                case "sellingPrice_desc":
                    items = items.OrderByDescending(item => item.SellingPrice);
                    break;
                case "Markup":
                    items = items.OrderBy(item => item.Markup);
                    break;
                case "markup_desc":
                    items = items.OrderByDescending(item => item.Markup);
                    break;
                case "Stock":
                    items = items.OrderBy(item => item.Stock);
                    break;
                case "stock_desc":
                    items = items.OrderByDescending(item => item.Stock);
                    break;
                case "WarningLevel":
                    items = items.OrderBy(item => item.WarningLevel);
                    break;
                case "warningLevel_desc":
                    items = items.OrderByDescending(item => item.WarningLevel);
                    break;
                default:
                    items = items.OrderBy(item => item.Provider.Name);
                    break;
            }
            return View(items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProviderID,Description,PricePerUnit,SellingPrice,Markup,Stock,WarningLevel")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "Name", item.ProviderID);
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "Name", item.ProviderID);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProviderID,Description,PricePerUnit,SellingPrice,Markup,Stock,WarningLevel")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProviderID = new SelectList(db.Providers, "ID", "Name", item.ProviderID);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
