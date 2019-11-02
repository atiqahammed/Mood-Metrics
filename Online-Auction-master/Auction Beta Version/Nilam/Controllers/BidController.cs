using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dbLayer;
using System.Data.Entity;

namespace Nilam.Controllers
{
    public class BidController : Controller
    {
        AuctionEntities acForBid = new AuctionEntities();
        // GET: Bid
        public ActionResult Index()
        {
            return View();
        }


        //See available product
        public ActionResult availableProducts()
        {
            DateTime currentDataAndTime = DateTime.Now;
            string userNameFromSession1 = Session["userName"].ToString();
            return View(acForBid.productTables.Where(whichOne => whichOne.uploader != userNameFromSession1 && whichOne.endDate> currentDataAndTime && whichOne.startDate<=currentDataAndTime));
        }

        
        //update bid

        public ActionResult updateBid(int productID = 1)
        {
            return View(acForBid.productTables.Find(productID));
        }

        [HttpPost]
        public ActionResult updateBid(productTable upd)
        {
            //upd.biddedPrice = 69;
            //ViewBag.shohan = new SelectList(acForBid.productTables, "productID", "basePrice");
            
            acForBid.Entry(upd).State = EntityState.Modified;
            acForBid.SaveChanges();

            //return returnre("availableProducts");
            //return RedirectToAction("~/Bid/availableProducts");
            //return View("availableProducts");
            return RedirectToAction("ShowBidListForUser", "Product");
        }

    }
}