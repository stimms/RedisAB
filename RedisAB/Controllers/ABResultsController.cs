using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookSleeve;
using System.Threading.Tasks;
using System.Dynamic;
using RedisAB.Models;

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

        public async Task<ActionResult> Details(string keyName)
        {
            var campaignResults = new List<CampaignResult>();
            using (var conn = new RedisConnection("localhost"))
            {
                await conn.Open();

                foreach (var subKey in await GetSubKeys(keyName, conn))
                {
                    campaignResults.Add(new CampaignResult
                    {
                        Name = subKey,
                        Successes = Int32.Parse(await conn.Strings.GetString(0, String.Format("{0}.{1}.success", keyName, subKey))),
                        Total = Int32.Parse(await conn.Strings.GetString(0, String.Format("{0}.{1}", keyName, subKey)))
                    });
                }
                return View(campaignResults);
            }
        }

        private static async Task<IEnumerable<string>> GetSubKeys(string keyName, RedisConnection conn)
        {
            return (await conn.Keys.Find(0, keyName + ".*")).Select(x => x.Split('.').Skip(1).First()).Distinct();
        }
    }
}