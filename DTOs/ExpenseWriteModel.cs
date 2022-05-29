using System;

namespace Xpense.DTOs
{
    public class ExpenseWriteModel
    {
        public string ExpenseDescription { get; set; }
        public int ExpenseAmount { get; set; }
        public Guid CategoryId { get; set; }
    }
}