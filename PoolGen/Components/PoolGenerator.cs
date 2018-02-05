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
            pools = CreatePoolObjects(numOfPools, pools);
            foreach(var pool in pools)
            {
                pool.Teams = new List<Team>
                {
                    new Team(),
                    new Team()
                };
            }
            return pools;
        }

        private List<Pool> CreatePoolObjects(int numOfPools, List<Pool> pools)
        {
            for (int i = 0; i < numOfPools; i++)
            {
                pools.Add(new Pool());
            }
            return pools;
        }
    }
}
