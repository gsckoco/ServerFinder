using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServerFinder.Entities;

[Table("tbl_Company")]
public partial class TblCompany
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("companyName")]
    [StringLength(50)]
    [Unicode(false)]
    public string CompanyName { get; set; } = null!;

    [Column("website")]
    [StringLength(255)]
    [Unicode(false)]
    public string Website { get; set; } = null!;

    [InverseProperty("CompanyNavigation")]
    public virtual ICollection<TblServer> TblServers { get; set; } = new List<TblServer>();
}
