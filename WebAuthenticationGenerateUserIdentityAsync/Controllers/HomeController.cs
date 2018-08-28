using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace WebAuthenticationGenerateUserIdentityAsync.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var x = User.Identity.Name;
            var identity = (ClaimsIdentity)User.Identity;


            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Name);

            string userclaims = identity.Name.ToString();
            if (((System.Security.Claims.ClaimsIdentity)User.Identity).HasClaim(ClaimTypes.Name, claim.Value))
            {
                ViewBag.Message = "Your application description page.";
                return View();
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}