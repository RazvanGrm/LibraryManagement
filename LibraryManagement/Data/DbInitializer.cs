using LibraryManagement.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public class DbInitializer
    {
        public static async Task Seed(IApplicationBuilder applicationBuilder)
        {
            LibraryDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<LibraryDbContext>();

            UserManager<IdentityUser> userManager = applicationBuilder.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

            // Add Lender
            var user = new IdentityUser("Razvan");
            await userManager.CreateAsync(user, "%Razvan");

            // Add Customers
            var eugen = new Customer { Name = "Eugen Cristescu" };

            var andrei = new Customer { Name = "Andrei Cernescu" };

            var daniel = new Customer { Name = "Daniel Popescu" };

            var ciprian = new Customer { Name = "Ciprian Lionte" };

            context.Customers.Add(eugen);
            context.Customers.Add(andrei);
            context.Customers.Add(daniel);
            context.Customers.Add(ciprian);

            // Add Author
            var authorShakespeare = new Author
            {
                Name = "William Shakespeare",
                Books = new List<Book>()
                {
                    new Book { Title = "Hamlet" },
                    new Book { Title = "Othello" }
                }
            };

            var authorAusten = new Author
            {
                Name = "Jane Austen",
                Books = new List<Book>()
                {
                    new Book { Title = "Pride and Prejudice"},
                    new Book { Title = "Persuasion "},
                    new Book { Title = "Sense and Sensibility"}
                }
            };

            var authorTracy = new Author
            {
                Name = "Brian Tracy",
                Books = new List<Book>()
                {
                    new Book { Title = "Master Your Time, Master Your Life"},
                    new Book { Title = "Speak to Win"},
                    new Book { Title = "Many Miles to Go"}
                }
            };

            context.Authors.Add(authorShakespeare);
            context.Authors.Add(authorAusten);
            context.Authors.Add(authorTracy);

            context.SaveChanges();
        }
    }
}
