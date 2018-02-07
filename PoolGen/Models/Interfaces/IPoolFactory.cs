using PoolGen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Models.Interfaces
{
    public interface IPoolFactory
    {
        List<Pool> Create();
    }
}
