using PoolGen.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Models.Builders
{
    public class PoolGroupBuilder : IPoolGroupBuilder
    {
        private PoolGroup _poolGroup = new PoolGroup();
        private String _seedMethod = "snake";

        public PoolGroupBuilder WithPools(int numOfPools)
        {
            
            for (int i = 0; i < numOfPools; i++)
            {
                _poolGroup.Pools.Add(new Pool());
            }

            return this;
        }

        public PoolGroupBuilder WithTeams(int numOfTeams)
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
            return this;
        }

        public PoolGroupBuilder WithRounds(int numOfRounds)
        {
            return this;
        }

        public PoolGroupBuilder UsingSeed(string seedMethod)
        {
            _seedMethod = seedMethod;
            return this;
        }

        public PoolGroup Build()
        {
            return _poolGroup;
        }

        public static implicit operator PoolGroup(PoolGroupBuilder pgb)
        {
            return pgb.Build();
        }
    }
}
