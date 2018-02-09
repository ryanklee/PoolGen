using System.Collections.Generic;

namespace PoolGen.Models
{
    public class Game
    {
        public int Id { get; set; }
        public List<Team> Teams { get; set; }
    }
}
