using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

public class BaseEntity
{
    [Column("createduser")] public string CreatedUser { get; set; } = "administrator";
    [Column("createddate")] public DateTime CreatedDate { get; set; } = DateTime.Now.ToUniversalTime();
    [Column("updateduser")] public string? UpdatedUser { get; set; }
    [Column("updateddate")] public DateTime? UpdatedDate { get; set; }
    [Column("isdeleted")] public bool IsDeleted { get; set; }
    [Column("isactive")] public bool IsActive { get; set; } = true;
}