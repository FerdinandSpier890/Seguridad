using Microsoft.EntityFrameworkCore;
using Seguridad2.Models;

namespace Seguridad2.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //Declaración de la Tabla Users
        public DbSet<Users>? Users { get; set; }
    }
}
