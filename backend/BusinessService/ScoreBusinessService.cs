using backend.DataService;
using backend.Models;

namespace backend.BusinessService
{
    public class ScoreBusinessService
    {
        private ScoreDataService _scoreDataService;
        public ScoreBusinessService(ScoreDataService scoreDataService)
        {
            _scoreDataService = scoreDataService;
        }

        public List<Score> GetScores()
        {
            return _scoreDataService.GetScores();
        }

        public Score CreateScore(Score score)
        {
            return _scoreDataService.CreateScore(score);
        }
    }
}