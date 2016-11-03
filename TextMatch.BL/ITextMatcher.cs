using System.Collections.Generic;

namespace TextMatch.BL
{
    public interface ITextMatcher
    {
        IEnumerable<int> Matches(string text, string subText);
    }
}