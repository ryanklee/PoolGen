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
            ValidateArgs(numOfPools, numOfTeams, numOfRounds);

            var pools = new List<Pool>();
            CreatePoolObjects(numOfPools, pools);
            CreateTeamObjects(numOfTeams, pools);
            return pools;
        }

        private void CreateTeamObjects(int numOfTeams, List<Pool> pools)
        {
            var numTeamsPerPool = numOfTeams / pools.Count();

            foreach (var pool in pools)
            {
                pool.Teams = new List<Team>();
                for (int i = 0; i < numTeamsPerPool; i++)
                {
                    pool.Teams.Add(new Team());
                }
            }

            if (pools.Count() % 2 != 0)
            {
                pools.Last().Teams.Add(new Team());
            }
        }

        private void CreatePoolObjects(int numOfPools, List<Pool> pools)
        {
            for (int i = 0; i < numOfPools; i++)
            {
                pools.Add(new Pool());
            }
        }

        private static void ValidateArgs(int numOfPools, int numOfTeams, int numOfRounds)
        {
            if (numOfPools == 0 ||
                numOfTeams < 2 ||
                numOfRounds < 1 ||
                numOfTeams < numOfPools * 2)
            {
                throw new ArgumentException("Incorrect argument");
            }
        }
    }
}
