using PoolGen.Models.Factories;
using PoolGen.Models.Interfaces;
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
        private int _numOfRounds;

        public PoolGroupBuilder WithPools(int numOfPools)
        {
            _numOfPools = numOfPools;
            return this;
        }

        internal void UsingSeed(object sequential)
        {
            throw new NotImplementedException();
        }

        public PoolGroupBuilder WithTeams(int numOfTeams)
        {
            _numOfTeams = numOfTeams;
            return this;
        }

        public PoolGroupBuilder WithRounds(int numOfRounds)
        {
            _numOfRounds = numOfRounds;
            return this;
        }

        public PoolGroupBuilder UsingSeed(SeedMethod seedMethod)
        {
            _seedMethod = seedMethod;
            return this;
        }

        public PoolGroup Build()
        {
            PoolFactory poolFactory = new PoolFactory();
            TeamFactory teamFactory = new TeamFactory();
            GameFactory gameFactory = new GameFactory();

            _poolGroup.Pools = poolFactory.Create(_numOfPools);
            _poolGroup.Pools = teamFactory.Create(_poolGroup.Pools, _numOfTeams, _seedMethod);
            _poolGroup.Pools = gameFactory.Create(_poolGroup.Pools, _numOfRounds);

            return _poolGroup;
        }

        public static implicit operator PoolGroup(PoolGroupBuilder pgb)
        {
            return pgb.Build();
        }

        

        
    }
}
