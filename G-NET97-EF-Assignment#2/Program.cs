using G_NET97_EF_Assignment_2.contexts;
using G_NET97_EF_Assignment_2.models;
using Microsoft.EntityFrameworkCore;

namespace G_NET97_EF_Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new EventHubDbContext();
             context.Database.MigrateAsync();

            



    }
    }
}
