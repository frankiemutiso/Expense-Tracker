using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xpense.Models
{
    /// <summary>
    /// name of table
    /// </summary>
    [Table("users")]
    public class User
    {
        /// <summary>
        /// primary key 
        /// </summary>
        /// <value></value>
        [Column("id"), Key]
        public Guid Id { get; set; }

        /// <summary>
        /// unique name of user
        /// </summary>
        /// <value></value>
        [Column("username"), Required]
        public string Username { get; set; }

        /// <summary>
        /// email of the user
        /// </summary>
        /// <value></value>
        [Column("email"), Required]
        public string Email { get; set; }

        /// <summary>
        /// password of user
        /// </summary>
        /// <value></value>
        [Column("password"), Required]
        public string Password { get; set; }

        /// <summary>
        /// role of user
        /// </summary>
        /// <value></value>
        [Column("role"), Required]
        public UserRoles Role { get; set; } = UserRoles.User;

        /// <summary>
        /// date joined
        /// </summary>
        /// <value></value>
        [Column("date_joined")]
        public DateTimeOffset DateJoined { get; set; } = DateTimeOffset.UtcNow;
    }

    public enum UserRoles
    {
        Admin,
        User
    }
}