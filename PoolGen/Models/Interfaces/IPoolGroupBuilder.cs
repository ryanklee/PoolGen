using PoolGen.Models.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Models.Interfaces
{
    public interface IPoolGroupBuilder
    {
        PoolGroupBuilder WithPools(int numOfPools);
        PoolGroupBuilder WithTeams(int numOfTeams);
        PoolGroupBuilder WithRounds(int numOfRounds);
        PoolGroupBuilder UsingSeed(SeedMethod seedMethod);
        PoolGroup Build();
    }
}
