using Microsoft.EntityFrameworkCore;
using search_data.Configurations;
using search_model;

namespace search_data
{
    public class SearchContext : DbContext
    {
        public SearchContext(DbContextOptions<SearchContext> options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionChoice> QuestionChoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuestionConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuestionChoiceConfiguration).Assembly);
        }
    }
}
