using DataSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportApp
{
    public static class MatchGenerator
    {
        public static DataSeries<Cs2Match> GenerateCs2(string player, int count, int seed = 42)
        {
            var rng = new Random(seed);
            var maps = new[] { "Dust2", "Mirage", "Inferno", "Anubis", "Nuke", "Ancient" };
            var sides = new[] { "CT", "T" };
            var start = new DateTime(2023, 9, 1);

            return DataSeries<Cs2Match>.From(
                Enumerable.Range(1, count)
                    .Select(i => new DataPoint<Cs2Match>(
                        start.AddDays(i),
                        new Cs2Match(player, maps[rng.Next(maps.Length)], sides[rng.Next(2)], rng.Next(0, 50), rng.Next(0, 50), rng.Next(0, 50), rng.Next(0, 12), rng.Next(2) == 0)
                    ))
            );

        }

        public static DataSeries<ValorantMatch> GenerateValorant(string player, int count, int seed = 42)
        {
            var rng = new Random(seed);
            var agents = new[] { "Jett", "Neon", "Yoru", "Omen", "Reyna", "Brimstone" };
            var start = new DateTime(2023, 9, 1);

            return DataSeries<ValorantMatch>.From(
                Enumerable.Range(1, count)
                    .Select(i => new DataPoint<ValorantMatch>(
                        start.AddDays(i),
                        new ValorantMatch(player, agents[rng.Next(agents.Length)], rng.Next(0, 50), rng.Next(0, 50), rng.Next(0, 50), rng.Next(0, 50), rng.Next(0,12), rng.Next(2) == 0)
                    ))
            );

        }

        public static DataSeries<LolMatch> GenerateLol(string player, int count, int seed = 42)
        {
            var rng = new Random(seed);
            var champions = new[] { "Thresh", "Yone", "Yasuo", "Irelia", "Zed", "Sett" };
            var roles = new[] { "Top", "Jungle", "Mid", "ADC", "Support" };
            var start = new DateTime(2023, 9, 1);

            return DataSeries<LolMatch>.From(
                Enumerable.Range(1, count)
                    .Select(i => new DataPoint<LolMatch>(
                        start.AddDays(i),
                        new LolMatch(player, champions[rng.Next(champions.Length)], roles[rng.Next(roles.Length)], rng.Next(0, 50), rng.Next(0, 50), rng.Next(0, 50), rng.Next(0, 300), rng.Next(0,100), rng.Next(2) == 0)
                    ))
            );

        }
    }
}
