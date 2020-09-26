using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public static class Tournament
{   
    static private Dictionary<string, (int mp, int w, int d, int l, int p)> _table;
    public static void Tally(Stream inStream, Stream outStream)
    {
        StreamReader reader = new StreamReader(inStream);
        _table = new Dictionary<string, (int mp, int w, int d, int l, int p)>();
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] inputrows = line.Split("\n");
            foreach (var inputrow in inputrows)
            {
                var columns = inputrow.Split(";");
                switch (columns[2])
                {
                    case "win":
                        RegisterScore(columns[0], "win");
                        RegisterScore(columns[1], "loss");
                        break;
                    case "draw":
                        RegisterScore(columns[0], "draw");
                        RegisterScore(columns[1], "draw");
                        break;
                    case "loss":
                        RegisterScore(columns[0], "loss");
                        RegisterScore(columns[1], "win");
                        break;
                }
            }
        }
        _table = _table.OrderByDescending(x => x.Value.p).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        string outString = $"{"Team",-30} | MP |  W |  D |  L |  P\n";
        foreach (var item in _table)
            outString +=
                $"{item.Key,-30} | " +
                $"{item.Value.mp,2} | " +
                $"{item.Value.w,2} | " +
                $"{item.Value.d,2} | " +
                $"{item.Value.l,2} | " +
                $"{item.Value.p,2}\n";
        outString = outString.Remove(outString.Length - 1);
        using (StreamWriter writer = new StreamWriter(outStream))
            writer.Write(outString);
    }
    private static void RegisterScore(string team, string outcome)
    {
        switch (outcome)
        {
            case "win":
                if (_table.ContainsKey(team))
                    _table[team] = (
                        _table[team].mp + 1,
                        _table[team].w + 1,
                        _table[team].d,
                        _table[team].l,
                        _table[team].p + 3);
                else _table.Add(team, (1, 1, 0, 0, 3));
                break;
            case "draw":
                if (_table.ContainsKey(team))
                    _table[team] = (
                        _table[team].mp + 1,
                        _table[team].w,
                        _table[team].d + 1,
                        _table[team].l,
                        _table[team].p + 1);
                else _table.Add(team, (1, 0, 1, 0, 1));
                break;
            case "loss":
                if (_table.ContainsKey(team))
                    _table[team] = (
                        _table[team].mp + 1,
                        _table[team].w,
                        _table[team].d,
                        _table[team].l + 1,
                        _table[team].p);
                else _table.Add(team, (1, 0, 0, 1, 0));
                break;
        }
    }
}
