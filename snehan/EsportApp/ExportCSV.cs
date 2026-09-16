using DataSeries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EsportApp
{
    public static class ExportCSV
    {
        public static void ExportCs2(DataSeries<Cs2Match> matches, string path)
        {
            var header = "date,player,map,start_side,kills,deaths,assists,mvps,won";
            var lines = matches.Values.Select(m =>
                $"{m.TimeStamp:yyyy-MM-dd},{m.Player},{m.Map},{m.StartSide},{m.Kills},{m.Deaths},{m.Assists},{m.Mvps},{m.Won.ToString().ToLower()}"
            );
            File.WriteAllLines(path, lines.Prepend(header));
        }

        public static void ExportValorant(DataSeries<ValorantMatch> matches, string path)
        {
            var header = "date,player,agent,kills,deaths,assists,headshots,rounds_won,won";
            var lines = matches.Values.Select(m =>
                $"{m.TimeStamp:yyyy-MM-dd},{m.Player},{m.Agent},{m.Kills},{m.Deaths},{m.Assists},{m.Headshots},{m.Rounds_won},{m.Won.ToString().ToLower()}"
            );
            File.WriteAllLines(path, lines.Prepend(header));
        }

        public static void ExportLol(DataSeries<LolMatch> matches, string path)
        {
            var header = "date,player,champion,role,kills,deaths,assists,cs,vision_score,won";
            var lines = matches.Values.Select(m =>
                $"{m.TimeStamp:yyyy-MM-dd},{m.Player},{m.Champion},{m.Role},{m.Kills},{m.Deaths},{m.Assists},{m.Cs},{m.VisionScore},{m.Won.ToString().ToLower()}"
            );
            File.WriteAllLines(path, lines.Prepend(header));
        }
    }
}