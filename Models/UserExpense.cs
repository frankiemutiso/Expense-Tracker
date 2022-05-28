using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xpense.Models
{
    [Table("user_expenses")]
    public class UserExpense
    {
        [Column("id"), Key]
        public string Id { get; set; }

        [Column("expense_name"), Required]
        public string ExpenseName { get; set; }

        [Column("expense_amount"), Required]
        public int ExpenseAmount { get; set; }

        [Column("date_created")]
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.UtcNow;

        [Column("category_id"), ForeignKey("ExpenseCategory")]
        public string CategoryId { get; set; }
    }
}