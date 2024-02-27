using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServerFinder.Entities;

[Table("tbl_Processors")]
public partial class TblProcessor
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("processorName")]
    [StringLength(50)]
    [Unicode(false)]
    public string ProcessorName { get; set; } = null!;

    [Column("pCores")]
    public int PCores { get; set; }

    [Column("eCores")]
    public int ECores { get; set; }

    [Column("pThreads")]
    public int PThreads { get; set; }

    [Column("eThreads")]
    public int EThreads { get; set; }

    [Column("baseFreq")]
    public int BaseFreq { get; set; }

    [Column("brand")]
    [StringLength(20)]
    [Unicode(false)]
    public string Brand { get; set; } = null!;
    
    
    public string DisplayName => this.Brand + " " + this.ProcessorName;

    [InverseProperty("ProcessorNavigation")]
    public virtual ICollection<TblServer> TblServers { get; set; } = new List<TblServer>();
}
