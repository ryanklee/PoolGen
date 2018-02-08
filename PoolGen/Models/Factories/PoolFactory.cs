using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Models.Factories
{
    public class PoolFactory
    {
        public List<Pool> Create(int numOfPools)
        {
            var pools = new List<Pool>();
            for (int i = 0; i < numOfPools; i++)
            {
                pools.Add(new Pool() { Name = GetPoolName(i) });
            }

            return pools;
        }
      

        private string GetPoolName(int letterPosition)
        {
            char letter = Convert.ToChar(65 + letterPosition);
            var poolName = "Pool " + letter;
            return poolName;
        }
    }
}
