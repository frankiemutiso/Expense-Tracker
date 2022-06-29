using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xpense.Models
{
    [Table("user_expenses")]
    public class UserExpense
    {
        [Column("id"), Key]
        public Guid Id { get; set; }

        [Column("expense_description"), Required]
        public string ExpenseDescription { get; set; }

        [Column("expense_amount"), Required]
        public int ExpenseAmount { get; set; }

        [Column("date_created")]
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.UtcNow;

        [Column("date_updated")]
        public DateTimeOffset DateUpdated { get; set; } = DateTimeOffset.UtcNow;

        [Column("date_deleted")]
        public DateTimeOffset DateDeleted { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        [Column("category_id")]
        public Guid CategoryId { get; set; }

        [Column("username")]
        public string Username { get; set; }
    }
}