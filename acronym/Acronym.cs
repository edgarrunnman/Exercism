using System;
using System.Linq;

namespace Acronym
{
    public static class Acronym
    {
        public static string Abbreviate(string phrase)
        {
            var chars = phrase.ToCharArray().ToList();
            chars.Remove('_');
            var index = chars.FindIndex(i => i == '-');
            if (index != -1 )
                chars[index] = ' ';
            return string
                .Join("",string
                    .Join("", chars)
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => c[0]))
                .ToUpper();
        }
    }
}