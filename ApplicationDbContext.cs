using Day1Csharp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Questionweb.Models;
using System.Collections.Generic;

namespace Questionweb.Controllers.data
{
    

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<QuestionPaper> QuestionPapers { get; set; }
        public DbSet<FeedbackViewModel> Feedbacks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<QuestionPaper>().Ignore(q => q.File);
        }


    }


}
