using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dbLayer;
using System.Data.Entity;

namespace Nilam.Controllers
{
    public class SearchProductController : Controller
    {

        AuctionEntities searchProduct = new AuctionEntities();
        // GET: SearchProduct
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult searchProducts(string SearchBy, string search, string productID)
        {
            ViewBag.categories = new SelectList(searchProduct.productTables, "productID", "productCategory");
            DateTime currentDataAndTime = DateTime.Now;
            string userNameFromSession1 = Session["userName"].ToString();
            if (SearchBy == "Category")
            {
                return View(searchProduct.productTables.Where(x => x.productCategory.StartsWith(search) && x.uploader != userNameFromSession1 && x.endDate> currentDataAndTime && x.startDate <= currentDataAndTime || search == null).ToList());
            }
            else
                return View(searchProduct.productTables.Where(x => x.productName.StartsWith(search) && x.uploader != userNameFromSession1 && x.endDate > currentDataAndTime && x.startDate <= currentDataAndTime || search == null).ToList());


            //if (!string.IsNullOrEmpty(productID))
            //{
            //    int pID = Convert.ToInt32(productID);
            //    return View(searchProduct.productTables.Where(x => x.productID == pID));
            //}

            //return View(searchProduct.productTables.Where(x => x.productName.StartsWith(search) || search == null).ToList());

        }

        // bid from search list

        //update bid
        public ActionResult BidFromSearch(int productID = 1)
        {
            return View(searchProduct.productTables.Find(productID));
        }

        [HttpPost]
        public ActionResult BidFromSearch(productTable upd)
        {
            //upd.biddedPrice = 69;
            //ViewBag.shohan = new SelectList(acForBid.productTables, "productID", "basePrice");

            searchProduct.Entry(upd).State = EntityState.Modified;
            searchProduct.SaveChanges();
            return RedirectToAction("ShowBidListForUser", "Product");
            
        }

    }
}