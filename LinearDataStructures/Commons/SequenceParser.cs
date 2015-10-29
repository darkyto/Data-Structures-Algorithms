namespace Commons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class SequenceParser
    {
        public static List<int> StringNumberSequenceToList(string input)
        {
            return input.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();
        }

        public static int[] StringNumberSequenceToArray(string input)
        {
            return input.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
        }
    }
}
