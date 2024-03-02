using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServerFinder.Entities;

[Table("tbl_Servers")]
public partial class TblServer
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("serverName")]
    [StringLength(50)]
    [Unicode(false)]
    public string ServerName { get; set; } = null!;

    [Column("ram")]
    public int Ram { get; set; }

    [Column("isEcc")]
    public bool IsEcc { get; set; }

    [Column("storage")]
    [StringLength(1024)]
    [Unicode(false)]
    public string Storage { get; set; } = "";

    [Column("totalStorage")]
    public int TotalStorage { get; set; }

    [Column("connectionSpeed")]
    public int ConnectionSpeed { get; set; }

    [Column("bandwidth")]
    public int Bandwidth { get; set; }

    [Column("isCustomisable")]
    public bool IsCustomisable { get; set; }

    [Column("link")]
    [StringLength(255)]
    [Unicode(false)]
    public string Link { get; set; } = null!;

    [Column("company")]
    public int Company { get; set; }

    [Column("processor")]
    public int Processor { get; set; }

    [Column("processorCount")]
    public int ProcessorCount { get; set; }

    [Column("price")]
    public decimal Price { get; set; }
    
    /// <summary>
    /// Normalise all other currencies to GBP.
    /// TODO Maybe also normalise to USD, potentially more useful.
    /// </summary>
    [Column("price_gbp")]
    public decimal PriceGbp { get; set; }

    [Column("currency")]
    [StringLength(3)]
    [Unicode(false)]
    public string Currency { get; set; } = null!;

    [ForeignKey("Company")]
    [InverseProperty("TblServers")]
    public virtual TblCompany? CompanyNavigation { get; set; } = null!;

    [ForeignKey("Processor")]
    [InverseProperty("TblServers")]
    public virtual TblProcessor? ProcessorNavigation { get; set; } = null!;
}
