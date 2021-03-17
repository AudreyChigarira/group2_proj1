using System;
using Microsoft.EntityFrameworkCore;

namespace SignUpGenius.Models
{
    public class SignUpDbContext : DbContext
    {
        public SignUpDbContext(DbContextOptions<SignUpDbContext> options) : base(options)
        {

        }

        public DbSet<FormModel> Form { get; set; }
    }
}
