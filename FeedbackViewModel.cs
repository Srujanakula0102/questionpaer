using System.ComponentModel.DataAnnotations;

namespace Questionweb.Models
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }

        [Required]
        public string? Fname { get; set; }

        
        public string? Description { get; set; }
    }
}