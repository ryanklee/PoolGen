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
        public List<Pool> GeneratePools(int numOfPools, int numOfTeams, int numOfRounds)
        {
            var pools = new List<Pool>();
            for (int i = 0; i < numOfPools; i++)
            {
                pools.Add(new Pool());
            }
            return pools;
        }
    }
}
