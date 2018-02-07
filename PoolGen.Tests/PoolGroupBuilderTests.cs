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
                .WithTeams(expected);

            var actual = poolGroup.Pools.First().Teams.Count;
            Assert.Equal(expected, actual);
        }
    }
}