using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using TextMatch.BL;
using TextMatch.Controllers;
using TextMatch.Models;

namespace TextMatch.Tests.Controllers
{
    [TestFixture]
    class HomeControllerTests
    {
        private HomeController _homeController;
        private Mock<ITextMatcher> _textMatcherMock;

        [SetUp]
        public void Setup()
        {
            _textMatcherMock = new Mock<ITextMatcher>();
            _homeController = new HomeController(_textMatcherMock.Object);
        }

        [TestCase(null, null)]
        [TestCase(null, "valid")]
        [TestCase("valid", null)]
        [TestCase("", "")]
        [TestCase("valid", "")]
        [TestCase("", "valid")]
        [TestCase("   ", "   ")]
        [TestCase("valid", "   ")]
        [TestCase("   ", "valid")]
        public void Post_TextOrSubTextInvalid_ReturnsErrorMessage(string text, string subText)
        {
            var actionResult = _homeController.FindMatches(
                new TextMatcherModel { Text = text, SubText = subText });

            var viewResult = CommonViewAndModelChecks(actionResult);

            var viewModel = (TextMatcherModel)viewResult.Model;
            Assert.That(viewModel.ErrorMessage, Is.EqualTo("Neither the text nor subtext can be null, empty or whitespace."));
        }

        [Test]
        public void Post_SubTextLongerThanText_ThrowsException()
        {
            var text = "A";
            var subText = "AB";

            var actionResult = _homeController.FindMatches(
                new TextMatcherModel { Text = text, SubText = subText });

            var viewResult = CommonViewAndModelChecks(actionResult);

            var viewModel = (TextMatcherModel)viewResult.Model;
            Assert.That(viewModel.ErrorMessage, Is.EqualTo("The subtext cannot be longer than the text."));
        }

        [Test]
        public void Post_ValidInputWithNoMatches_ReturnsEmptyMatches()
        {
            var text = "A";
            var subText = "B";

            _textMatcherMock.Setup(m => m.Matches(text, subText)).Returns(new List<int>());

            var actionResult = _homeController.FindMatches(
                new TextMatcherModel { Text = text, SubText = subText });

            var viewResult = CommonViewAndModelChecks(actionResult);

            var viewModel = (TextMatcherModel) viewResult.Model;
            Assert.False(viewModel.Matches.Any());
        }

        [Test]
        public void Post_ValidInputWithMatches_ReturnsMatches()
        {
            var text = "A";
            var subText = "A";

            _textMatcherMock.Setup(m => m.Matches(text, subText)).Returns(new List<int> { 1 });

            var actionResult = _homeController.FindMatches(
                new TextMatcherModel { Text = text, SubText = subText });

            var viewResult = CommonViewAndModelChecks(actionResult);

            var viewModel = (TextMatcherModel)viewResult.Model;
            Assert.That(viewModel.Matches.Count(), Is.EqualTo(1));
            Assert.That(viewModel.Matches.ElementAt(0), Is.EqualTo(1));
        }
        
        private static ViewResult CommonViewAndModelChecks(ActionResult actionResult)
        {
            Assert.IsInstanceOf<ViewResult>(actionResult);

            var viewResult = (ViewResult) actionResult;
            Assert.That(viewResult.ViewName, Is.EqualTo("Index"));

            Assert.IsInstanceOf<TextMatcherModel>(viewResult.Model);
            return viewResult;
        }
    }
}