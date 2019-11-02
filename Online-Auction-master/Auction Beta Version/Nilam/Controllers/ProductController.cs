using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dbLayer;
using System.Data.Entity;

namespace Nilam.Controllers
{
    public class ProductController : Controller
    {
        AuctionEntities acForproduct = new AuctionEntities();
        AuctionEntities acForBid = new AuctionEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        //upload product
        public ActionResult uploadProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult uploadProduct(productTable pt)
        {
            using (acForproduct)
            {
                acForproduct.productTables.Add(pt);
                acForproduct.SaveChanges();
                return RedirectToAction("ShowListForUser");
                //return RedirectToAction("PORE KORBO");
            }
        }

        //list
        public ActionResult ShowListForUser()
        {
            string userNameFromSession = Session["userName"].ToString();
            return View(acForproduct.productTables.Where(whichOne => whichOne.uploader == userNameFromSession));
            //(acForproduct.productTables.Where(shohan=>shohan.uploader=="Tamim")));
            //string haha = Session["userName"].ToString();
            //var shohna = acForproduct.productTables.Single(us => us.uploader == haha);
            //return View(acForproduct.productTables.Single(us => us.uploader == haha));
        }


        //see your bidded product
        public ActionResult ShowBidListForUser()
        {
            DateTime currentDataAndTime = DateTime.Now;
            string userNameFromSession = Session["userName"].ToString();
            return View(acForproduct.productTables.Where(whichOne => whichOne.bidder == userNameFromSession && whichOne.endDate > currentDataAndTime && whichOne.startDate <= currentDataAndTime));

        }


        //increase bid from bidding list

        //update bid
        public ActionResult updateBidFromProduct(int productID = 1)
        {
            return View(acForBid.productTables.Find(productID));
        }

        [HttpPost]
        public ActionResult updateBidFromProduct(productTable upd)
        {
            //upd.biddedPrice = 69;
            //ViewBag.shohan = new SelectList(acForBid.productTables, "productID", "basePrice");

            acForBid.Entry(upd).State = EntityState.Modified;
            acForBid.SaveChanges();

            //return returnre("availableProducts");
            //return RedirectToAction("~/Bid/availableProducts");
            //return View("availableProducts");
            return RedirectToAction("ShowBidListForUser");
        }



        //Buyer History

        public ActionResult buyerHistory()
        {
            DateTime currentDataAndTime = DateTime.Now;
            return View(acForproduct.productTables.Where(whichOne => whichOne.endDate< currentDataAndTime && whichOne.bidder !=null));
        }


        //Seller History

        public ActionResult sellerHistory()
        {
            DateTime currentDataAndTime = DateTime.Now;
            return View(acForproduct.productTables.Where(whichOne => whichOne.endDate < currentDataAndTime && whichOne.biddedPrice>0));
        }

        
        public ActionResult winningProduct()
        {
            string sessionNameUser = Session["userName"].ToString();
            DateTime currentDataAndTime = DateTime.Now;
            return View(acForproduct.productTables.Where(whichOne => whichOne.endDate < currentDataAndTime && whichOne.bidder != null && whichOne.bidder==sessionNameUser));
        }

    }
}