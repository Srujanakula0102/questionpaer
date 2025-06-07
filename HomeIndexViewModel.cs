using System.Collections.Generic;

namespace Questionweb.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<QuestionPaper> QuestionPapers { get; set; } = new List<QuestionPaper>();
        public FeedbackViewModel Feedback { get; set; } = new FeedbackViewModel();
    }
}