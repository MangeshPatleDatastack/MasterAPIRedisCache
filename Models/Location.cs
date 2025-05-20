using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RedisService.Models;

[Table("LOCATIONS", Schema = "ERPMASTER")]
public partial class Location
{
    [Key]
    [Column("LOCATION_ID")]
    [Precision(16)]
    public long LocationId { get; set; }

    [Column("CODE")]
    [StringLength(100)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [Column("NAME")]
    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("EMAIL")]
    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("GST_REGISTERED")]
    [StringLength(20)]
    [Unicode(false)]
    public string? GstRegistered { get; set; }

    [Column("GST_NUMBER")]
    [StringLength(200)]
    [Unicode(false)]
    public string? GstNumber { get; set; }

    [Column("ADDRESS_1")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Address1 { get; set; }

    [Column("ADDRESS_2")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Address2 { get; set; }

    [Column("ADDRESS_3")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Address3 { get; set; }

    [Column("CITY")]
    [StringLength(100)]
    [Unicode(false)]
    public string? City { get; set; }

    [Column("PIN_CODE")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PinCode { get; set; }

    [Column("STATE_ID", TypeName = "NUMBER(38)")]
    public long StateId { get; set; }

    [Column("PHONE_NUMBER_1")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PhoneNumber1 { get; set; }

    [Column("PHONE_NUMBER_2")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PhoneNumber2 { get; set; }

    [Column("TELEPHONE_NUMBER_1")]
    [StringLength(20)]
    [Unicode(false)]
    public string? TelePhoneNumber1 { get; set; }


    [Column("TELEPHONE_NUMBER_2")]
    [StringLength(20)]
    [Unicode(false)]
    public string? TelePhoneNumber2 { get; set; }

    [Column("FAX_NUMBER_1")]
    [StringLength(20)]
    [Unicode(false)]
    public string? FaxNumber1 { get; set; }

    [Column("FAX_NUMBER_2")]
    [StringLength(20)]
    [Unicode(false)]
    public string? FaxNumber2 { get; set; }

    [Column("STATUS")]
    [StringLength(20)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [Column("STATUS_CHANGE_DATE")]
    [Precision(6)]
    public DateTime StatusChangeDate { get; set; }

    [Column("IS_PRIMARY")]
    [StringLength(1)]
    [Unicode(false)]
    public string? IsPrimary { get; set; }

    [Column("CUSTOMER_ID")]
    [Precision(16)]
    public long CustomerId { get; set; }
    [Column("COMPANY_ID")]
    [Precision(16)]
    public long CompanyId { get; set; }

	[Column("TYPE")]
	[StringLength(100)]
	public string? Type { get; set; }

}
