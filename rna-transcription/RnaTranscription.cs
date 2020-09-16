public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        string rnaString = "";
        for (int i = 0; i < nucleotide.Length; i++) 
        { 
            switch (nucleotide[i])
            {
                case 'G':
                    rnaString += "C";
                    break;
                case 'C':
                    rnaString += "G";
                    break;
                case 'T':
                    rnaString += "A";
                    break;
                case 'A':
                    rnaString += "U";
                    break;
                default:
                    break;
            }
        }
        return rnaString;
    }
}