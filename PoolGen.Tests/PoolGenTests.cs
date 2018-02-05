using System;
using System.Collections.Generic;
using PoolGen.Models;
using PoolGen.Components;
using Xunit;

namespace PoolGen.Tests
{
    public class GeneratePoolsTests
    {
        [Fact]
        public void Returns_List_of_Type_Pool()
        {
            PoolGenerator generator = new PoolGenerator();
            var result = generator.GeneratePools(1, 1, 1);
            Assert.IsType<List<Pool>>(result);
        }
        
        [Fact]
        public void PoolList_Contains_Single_Pool()
        {
            PoolGenerator generator = new PoolGenerator();
            var result = generator.GeneratePools(1, 1, 1);
            Assert.IsType<Pool>(result[0]);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(0)]
        public void PoolList_Contains_Specified_Number_of_Pools(int numOfPools)
        {
            PoolGenerator generator = new PoolGenerator();
            var pools = generator.GeneratePools(numOfPools, 1, 1);
            var expected = numOfPools;
            var actual = pools.Count;
            Assert.Equal(expected, actual);
        }
        
    }
}
