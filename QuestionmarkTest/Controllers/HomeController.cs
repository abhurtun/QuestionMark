using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuestionmarkTest.Models;

namespace QuestionmarkTest.Controllers
{
    public class HomeController : Controller
    {
        //Get: /Home/Index
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to my date difference solution!";

            return View();
        }

        //
        // POST:  /Home/Index
        //calculate the number of days

        [HttpPost]
        public ActionResult Index(DateDiffModel model)
        {
            //check for empty dates being passed
            if (!String.IsNullOrWhiteSpace(model.DateFrom) || !String.IsNullOrWhiteSpace(model.DateFrom))
            {
                //get the to and from dates as int
                // varibale f is the from date
                int f = int.Parse(model.DateFrom.Replace("-", ""));
                //variable t is the to date
                int t = int.Parse(model.DateTo.Replace("-", ""));
                // Test to date should be greater than from date.
                if (t <= f)
                {
                    //shhow error to user
                    ModelState.AddModelError("", "To date should always be greater than from date.");
                }
                else
                {
                    //convert the string dates into integer arrays
                    //using some link code
                    int[] from = model.DateFrom.Split('-').Select(n => Convert.ToInt32(n)).ToArray();
                    int[] to = model.DateTo.Split('-').Select(n => Convert.ToInt32(n)).ToArray();

                    //get the days
                    model.Days = model.GetDays(from, to).ToString();
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //Get: /About
        public ActionResult About()
        {
            return View();
        }



    }
}
