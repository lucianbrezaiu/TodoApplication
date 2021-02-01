using ToDoList.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Data
{
    public class Context : DbContext
    {
		public DbSet<Note> Notes { get; set; }

		public Context(DbContextOptions<Context> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
		}

		public void ExecuteSql(string sql) => Database.ExecuteSqlRaw(sql);
	}
}
