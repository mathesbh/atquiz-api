using Microsoft.EntityFrameworkCore;
using AtQuiz.Models;

namespace AtQuiz.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Answer> Answers { get; set; }

    }
}