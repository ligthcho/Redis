using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisTest.Models;

namespace RedisTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
			this.HttpContext.Session.SetString("userid","123456");
			string userid = HttpContext.Session.GetString("userid");
			 return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
		public IActionResult ShowRedis()
		{
			byte[] temp;
			if(HttpContext.Session.TryGetValue("userid",out temp))
			{
				ViewData["Redis"] = Encoding.UTF8.GetString(temp);
			}
			return View();
		}
		public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
