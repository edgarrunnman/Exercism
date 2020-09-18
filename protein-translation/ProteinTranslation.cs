using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{
    private static Dictionary<string, string[]> proteins = new Dictionary<string, string[]>
    {
        {"Methionine", new string[]{"AUG"}},
        {"Phenylalanine", new string[]{"UUU", "UUC"}},
        {"Leucine", new string[]{"UUA", "UUG"}},
        {"Serine", new string[]{"UCU", "UCC", "UCA", "UCG"}},
        {"Tyrosine", new string[]{"UAU", "UAC"}},
        {"Cysteine", new string[]{"UGU", "UGC"}},
        {"Tryptophan", new string[]{"UGG"}},
        {"STOP", new string[]{"UAA", "UAG", "UGA"}}
    };
    public static string[] Proteins(string strand)
    {
        string[] codons = CodonGenerator(strand);
        List<string> returnProteins = new List<string>();
        foreach (var codon in codons)
            foreach (var key in proteins.Keys)
                if (proteins[key].Contains(codon) && key != "STOP")
                    returnProteins.Add(key);
                else if (proteins[key].Contains(codon) && key == "STOP")
                    return returnProteins.ToArray();
        return returnProteins.ToArray();
    }
    private static string[] CodonGenerator(string strand)
    {
        string[] returnCodons = new string[strand.Length / 3];
        for (int i = 0; i < strand.Length - 2; i += 3)
            returnCodons[i/3] = strand[i].ToString() + strand[i + 1] + strand[i + 2];
        return returnCodons;
    }
}