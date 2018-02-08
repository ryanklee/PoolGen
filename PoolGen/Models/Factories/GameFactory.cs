﻿using Combinatorics.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Models.Factories
{
    public class GameFactory
    {
        public List<Pool> Create(List<Pool> pools)
        {
            var gameId = 0;
            foreach (var pool in pools)
            {
                pool.Games = new List<Game>();
                var games = new Combinations<Team>(pool.Teams.ToArray(), 2);

                foreach (var game in games)
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
            return pools;
        }
    }
}