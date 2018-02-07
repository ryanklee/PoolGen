using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoolGen.Models
{
    public class PoolGroup
    {
        public List<Pool> Pools = new List<Pool>();
    }
}
