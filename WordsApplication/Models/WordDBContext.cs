using Microsoft.EntityFrameworkCore;

namespace WordsApplication.Models
{
    public class WordDBContext: DbContext
    {
        public WordDBContext(DbContextOptions<WordDBContext> options)
           : base(options)
        {

        }
        public virtual DbSet<Word> Word { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}