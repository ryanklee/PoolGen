using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Models.Factories
{
    public class TeamFactory
    {
        private int _numOfTeams;
        private SeedMethod _seedMethod;

        public List<Pool> Create(List<Pool> pools, int numOfTeams, SeedMethod seedMethod)
        {
            _numOfTeams = numOfTeams;
            _seedMethod = seedMethod;
            pools = CreateEmptyTeamLists(pools);
            pools = PopulateTeamLists(pools);
            pools = NameTeams(pools);
            return pools;
        }

        private List<Pool> CreateEmptyTeamLists(List<Pool> pools)
        {
            pools.ForEach(pool => pool.Teams = new List<Team>());
            return pools;
        }

        private List<Pool> PopulateTeamLists(List<Pool> pools)
        {
            var numOfPools = pools.Count;
            var numTeamsPerPool = _numOfTeams / numOfPools;
            var overflow = _numOfTeams % numOfPools;
            var currentRow = 0;

            for (int i = 0; i < numTeamsPerPool; i++)
            {
                pools.ForEach(pool => pool.Teams.Add(new Team()));
                currentRow++;
            }

            for (int i = 0; i < overflow; i++)
            {
                if (_seedMethod == SeedMethod.Snake)
                {
                    if (currentRow % 2 != 0)
                    {
                        pools[numOfPools - 1 - i].Teams.Add(new Team());
                    }
                    else
                    {
                        pools[i].Teams.Add(new Team());
                    }
                }

                if (_seedMethod == SeedMethod.Sequential)
                {
                    pools[i].Teams.Add(new Team());
                }
            }
            return pools;
        }

        private List<Pool> NameTeams(List<Pool> pools)
        {
            var currentTeamNum = 1;
            var currentRow = 0;

            while (currentTeamNum <= _numOfTeams)
            {

                for (int i = 0; i < pools.Count; i++)
                {
                    if (currentTeamNum >= _numOfTeams) break;
                    if (currentRow >= pools[i].Teams.Count) break;
                    pools[i].Teams[currentRow].Name = "Team " + currentTeamNum;
                    currentTeamNum++;
                }
                currentRow++;

                if (_seedMethod == SeedMethod.Snake && currentRow % 2 != 0)
                {
                    for (int i = pools.Count - 1; i >= 0; i--)
                    {
                        if (currentTeamNum >= _numOfTeams) break;
                        if (currentRow > pools[i].Teams.Count) break;
                        pools[i].Teams[currentRow].Name = "Team " + currentTeamNum;
                        currentTeamNum++;
                    }
                    currentRow++;
                }

            }


            return pools;
        }
    }
}
