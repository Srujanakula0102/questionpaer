using System.Collections.Generic;

namespace Questionweb.Models
{
    public class AdminIndexViewModel
    {
        public IEnumerable<QuestionPaper> UnapprovedPapers { get; set; } = new List<QuestionPaper>();
        public IEnumerable<QuestionPaper> ApprovedPapers { get; set; } = new List<QuestionPaper>();
        public IEnumerable<FeedbackViewModel> Feedbacks { get; set; } = new List<FeedbackViewModel>();
    }
}
