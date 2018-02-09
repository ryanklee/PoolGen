using System.Collections.Generic;

namespace PoolGen.Models
{
    public class Pool
    {
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
        public List<Game> Games { get; set; }
    }
}
