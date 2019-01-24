using LuckySpin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuckySpin.Models
{
    public class Repository
    {
        private List<Spin> playerspins = new List<Spin>();
        public IEnumerable<Spin> PlayerSpins
        {
            get { return playerspins; }
        }

        public void AddSpins(Spin playerspin)
        {
            playerspins.Add(playerspin);
        }
    }
}
