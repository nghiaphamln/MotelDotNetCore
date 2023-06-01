using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities;

using static String;

[Table("users")]
[Index(nameof(UserId), nameof(UserName), nameof(Email), nameof(PhoneNumber), IsUnique = true)]
public class UserEntity : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("userid")]
    public int UserId { get; set; }

    [Column("username")] public string UserName { get; set; } = Empty;
    [Column("email")] public string Email { get; set; } = Empty;
    [Column("password")] public string Password { get; set; } = Empty;
    [Column("address")] public string Address { get; set; } = Empty;
    [Column("phonenumber")] public string PhoneNumber { get; set; } = Empty;
    [Column("avatar")] public string Avatar { get; set; } = "/image/no-avatar.jpeg";
    [Column("money")] public ulong Money { get; set; }
}