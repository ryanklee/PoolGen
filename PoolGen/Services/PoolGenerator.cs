using PoolGen.Interfaces;
using PoolGen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Services
{
    public class PoolGenerator : IPoolGenerator
    {
        public List<Pool> GeneratePools()
        {
            var pools = new List<Pool>();
            return pools;
        }
    }
}
