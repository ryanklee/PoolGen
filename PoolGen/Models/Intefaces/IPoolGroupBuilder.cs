﻿using PoolGen.Models.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Models.Intefaces
{
    public interface IPoolGroupBuilder
    {
        PoolGroupBuilder WithPools(int numOfPools);
        PoolGroupBuilder WithTeams(int numOfTeams);
        PoolGroupBuilder WithRounds(int numOfRounds);
        PoolGroupBuilder UsingSeed(string seedMethod);
        PoolGroup Build();
    }
}