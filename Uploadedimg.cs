using System.ComponentModel.DataAnnotations;

namespace Day1Csharp.Models
{
    public class Uploadedimg
    {
        [Required]
        public int Id { get; set; }
        public string Publicid { get; set; }
        public string Url { get; set; }
        public DateTime Uploadedat { get; set; }

    }
}
