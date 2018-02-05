using System;
using System.Collections.Generic;
using PoolGen.Models;
using PoolGen.Components;
using Xunit;

namespace PoolGen.Tests
{
    public class PoolGenTests
    {
        [Fact]
        public void PoolGen_Returns_List_of_Type_Pool()
        {
            PoolGenerator generator = new PoolGenerator();
            var result = generator.GeneratePools(1, 1, 1);
            Assert.IsType<List<Pool>>(result);
        }
    }
}
