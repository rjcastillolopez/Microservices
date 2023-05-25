using backend.Models;

namespace backend.DataService
{
    public class ScoreDataService
    {
        private Context _context;
        public ScoreDataService(Context context){
            _context = context;
        }

        public List<Score> GetScores(){
            return _context.Scores.ToList();
        }

        public Score CreateScore(Score score){
            _context.Scores.Add(score);
            _context.SaveChanges();
            return score;
        }
    }
}