using PoolGen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Interfaces
{
    public interface IPoolGenerator
    {
        List<Pool> GeneratePools(int numOfpools, int numOfteams, int numOfRounds);
    }
}
