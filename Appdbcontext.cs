using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Minimal_api_net9
{
    public class Todo()
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public bool IsComplete { get; set; }
    };

    public class Appdbcontext(DbContextOptions<Appdbcontext> options) : DbContext(options)
    {
        public DbSet<Todo> Todos { get; set; }
    }
}