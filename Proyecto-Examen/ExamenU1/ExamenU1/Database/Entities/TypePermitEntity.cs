using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenU1.Database.Entities;

[Table("types_permit", Schema = "dbo")]
public class TypePermitEntity : BaseEntity
{
    [Display(Name = "Descripcion")]
    [Required(ErrorMessage = "La {0} es requerida")]
    [Column("description")]
    public string Description { get; set; }
}
