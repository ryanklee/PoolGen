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
        public List<Pool> GeneratePools(int numOfPools, int numOfteams, int numOfRounds)
        {

            var pools = CreatePoolObjects(numOfPools);
            pools = AssignPoolNames(pools);
            
            var teams = CreateTeamObjects(numOfteams);
            teams = AssignTeamNames(teams);



            return pools;
        }

        private List<Team> AssignTeamNames(List<Team> teams)
        {
            teams.ForEach(team => team.Name = "Team " + teams.IndexOf(team));
            return teams;
        }

        private List<Team> CreateTeamObjects(int numOfteams)
        {
            var teams = new List<Team>();
            for (int i = 0; i < numOfteams; i++)
            {
                teams.Add(new Team());
            }
            return teams;
        }

        private List<Pool> CreatePoolObjects(int numOfPools)
        {
            var pools = new List<Pool>();
            for (int i = 0; i < numOfPools; i++)
            {
                pools.Add(new Pool());
            }
            return pools;
        }

        private List<Pool> AssignPoolNames(List<Pool> pools)
        {
            pools.ForEach(pool => pool.Name = "Pool " + GetLetter(pools.IndexOf(pool)));
            return pools;
        }

        private char GetLetter(int numToConvert)
        {
            return Convert.ToChar(numToConvert + 41);
        }
    }
}
