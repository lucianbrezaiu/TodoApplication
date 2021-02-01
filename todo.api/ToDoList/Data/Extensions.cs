using System.Linq;
using ToDoList.Data.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ToDoList.Data
{
    public static class Extensions
    {
        public static void ConfigureDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<Context>();
            context.Database.EnsureCreated();
            context.ExecuteSql("ALTER DATABASE [todo-list-application] SET ALLOW_SNAPSHOT_ISOLATION ON");

            if (!context.Notes.Any())
            {
                context.Notes.AddRange(new List<Note>{
                    new Note
                    {
                        Title = "Facultate",
                        Description = "Predarea proiectului de dizertatie",
                    },
                    new Note
                    {
                        Title = "Firma",
                        Description = "Curs de devops",
                    },
                    new Note
                    {
                        Title = "Dentist",
                        Description = "Programare saptamana viitoare",
                    },
                    new Note
                    {
                        Title = "Netflix",
                        Description = "Plata abonament",
                    },
                });
                context.SaveChanges();
            }
            
        }
    }
}
