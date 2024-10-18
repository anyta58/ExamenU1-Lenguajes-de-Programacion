using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenU1.Database.Entities;

// se declara la clase que heredara de IdentityUser, esta se usará en lugar de IdentityUser
//en el context se le colocó el schema y el nombre de tabla

//[Table("users", Schema = "security")]
public class UserEntity : IdentityUser
{
    [Display(Name = "Fecha de ingreso")]
    [Required(ErrorMessage = "La {0} es requerido.")]
    [Column("entry_date")]
    public DateTime EntryDate { get; set; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "El {0} es requerido")]
    [Column("name")]
    public string Name { get; set; }
}
