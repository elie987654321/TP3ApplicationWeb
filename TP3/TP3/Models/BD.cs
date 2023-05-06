using Microsoft.EntityFrameworkCore;

namespace TP3.Models
{
    public class BD : DbContext
    {
        public DbSet<Evaluation> evaluations; 
    }
}
