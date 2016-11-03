using System.Collections.Generic;

namespace TextMatch.Models
{
    public class TextMatcherModel
    {
        public string Text { get; set; }
        public string SubText { get; set; }
        public IEnumerable<int> Matches { get; set; }
        
        public string ErrorMessage { get; set; }
    }
}