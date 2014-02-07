using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedisAB.Models
{
    public class CampaignResult
    {
        public string Name { get; set; }
        public int Successes { get; set; }
        public int Total { get; set; }
    }
}