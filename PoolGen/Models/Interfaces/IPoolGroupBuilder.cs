using PoolGen.Models.Builders;

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
