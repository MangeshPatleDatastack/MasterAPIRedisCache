using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RedisService.Models;

[Table("PRODUCTS", Schema = "ERPMASTER")]
public partial class Product
{
    [Key]
    [Column("PRODUCT_ID")]
    [Precision(16)]
    public long ProductId { get; set; }

    [Column("PRODUCT_CODE")]
    [StringLength(200)]
    [Unicode(false)]
    public string ProductCode { get; set; } = null!;

    [Column("NAME")]
    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("GENERIC_NAME")]
    [StringLength(200)]
    [Unicode(false)]
    public string GenericName { get; set; } = null!;

    [Column("PRODUCT_CATEGORY")]
    [StringLength(200)]
    [Unicode(false)]
    public string ProductCategory { get; set; } = null!;

    [Column("SUBDIVISION_ID", TypeName = "NUMBER(38)")]
    public long SubdivisionId { get; set; }

    [Column("PACK_SIZE")]
    [StringLength(200)]
    [Unicode(false)]
    public string? PackSize { get; set; }

    [Column("SCHEDULED")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Scheduled { get; set; }

    [Column("CARTON_SIZE")]
    [Precision(16)]
    public long? CartonSize { get; set; }

    [Column("IS_SAMPLE")]
    [StringLength(10)]
    [Unicode(false)]
    public string? IsSample { get; set; }

    [Column("PACK_QUANTITY")]
    [Precision(16)]
    public long? PackQuantity { get; set; }

    [Column("PACK_TYPE")]
    [StringLength(200)]
    [Unicode(false)]
    public string? PackType { get; set; }

    [Column("HSN_CODE")]
    [StringLength(200)]
    [Unicode(false)]
    public string? HsnCode { get; set; }

    [Column("REMARK")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Remark { get; set; }

    [Column("STATUS")]
    [StringLength(20)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Column("STATUS_CHANGE_DATE")]
    [Precision(6)]
    public DateTime StatusChangeDate { get; set; }

    [Column("TIE_UP_SCHEME", TypeName = "CLOB")]
    public string? TieUpScheme { get; set; }

    [Column("BONUS_SCHEME", TypeName = "CLOB")]
    public string? BonusScheme { get; set; }

    [Column("GST_PERCENTAGE", TypeName = "NUMBER(38)")]
    public decimal? GstPercentage { get; set; }

    [Column("DISCOUNT_PERCENTAGE", TypeName = "NUMBER(38)")]
    public decimal? DiscountPercentage { get; set; }
}
