using System;
using System.Collections.Generic;
using PoolGen.Models;
using PoolGen.Services;
using Xunit;

namespace PoolGen.Tests
{
    public class PoolGenTests
    {
        [Fact]
        public void PoolGen_Returns_Containing_Single_Game_For_Two_Teams_One_Round()
        {
            PoolGenerator generator = new PoolGenerator();

            var numOfPools = 1;
            var numOfTeams = 2;
            var numOfRounds = 1;

            var team1 = new Team() { Name = "Team 1" };
            var team2 = new Team() { Name = "Team 2" };
            var teams = new List<Team>() { team1, team2 };
            var game1 = new Game() { Id = 1, Teams = teams };
            var pool1 = new Pool() { Name = "Pool A", Games = { game1 }, Teams = teams };

            var expected = new List<Pool>() { pool1 }; 
            var actual = generator.GeneratePools(numOfPools, numOfTeams, numOfRounds);

            Assert.Equal(expected, actual);
        }
    }
}
