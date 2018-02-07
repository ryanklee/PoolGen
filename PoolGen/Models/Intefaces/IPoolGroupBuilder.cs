using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Models.Intefaces
{
    public interface IPoolGroupBuilder
    {
        void Teams(int numOfTeams);
        void Rounds(int numOfRounds);
        void UsingSeed(string seedMethod);
        PoolGroup Build();
    }
}
