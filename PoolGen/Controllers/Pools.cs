using Microsoft.AspNetCore.Mvc;
using PoolGen.Models;
using PoolGen.Models.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Controllers
{
    [Route("api/pools")]
    public class Pools : Controller
    {
        [HttpGet("snake/{numPools}/{numTeams}/{numRounds}")]
        public JsonResult GetSnakePools(int numPools, int numTeams, int numRounds)
        {
            PoolGroupBuilder pgb = new PoolGroupBuilder();

            var pools = pgb
                .WithPools(numPools)
                .WithTeams(numTeams)
                .WithRounds(numRounds)
                .UsingSeed(SeedMethod.Snake)
                .Build();
            return new JsonResult(pools);
        }

        [HttpGet("seq/{numPools}/{numTeams}/{numRounds}")]
        public JsonResult GetSeqPools(int numPools, int numTeams, int numRounds)
        {
            PoolGroupBuilder pgb = new PoolGroupBuilder();

            var pools = pgb
                .WithPools(numPools)
                .WithTeams(numTeams)
                .WithRounds(numRounds)
                .UsingSeed(SeedMethod.Sequential)
                .Build();
            return new JsonResult(pools);
        }
    }
}
