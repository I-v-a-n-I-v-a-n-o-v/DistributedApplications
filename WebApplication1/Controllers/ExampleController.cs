using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ExampleController : Controller
    {
        // GET: Example
        public ActionResult BGToll(string number)
        {
            ViewData["search"] = number;

            var url = "https://check.bgtoll.bg/check/vignette/plate/BG/" + number;

            var client = new WebClient();

            var body = "empty";

            if (number != null && number != "")
            {
                body = client.DownloadString(url);

                JObject data = JObject.Parse(body);

                if ((bool)data["ok"] == true)
                {
                    ViewData["result"] = "Намерена е винетка за номер " + number;

                    ViewData["vNumber"] = data["vignette"]["vignetteNumber"];
                    ViewData["active"] = data["vignette"]["validityDateToFormated"];
                    ViewData["class"] = data["vignette"]["vehicleClass"];
                }
                else
                {
                    ViewData["result"] = number + " няма активна винетка.";
                }
            }
            ViewData["body"] = body;

            return View();
        }
    }
}