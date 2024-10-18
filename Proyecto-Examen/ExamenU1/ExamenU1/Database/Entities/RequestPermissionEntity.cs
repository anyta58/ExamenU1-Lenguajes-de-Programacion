using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenU1.Database.Entities;

[Table("requests_permission", Schema = "dbo")]
public class RequestPermissionEntity : BaseEntity
{
    [Display(Name = "Fecha de inicio")]
    [Required(ErrorMessage = "La {0} es requerida.")]
    [Column("start_date")]
    public DateTime StartDate { get; set; }

    [Display(Name = "Fecha de fin")]
    [Required(ErrorMessage = "La {0} es requerida.")]
    [Column("end_date")]
    public DateTime EndDate { get; set; }

    [Display(Name = "Motivo")]
    [Required(ErrorMessage = "El {0} es requerido")]
    [Column("reason")]
    public string Reason { get; set; }

    [Column("user_id")]
    public string UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual UserEntity User { get; set; }

    [Column("type_permit_id")]
    public Guid TypePermitId { get; set; }

    [ForeignKey(nameof(TypePermitId))]
    public virtual TypePermitEntity TypePermit { get; set; }

    [Column("permission_status")]
    public Guid PermissionStatusEntity { get; set; }

    [ForeignKey(nameof(PermissionStatusEntity))]
    public virtual PermissionStatusEntity PermissionStatus { get; set; }
}
