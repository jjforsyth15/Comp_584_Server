using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorldModel;

[Table("City")]
public partial class City
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("countryID")]
    public int CountryId { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("latitude")]
    [StringLength(10)]
    [Unicode(false)]
    public string Latitude { get; set; } = null!;

    [Column("longitude")]
    [StringLength(10)]
    [Unicode(false)]
    public string Longitude { get; set; } = null!;

    [ForeignKey("CountryId")]
    [InverseProperty("Cities")]
    public virtual Country Country { get; set; } = null!;
}
