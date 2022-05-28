using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xpense.Models
{

    /// <summary>
    /// name of the table
    /// </summary>
    [Table("expense_categories")]
    public class ExpenseCategory
    {
        /// <summary>
        /// primary key
        /// </summary>
        /// <value></value>
        [Column("id"), Key]
        public string Id { get; set; }

        /// <summary>
        /// name of the category
        /// </summary>
        /// <value></value>
        [Column("category_name")]
        public string CategoryName { get; set; }

        /// <summary>
        /// date when the category was created
        /// </summary>
        /// <value></value>
        [Column("date_created")]
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>
        /// date when category was updated
        /// </summary>
        /// <value></value>
        [Column("date_updated")]
        public DateTimeOffset DateUpdated { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>
        /// date when category was deleted
        /// </summary>
        /// <value></value>
        [Column("date_deleted")]
        public DateTimeOffset DateDeleted { get; set; }

        /// <summary>
        /// is category deleted?
        /// </summary>
        /// <value></value>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}