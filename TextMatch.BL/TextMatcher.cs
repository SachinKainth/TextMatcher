using System.Collections.Generic;

namespace TextMatch.BL
{
    public class TextMatcher : ITextMatcher
    {
        public IEnumerable<int> Matches(string text, string subText)
        {
            var textLower = text.ToLowerInvariant();
            var subTextLower = subText.ToLowerInvariant();

            var result = new List<int>();

            for (var i = 0; i < textLower.Length; i++)
            {
                if (textLower.Length >= subTextLower.Length + i)
                {
                    string potentialMatch = textLower.Substring(i, subTextLower.Length);
                    if (potentialMatch.Equals(subTextLower))
                    {
                        result.Add(i + 1);
                    }
                }
            }

            return result;
        }
    }
}