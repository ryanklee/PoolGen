using PoolGen.Interfaces;
using PoolGen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Components
{
    public class PoolGenerator : IPoolGenerator
    {
        public List<Pool> GeneratePools(int numOfPools, int numOfTeams, int numOfRounds)
        {
            ValidateArgs(numOfPools, numOfTeams, numOfRounds);
            var pools = new List<Pool>();
            CreatePoolObjects(numOfPools, pools);
            CreateTeamObjects(numOfTeams, pools);
            AssignSnakeSeedTeamNames(numOfTeams, pools);
    
            return pools;
        }

        private void AssignSnakeSeedTeamNames(int numOfTeams, List<Pool> pools)
        {
            var teamCounter = 1;
            var passes = 0;

            while (teamCounter <= numOfTeams)
            {
                for (int j = 0; j < pools.Count && teamCounter <= numOfTeams; j++)
                {
                    if (passes < pools[j].Teams.Count)
                    {
                        pools[j].Teams[passes].Name = "Team " + teamCounter.ToString();
                        teamCounter++;
                    }
                }
                passes++;

                for (int k = pools.Count - 1; k >= 0 && teamCounter <= numOfTeams; k--)
                {
                    if (passes < pools[k].Teams.Count)
                    {
                        pools[k].Teams[passes].Name = "Team " + teamCounter.ToString();
                        teamCounter++;
                    }
                }
                passes++;
            }
        }

        private void CreatePoolObjects(int numOfPools, List<Pool> pools)
        {
            for (int i = 0; i < numOfPools; i++)
            {
                pools.Add(new Pool() { Name = "Pool " + GetLetter(i) });
            }
        }

        private string GetLetter(int i)
        {
            return Convert.ToChar(i + 65).ToString();
        }

        private void CreateTeamObjects(int numOfTeams, List<Pool> pools)
        {
            var numTeamsPerPool = numOfTeams / pools.Count;
            var overFlow = numOfTeams % pools.Count;

            foreach (var pool in pools)
            {
                pool.Teams = new List<Team>();
                for (int i = 0; i < numTeamsPerPool; i++)
                {
                    pool.Teams.Add(new Team());
                }
            }

            if (overFlow != 0)
            {
                for (int i = 0; i < overFlow; i++)
                {
                    pools[pools.Count - 1 - i].Teams.Add(new Team());
                }
            }
        }

        private static void ValidateArgs(int numOfPools, int numOfTeams, int numOfRounds)
        {
            if (numOfPools == 0 ||
                numOfTeams < 2 ||
                numOfRounds < 1 ||
                numOfTeams < numOfPools * 2)
            {
                throw new ArgumentException("Incorrect argument");
            }
        }

        
    }
}
