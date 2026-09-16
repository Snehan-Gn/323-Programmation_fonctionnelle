
using DataSeries;
using EsportApp;
using System.Linq;

namespace EsportApp
{
    class Program
    {
        static ValorantMatch ParseValorant(string[] cols) => new ValorantMatch(
            DateTime.Parse(cols[0]),
            cols[1],
            cols[2],
            int.Parse(cols[3]),
            int.Parse(cols[4]),
            int.Parse(cols[5]),
            int.Parse(cols[6]),
            int.Parse(cols[7]),
            bool.Parse(cols[8])
        );

        static Cs2Match ParseCs2(string[] cols) => new Cs2Match(
            DateTime.Parse(cols[0]),
            cols[1],
            cols[2],
            cols[3],
            int.Parse(cols[4]),
            int.Parse(cols[5]),
            int.Parse(cols[6]),
            int.Parse(cols[7]),
            bool.Parse(cols[8])
        );

        static LolMatch ParseLol(string[] cols) => new LolMatch(
            DateTime.Parse(cols[0]),
            cols[1],
            cols[2],
            cols[3],
            int.Parse(cols[4]),
            int.Parse(cols[5]),
            int.Parse(cols[6]),
            int.Parse(cols[7]),
            int.Parse(cols[8]),
            bool.Parse(cols[9])
        );

        static void Main(string[] args)
        {
            var valorant = DataSeries<ValorantMatch>.FromCsv("data/valorant.csv", ParseValorant);
            var cs2 = DataSeries<Cs2Match>.FromCsv("data/cs2.csv", ParseCs2);
            var lol = DataSeries<LolMatch>.FromCsv("data/lol.csv", ParseLol);

            var valorantValid = valorant.RemoveOutliers(m =>
                m.Kills >= 0 && m.Kills <= 50 &&
                m.Deaths >= 1 && m.Deaths <= 30 &&
                m.Assists >= 0
            );

            var cs2Valid = cs2.RemoveOutliers(m =>
                m.Kills + m.Assists <= 50 &&
                m.Deaths >= 1
            );

            var lolValid = lol.RemoveOutliers(m =>
                m.Kills <= 10 &&
                m.Deaths >= 1 &&
                m.Assists >= 0 &&
                m.Cs >= 0
            );

            Console.WriteLine($"Valorant : {valorantValid.Count} matchs");
            Console.WriteLine($"CS2  {cs2Valid.Count} matchs");
            Console.WriteLine($"LoL : {lolValid.Count} matchs");
            Console.WriteLine(valorantValid.HasAny(m => m.Kills > 20));
            Console.WriteLine(lolValid.AllMatch(m => m.Deaths >= 1));

            /*
            var raphaelGenerated = MatchGenerator.GenerateCs2("Raphaël", 20);
            var michelGenerated = MatchGenerator.GenerateValorant("Michel", 20);
            var gabrielGenerated = MatchGenerator.GenerateLol("Gabriel", 20);

            Func<Cs2Match, bool> isValid = m =>
                m.Kills + m.Assists <= 50;

            var raphaelValid = raphaelGenerated.Filter(isValid);
            Console.WriteLine($"Avant : {raphaelGenerated.Count}, après : {raphaelValid.Count}");

            ExportCSV.ExportCs2(raphaelValid, "raphael_generated.csv");
            ExportCSV.ExportValorant(michelGenerated, "michel_generated.csv");
            ExportCSV.ExportLol(gabrielGenerated, "gabriel_generated.csv");
            */
        }
    }
}