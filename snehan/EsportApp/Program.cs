// See https://aka.ms/new-console-template for more information
using DataSeries;
using EsportApp;

ValorantMatch ParseValorant(string[] cols) => new ValorantMatch(
    cols[1],              
    cols[2],              
    int.Parse(cols[3]),   
    int.Parse(cols[4]),   
    int.Parse(cols[5]),   
    int.Parse(cols[6]),   
    int.Parse(cols[7]),   
    bool.Parse(cols[8])   
);

Cs2Match ParseCs2(string[] cols) => new Cs2Match(
    cols[1],              
    cols[2],              
    cols[3],              
    int.Parse(cols[4]),   
    int.Parse(cols[5]),   
    int.Parse(cols[6]),   
    int.Parse(cols[7]),   
    bool.Parse(cols[8])   
);

LolMatch ParseLol(string[] cols) => new LolMatch(
    cols[1],              
    cols[2],              
    int.Parse(cols[4]),   
    int.Parse(cols[5]),   
    int.Parse(cols[6]),   
    int.Parse(cols[7]),   
    int.Parse(cols[8]),   
    bool.Parse(cols[9])   
);

var valorant = DataSeries<ValorantMatch>.FromCsv("data/valorant.csv", ParseValorant);
var cs2 = DataSeries<Cs2Match>.FromCsv("data/cs2.csv", ParseCs2);
var lol = DataSeries<LolMatch>.FromCsv("data/lol.csv", ParseLol);

Console.WriteLine($"Valorant : {valorant.Count} matchs");
Console.WriteLine($"CS2  {cs2.Count} matchs");
Console.WriteLine($"LoL : {lol.Count} matchs");
