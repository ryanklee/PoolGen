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
            AssignGames(pools);
            return pools;
        }

        private void AssignGames(List<Pool> pools)
        {

            foreach (var pool in pools)
            {
                var gameList = GetPermutations(pool.Teams, 2);
                var numOfGames = gameList.Count();

                CreateGameObjects(numOfGames, pool);
                HydrateGameObjects(pool, gameList.ToList());
            }
        }

        private static void HydrateGameObjects(Pool pool, List<IEnumerable<Team>> gameList)
        {

        }

        private void CreateGameObjects(int numOfGames, Pool pool)
        {
            pool.Games = new List<Game>();
            for (int i = 0; i < numOfGames; i++)
            {
                pool.Games.Add(new Game() { Teams = new List<Team>() });
            }
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

        IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int count)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (count == 1)
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetPermutations(items.Skip(i + 1), count - 1))
                        yield return new T[] { item }.Concat(result);
                }

                ++i;
            }
        }
    }
}
