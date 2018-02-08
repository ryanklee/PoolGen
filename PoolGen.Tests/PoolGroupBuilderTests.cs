using System;
using System.Collections.Generic;
using PoolGen.Models;
using Xunit;
using System.Linq;
using PoolGen.Models.Builders;

namespace PoolGen.Tests
{
    public class PoolGroupBuilderTests
    {
        [Fact]
        public void Builder_Returns_Pool_Group_of_Requested_Size()
        {
            PoolGroupBuilder builder = new PoolGroupBuilder();

            var expected = 2;
            PoolGroup poolGroup = builder
                .WithPools(expected);

            var actual = poolGroup.Pools.Count();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Builder_Returns_Single_Pool_With_Specified_Number_of_Teams()
        {
            PoolGroupBuilder builder = new PoolGroupBuilder();

            var expected = 5;
            PoolGroup poolGroup = builder
                .WithPools(1)
                .WithTeams(expected)
                .UsingSeed(SeedMethod.Snake);

            var actual = poolGroup.Pools.First().Teams.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Builder_Returns_Two_Pools_with_Even_Num_of_Team()
        {
            PoolGroupBuilder builder = new PoolGroupBuilder();
            PoolGroup poolGroup = builder
                .WithPools(2)
                .WithTeams(4)
                .UsingSeed(SeedMethod.Snake);

            var result = poolGroup.Pools.All(pool => pool.Teams.Count == 2);
            Assert.True(result);
        }

        [Fact]
        public void Builder_Returns_Two_Pools_Distributes_Unequal_Number_of_Teams_Using_Snake_Seed()
        {
            PoolGroupBuilder builder = new PoolGroupBuilder();
            PoolGroup poolGroup = builder
                .WithPools(2)
                .WithTeams(5)
                .UsingSeed(SeedMethod.Snake);

            var IsTwo   = poolGroup.Pools[0].Teams.Count.Equals(2);
            var IsThree = poolGroup.Pools[1].Teams.Count.Equals(3);

            Assert.True(IsTwo && IsThree);
        }

        [Fact]
        public void Builder_Returns_Four_Pools_Distributes_Fourteen_Teams_Using_Snake_Seed()
        {
            PoolGroupBuilder builder = new PoolGroupBuilder();
            PoolGroup poolGroup = builder
                .WithPools(4)
                .WithTeams(14)
                .UsingSeed(SeedMethod.Snake);

            var IsThree = poolGroup.Pools.Take(2).All(pool => pool.Teams.Count == 3);
            var IsFour  = poolGroup.Pools.TakeLast(2).All(pool => pool.Teams.Count == 4);

            Assert.True(IsThree && IsFour);
        }

        [Fact]
        public void Builder_Returns_Four_Pools_Distributes_Fourteen_Teams_Using_Seq_Seed()
        {
            PoolGroupBuilder builder = new PoolGroupBuilder();
            PoolGroup poolGroup = builder
                .WithPools(4)
                .WithTeams(14)
                .UsingSeed(SeedMethod.Sequential);

            var IsFour = poolGroup.Pools.Take(2).All(pool => pool.Teams.Count == 4);
            var IsThree = poolGroup.Pools.TakeLast(2).All(pool => pool.Teams.Count == 3);

            Assert.True(IsFour && IsThree);
        }

        [Fact]
        public void Builder_Returns_Pools_Correctly_Named()
        {
            PoolGroupBuilder builder = new PoolGroupBuilder();
            PoolGroup poolGroup = builder
                .WithPools(4)
                .WithTeams(1)
                .UsingSeed(SeedMethod.Sequential);

            var IsPoolA = poolGroup.Pools[0].Name.Equals("Pool A");
            var IsPoolB = poolGroup.Pools[1].Name.Equals("Pool B");
            var IsPoolC = poolGroup.Pools[2].Name.Equals("Pool C");
            var IsPoolD = poolGroup.Pools[3].Name.Equals("Pool D");

            Assert.True(IsPoolA &&
                        IsPoolB &&
                        IsPoolC &&
                        IsPoolD);
        }
    }
}