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
        private String _seedMethod;
        private int _numOfTeams;

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

            _numOfTeams = numOfTeams;

            return this;
        }

        public PoolGroupBuilder WithRounds(int numOfRounds)
        {
            return this;
        }

        /// <summary>
        /// Determine seeding method. Supports snake and sequential seeding.         
        /// </summary>
        /// <param name="seedMethod">"snake" for Snake seeding, "seq" for sequential seeding</param>
        /// <returns></returns>
        public PoolGroupBuilder UsingSeed(string seedMethod)
        {
            _seedMethod = seedMethod;
            return this;
        }

        public PoolGroup Build()
        {
            CreatePools();
            return _poolGroup;
        }

        public static implicit operator PoolGroup(PoolGroupBuilder pgb)
        {
            return pgb.Build();
        }

        private void CreatePools()
        {
            var numOfPools = _poolGroup.Pools.Count;
            var numTeamsPerPool = _numOfTeams / numOfPools;
            var overflow = _numOfTeams % numOfPools;

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

                if (_seedMethod == "seq")
                {
                    _poolGroup.Pools[i].Teams.Add(new Team());
                }
            }
        }
    }
}
