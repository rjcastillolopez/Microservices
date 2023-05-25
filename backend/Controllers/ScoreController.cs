using Microsoft.AspNetCore.Mvc;
using backend.BusinessService;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoreController
    {
        public ScoreBusinessService _scoreBusinessService;
        public ScoreController(ScoreBusinessService scoreBusinessService)
        {
            _scoreBusinessService = scoreBusinessService;
        }

        [HttpGet("[action]")]
        public List<Score> GetScores()
        {
            return _scoreBusinessService.GetScores();
        }

        [HttpPost("[action]")]
        public Score CreateScore(Score score)
        {
            return _scoreBusinessService.CreateScore(score);
        }
    }
}