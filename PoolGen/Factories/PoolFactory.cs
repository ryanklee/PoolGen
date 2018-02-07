using PoolGen.Models;
using PoolGen.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Factories
{
    public class PoolFactory : IPoolFactory
    {
        public IPools Create()
        {
            IPools pools = new List<Pool>();

           
           
    
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

        

        private string GetLetter(int i)
        {
            return Convert.ToChar(i + 65).ToString();
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
