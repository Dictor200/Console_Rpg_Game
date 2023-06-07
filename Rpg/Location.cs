using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    class Location
    {
        public string Name { get; set; }
        public List<Monster> Monsters { get; set; }
        public Boss FinalBoss { get; set; }
    }
}
