using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenU1.Database.Entities;

public class UserEntity : IdentityUser
{

    //[Column(TypeName = "datetime")]
    //public DateTime EntryDate { get; set; } = DateTime.UtcNow;
    //[Column("gender")] 
    //public string Gender { get; set; }
    [PersonalData]
    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }
}