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
        private SeedMethod _seedMethod;
        private int _numOfPools;
        private int _numOfTeams;

        public PoolGroupBuilder WithPools(int numOfPools)
        {
            _numOfPools = numOfPools;
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
        /// Specify seeding method.        
        /// </summary>
        /// <param name="seedMethod">"snake" for Snake seeding, "seq" for sequential seeding</param>
        /// <returns></returns>
        public PoolGroupBuilder UsingSeed(SeedMethod seedMethod)
        {
            _seedMethod = seedMethod;
            return this;
        }

        public PoolGroup Build()
        {
            CreatePoolObjects();
            CreateTeamObjects();
            return _poolGroup;
        }

        public static implicit operator PoolGroup(PoolGroupBuilder pgb)
        {
            return pgb.Build();
        }

        private void CreatePoolObjects()
        {
            for (int i = 0; i < _numOfPools; i++)
            {
                _poolGroup.Pools.Add(new Pool() { Name = GetPoolName(i)});
            }
        }

        private string GetPoolName(int letterPosition)
        {
            char letter = Convert.ToChar(65 + letterPosition);
            var poolName = "Pool " + letter;
            return poolName;
        }

        private void CreateTeamObjects()
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
                if (_seedMethod == SeedMethod.Snake)
                {
                    _poolGroup.Pools[numOfPools - 1 - i].Teams.Add(new Team());
                }

                if (_seedMethod == SeedMethod.Sequential)
                {
                    _poolGroup.Pools[i].Teams.Add(new Team());
                }
            }
        }
    }
}
