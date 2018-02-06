using System;
using System.Collections.Generic;
using PoolGen.Models;
using PoolGen.Components;
using Xunit;
using System.Linq;

namespace PoolGen.Tests
{
    public class GeneratePoolsTests
    {
        [Fact]
        public void Returns_List_of_Type_Pool()
        {
            PoolGenerator generator = new PoolGenerator();
            var result = generator.GeneratePools(1, 2, 1);
            Assert.IsType<List<Pool>>(result);
        }
        
        [Fact]
        public void PoolList_Contains_AtLeast_Single_Pool()
        {
            PoolGenerator generator = new PoolGenerator();
            var result = generator.GeneratePools(1, 2, 1);
            Assert.IsType<Pool>(result.First());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void PoolList_Contains_Specified_Number_of_Pools(int numOfPools)
        {
            PoolGenerator generator = new PoolGenerator();
            var pools = generator.GeneratePools(numOfPools, 2, 1);
            var expected = numOfPools;
            var actual = pools.Count;
            Assert.Equal(expected, actual);
        }

        
        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 4)]
        public void Pool_Objects_Contain_Correct_Number_of_Teams(int numOfPools, int numOfTeams)
        {
            PoolGenerator generator = new PoolGenerator();
            var pools = generator.GeneratePools(numOfPools, numOfTeams, 1);

            var minTeamsPerPool = numOfTeams / numOfPools;
            bool result = pools.All(pool => pool.Teams.Count() >= minTeamsPerPool);
            Assert.True(result);  
        }
    }
}
