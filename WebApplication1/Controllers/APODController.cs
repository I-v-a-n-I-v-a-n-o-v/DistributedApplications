using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class APODController : Controller
    {
        // GET: APOD
        //----> NAI - GOLEMITEEEEE!!! <----
        public ActionResult Index()
        {
            ViewData["APOD"] = "Hello world!!!";
            var api_key = "SY9gLxnPM6sUEjGfEe1OYpbcQxJMUBeVYhwkn085";

            var url = "https://api.nasa.gov/planetary/apod?api_key=" + api_key;


            var client = new WebClient();

            var body = "empty";

            body = client.DownloadString(url);

            JObject data = JObject.Parse(body);


            ViewData["Date"] = DateTime.Now.Date;
            ViewData["explanation"] = data["explanation"];

            ViewData["hdurl"] = data["hdurl"];

            ViewData["body"] = body;

            return View();
        }

        public ActionResult HomeWork()
        {

            var name = "ivan";

            var url = "https://api.genderize.io/?name=" + name;


            var client = new WebClient();

            var body = "empty";

            body = client.DownloadString(url);

            JObject data = JObject.Parse(body);


            ViewData["name"] = data["name"];

            ViewData["gender"] = data["gender"];
            ViewData["probability"] = data["probability"];

            ViewData["count"] = data["count"];

            return View();
        }
    }
}