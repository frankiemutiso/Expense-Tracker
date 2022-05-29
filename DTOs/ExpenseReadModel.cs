using System;

namespace Xpense.DTOs
{
    public class ExpenseReadModel
    {
        public Guid Id { get; set; }
        public string ExpenseDescription { get; set; }
        public int ExpenseAmount { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public Guid CategoryId { get; set; }
    }
}