using Combinatorics.Collections;
using System.Collections.Generic;

namespace PoolGen.Models.Factories
{
    public class GameFactory
    {
        public List<Pool> Create(List<Pool> pools, int numOfRounds)
        {
            var gameId = 0;
            foreach (var pool in pools)
            {
                pool.Games = new List<Game>();
                var games = new Combinations<Team>(pool.Teams.ToArray(), 2);

                foreach (var game in games)
                {
                    for (int i = 0; i < numOfRounds; i++)
                    {
                        var newGame = new Game();
                        newGame.Teams = new List<Team>();

                        foreach (var team in game)
                        {
                            newGame.Teams.Add(team);
                        }

                        newGame.Id = gameId;
                        pool.Games.Add(newGame);
                        gameId++;
                    }
                }
            }
            return pools;
        }
    }
}
