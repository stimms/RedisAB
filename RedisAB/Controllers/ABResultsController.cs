using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookSleeve;
using System.Threading.Tasks;

namespace RedisAB.Controllers
{
    public class ABResultsController : Controller
    {
        //
        // GET: /ABResults/
        public async Task<ActionResult> Index()
        {
            using (var conn = new RedisConnection("localhost"))
            {
                await conn.Open();
                return View(await conn.Keys.Find(0, "*"));
            }
            
        }
    }
}