using PoolGen.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Models
{
    public class PoolGroupBuilder : IPoolGroupBuilder
    {
        private PoolGroup _poolGroup = new PoolGroup();
        private String _seedMethod = "snake";

        public void Pools(int numOfPools)
        {
            for (int i = 0; i < numOfPools; i++)
            {
                _poolGroup.Pools.Add(new Pool());
            }
        }

        public void Teams(int numOfTeams)
        {
            var numOfPools = _poolGroup.Pools.Count;
            var numTeamsPerPool = numOfTeams / numOfPools;
            var overflow = numOfTeams % numOfPools;

            _poolGroup.Pools.ForEach(pool => pool.Teams = new List<Team>());

            for (int i = 0; i < numTeamsPerPool; i++)
            {
                _poolGroup.Pools.ForEach(pool => pool.Teams.Add(new Team()));

            }

            for (int i = 0; i < overflow; i++)
            {
                if (_seedMethod == "snake")
                {
                    _poolGroup.Pools[numOfPools - 1 - i].Teams.Add(new Team());
                }
            }
        }

        public void Rounds(int numOfRounds)
        {
            throw new NotImplementedException();
        }

        public void UsingSeed(string seedMethod)
        {
            _seedMethod = seedMethod;
        }

        public PoolGroup Build()
        {
            throw new NotImplementedException();
        }
    }
}
