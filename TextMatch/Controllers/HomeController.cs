using System.Web.Mvc;
using TextMatch.BL;
using TextMatch.Models;

namespace TextMatch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITextMatcher _textMatcher;

        public HomeController(ITextMatcher textMatcher)
        {
            _textMatcher = textMatcher;
        }

        // GET: Default
        public ActionResult Index()
        {
            var model = new TextMatcherModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult FindMatches(TextMatcherModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Text) || string.IsNullOrWhiteSpace(model.SubText))
            {
                model.ErrorMessage = "Neither the text nor subtext can be null, empty or whitespace.";
            }
            else if (model.SubText.Length > model.Text.Length)
            {
                model.ErrorMessage = "The subtext cannot be longer than the text.";
            }
            else
            {
                model.Matches = _textMatcher.Matches(model.Text, model.SubText);
            }

            return View("Index", model);
        }
    }
}