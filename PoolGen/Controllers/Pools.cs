using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Controllers
{
    [Route("api/pools")]
    public class Pools : Controller
    {
        [HttpGet()]
        public JsonResult GetPools()
        {
            return new JsonResult(new List<object>()
            {
                new { id=1, Name="Ma"},
                new { id=2, Name="Yo"}
            });
        }

    }
}
