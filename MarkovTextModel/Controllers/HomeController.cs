using Markov;
using MarkovTextModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarkovTextModel.Controllers
{
    [ApiController]
    [Route("api")]
    public class HomeController : ControllerBase
    {
        private readonly MarkovChain<string> _markovChain;

        public HomeController(MarkovChain<string> markovChain)
        {
            _markovChain = markovChain;
        }

        /// <summary>
        /// Generates a new review with a random rating value from 1 to 5.
        /// </summary>
        /// <returns>New Amazon Review with random rating.</returns>
        [HttpGet("generate")]
        public ActionResult<GeneratedReview> Generate()
        {
            Random rand = new Random();
            string sentence = string.Join(" ", _markovChain.Chain(rand));

            int randomRating = rand.Next(1, 5);

            return new GeneratedReview()
            {
                Text = sentence,
                Rating = randomRating
            };
        }
    }
}
