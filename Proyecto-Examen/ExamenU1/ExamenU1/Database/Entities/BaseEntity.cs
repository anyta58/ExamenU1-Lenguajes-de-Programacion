using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenU1.Database.Entities;

public class BaseEntity
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
}
