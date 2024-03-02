using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServerFinder.Entities;

/// <summary>
/// Base rate is EUR. To convert to any currency first convert to EUR and then to desired
/// </summary>
[Table("tbl_Rates")]
public partial class TblRates
{
    [Key]
    [Column("currency")]
    [StringLength(3)]
    public string Currency { get; set; }

    [Column("rate")]
    public float Rate { get; set; } = 1;
}
