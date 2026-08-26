using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportApp
{
    public class ValorantMatch
    {
        public ValorantMatch(string player, string agent, int kills, int deaths, int assits, int headshots, int rounds_won, bool won)
        {
            Player = player;
            Agent = agent;
            Kills = kills;
            Deaths = deaths;
            Assits = assits;
            Headshots = headshots;
            Rounds_won = rounds_won;
            Won = won;
        }

        public string Player { get; }
        public string Agent { get; }
        public int Kills { get; }
        public int Deaths { get; }
        public int Assits { get; }
        public int Headshots { get; }
        public int Rounds_won { get; }
        public bool Won { get; }
    }
}
