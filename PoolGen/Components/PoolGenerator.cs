using PoolGen.Interfaces;
using PoolGen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Components
{
    public class PoolGenerator : IPoolGenerator
    {
        public List<Pool> GeneratePools(int numOfpools, int numOfteams, int numOfRounds)
        {
            var pools = new List<Pool>();
            pools.Add(new Pool());
            return pools;
        }
    }
}
