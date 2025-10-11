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
    public decimal Latitude { get; set; }

    [Column("longitude")]
    public decimal Longitude { get; set; }

    [Column("population")]
    public decimal Population { get; set; }

    [ForeignKey("CountryId")]
    [InverseProperty("Cities")]
    public virtual Country Country { get; set; } = null!;
}
