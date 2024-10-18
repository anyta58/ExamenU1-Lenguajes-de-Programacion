using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenU1.Database.Entities;

[Table("permission_statuses", Schema = "dbo")]
public class PermissionStatusEntity : BaseEntity
{
    [Display(Name = "Descripcion")]
    [Required(ErrorMessage = "La {0} es requerida")]
    [Column("description")]
    public string Description { get; set; }
}
