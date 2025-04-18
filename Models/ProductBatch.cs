using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RedisService.Models;

[Table("PRODUCT_BATCHES", Schema = "ERPMASTER")]
public partial class ProductBatch
{
    [Key]
    [Column("PRODUCT_BATCH_ID")]
    [Precision(16)]
    public long ProductBatchId { get; set; }

    [Column("PRODUCT_ID")]
    [Precision(16)]
    public long ProductId { get; set; }

    [Column("COMPANY_ID")]
    [Precision(16)]
    public long CompanyId { get; set; }

    [Column("BATCH_CODE")]
    [StringLength(200)]
    [Unicode(false)]
    public string BatchCode { get; set; } = null!;

    [Column("MANUFACTURE_DATE")]
    [Precision(6)]
    public DateTime ManufactureDate { get; set; }

    [Column("EXPIRY_DATE")]
    [Precision(6)]
    public DateTime ExpiryDate { get; set; }

    [Column("STATUS")]
    [StringLength(20)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Column("STATUS_CHANGE_DATE")]
    [Precision(6)]
    public DateTime StatusChangeDate { get; set; }

    [Column("BATCH_NUMBER")]
    [StringLength(100)]
    [Unicode(false)]
    public string? BatchNumber { get; set; }

    [Column("MRP_RATE", TypeName = "NUMBER(38)")]
    public decimal MrpRate { get; set; }

    [Column("BASIC_RATE", TypeName = "NUMBER(38)")]
    public decimal BasicRate { get; set; }
}
