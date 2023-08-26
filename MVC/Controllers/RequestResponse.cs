using Business.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MVC.Controllers
{
    public class RequestResponse : Controller
    {
        private readonly ProductServiceBase _productService;

        public RequestResponse(ProductServiceBase productService)
        {
            _productService = productService;
        }

        //  /requestresponse/getresponse?isplain = true&redirect=http://microsoft.com
        public IActionResult GetResponse(bool isPlain, string redirect)
        {
            if (string.IsNullOrWhiteSpace(redirect))
            {
                if (isPlain)
                    return Content("Response returned.", "text/plain", Encoding.UTF8); // return Content("Response returned.");
                                                                                       //return Content("<b>Response returned.</b>", "text/html", Encoding.UTF8);
                return View("Response", "Response returned.");
                //return View();
            }
            else
            {
                return Redirect(redirect);
            }
        }

        //  /requestresponse/getresp?xml=true
        public IActionResult GetResp(bool xml)
        {
            var list = _productService.Query().ToList();
            if (!xml)
                return Json(list);

            string xmlResult = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            xmlResult += "<products>";
            foreach (var item in list)
            {
                xmlResult += "<product>";
                xmlResult += $"<id>{item.Id}</id>";
                xmlResult += $"<name>{item.Name}</name>";
                xmlResult += $"<category>{item.Category.Name}</category>";
                xmlResult += "</product>";
            }
            xmlResult += "</products>";
            return Content(xmlResult, "application/xml", Encoding.UTF8);
        }


        // /requestresponse/postrequest
        [HttpGet]
        public IActionResult PostRequest()
        {
            return View("Request");
        }

        [HttpPost]
        //public IActionResult PostRequest(string adi, string soyadi)
        public IActionResult PostRequest(Person insan)
        {
            return Content("Adı: " + insan.Adi + ", Soyadı: " + insan.Soyadi);
        }
    }

    public class Person
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
    }
}
