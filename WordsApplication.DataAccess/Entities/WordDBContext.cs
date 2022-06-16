using Microsoft.EntityFrameworkCore;

namespace WordsApplication.DataAccess
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