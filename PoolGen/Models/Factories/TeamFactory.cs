using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Models.Factories
{
    public class TeamFactory
    {
        private int _numOfTeams;

        public List<Pool> Create(List<Pool> pools, int numOfTeams, SeedMethod seedMethod)
        {
            _numOfTeams = numOfTeams;
            pools = CreateEmptyTeamLists(pools);
            pools = PopulateTeamLists(pools, seedMethod);
            return pools;
        }

        private List<Pool> CreateEmptyTeamLists(List<Pool> pools)
        {
            pools.ForEach(pool => pool.Teams = new List<Team>());
            return pools;
        }

        private List<Pool> PopulateTeamLists(List<Pool> pools, SeedMethod seedMethod)
        {
            var numOfPools = pools.Count;
            var numTeamsPerPool = _numOfTeams / numOfPools;
            var overflow = _numOfTeams % numOfPools;

            for (int i = 0; i < numTeamsPerPool; i++)
            {
                pools.ForEach(pool => pool.Teams.Add(new Team()));
            }

            for (int i = 0; i < overflow; i++)
            {
                if (seedMethod == SeedMethod.Snake)
                {
                    pools[numOfPools - 1 - i].Teams.Add(new Team());
                }

                if (seedMethod == SeedMethod.Sequential)
                {
                    pools[i].Teams.Add(new Team());
                }
            }
            return pools;
        }
    }
}
