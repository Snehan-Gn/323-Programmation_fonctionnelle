using DataSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportApp
{
    public static class ExportCSV
    {
        public static void ExportCs2(DataSeries<Cs2Match> matches, string path)
        {
            var header = "date,player,map,start_side,kills,deaths,assists,mvps,won";
            var lines = matches.DataPoints.Select(dp =>
                $"{dp.Timestamp:yyyy-MM-dd},{dp.Value.Player},{dp.Value.Map},{dp.Value.StartSide},{dp.Value.Kills},{dp.Value.Deaths},{dp.Value.Assists},{dp.Value.Mvps},{dp.Value.Won.ToString().ToLower()}"
            );
            File.WriteAllLines(path, lines.Prepend(header));
        }

        public static void ExportValorant(DataSeries<ValorantMatch> matches, string path)
        {
            var header = "date,player,agent,kills,deaths,assists,headshots,rounds_won,won";
            var lines = matches.DataPoints.Select(dp =>
                $"{dp.Timestamp:yyyy-MM-dd},{dp.Value.Player},{dp.Value.Agent},{dp.Value.Kills},{dp.Value.Deaths},{dp.Value.Assists},{dp.Value.Headshots},{dp.Value.Rounds_won},{dp.Value.Won.ToString().ToLower()}"
            );
            File.WriteAllLines(path, lines.Prepend(header));
        }

        public static void ExportLol(DataSeries<LolMatch> matches, string path)
        {
            var header = "date,player,champion,role,kills,deaths,assists,cs,vision_score,won";
            var lines = matches.DataPoints.Select(dp =>
                $"{dp.Timestamp:yyyy-MM-dd},{dp.Value.Player},{dp.Value.Champion},{dp.Value.Role}, {dp.Value.Kills},{dp.Value.Deaths},{dp.Value.Assists},{dp.Value.Cs},{dp.Value.VisionScore},{dp.Value.Won.ToString().ToLower()}"
            );
            File.WriteAllLines(path, lines.Prepend(header));
        }
    }
}
