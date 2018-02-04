using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Models
{
    public class Game
    {
        public int Id { get; set; }
        public List<Team> Teams { get; set; }
    }
}
