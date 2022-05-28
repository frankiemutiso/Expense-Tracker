using Microsoft.EntityFrameworkCore;
using Xpense.Models;

namespace Xpense.Data
{
    public class ExpenseContext : DbContext
    {
        public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<UserExpense> UserExpenses { get; set; }
    }
}