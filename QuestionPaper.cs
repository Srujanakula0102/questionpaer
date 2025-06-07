using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionweb.Models
{
    public class QuestionPaper
    {
        [Required]
        public int Id { get; set; }
        public string UploaderName { get; set; }
        public string Subject { get; set; }
        public int ?Year { get; set; }
        public string? Group { get; set; }
        public string ?Publicid { get; set; }
        public string ?Url { get; set; }
        public DateTime? Uploadedat { get; set; }

        [NotMapped]
        public IFormFile? File { get; set; }
    
        
        public bool Approved { get; set; }
        public bool IsApproved { get; set; } // New field for approval status


        public string? Fname { get; set; }
        public string? Desciption { get; set; }
    }
    
}
