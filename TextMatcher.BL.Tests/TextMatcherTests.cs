using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TextMatch.BL;

namespace TextMatcher.BL.Tests
{
    [TestFixture]
    class TextMatcherTests
    {
        private ITextMatcher _textMatcher;

        [SetUp]
        public void Setup()
        {
            _textMatcher = new TextMatch.BL.TextMatcher();
        }

        [Test]
        public void Matches_NoMatches_ReturnsEmptyList()
        {
            var matches = _textMatcher.Matches("A", "B");

            Assert.That(matches.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Matches_MatchesExactly_ReturnsList()
        {
            var matches = _textMatcher.Matches("A", "A").ToList();

            Assert.That(matches.Count, Is.EqualTo(1));
            Assert.That(matches[0], Is.EqualTo(1));
        }

        [TestCase("A", "a")]
        [TestCase("a", "A")]
        public void Matches_MatchesIgnoringCase_ReturnsList(string text, string subText)
        {
            var matches = _textMatcher.Matches(text, subText).ToList();

            Assert.That(matches.Count, Is.EqualTo(1));
            Assert.That(matches[0], Is.EqualTo(1));
        }


        [Test]
        public void Matches_MultipleNonOverlappingMatches_ReturnsList()
        {
            var matches = _textMatcher.Matches("aABaaBaaBAa", "AA").ToList();
            
            Assert.That(matches, Is.EquivalentTo(new List<int> {1, 4, 7, 10}));
        }

        [Test]
        public void Matches_MultipleOverlappingMatches_ReturnsList()
        {
            var matches = _textMatcher.Matches("aABaaaaaaBAa", "AA").ToList();

            Assert.That(matches, Is.EquivalentTo(new List<int> { 1, 4, 5, 6, 7, 8, 11 }));
        }
    }
}