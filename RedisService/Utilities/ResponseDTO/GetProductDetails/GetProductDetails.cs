using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisService.Utilities.ResponseDTO.GetProductDetails
{
    public class GetProductDetails
    {
        public class ProductDetails
        {
            public long ProductId { get; set; }
        
            [Required(ErrorMessage = "Required SubDivisionId")]
            [Range(1, 9999999999999999, ErrorMessage = "Invalid SubDivision Id")]
            public long SubDivisionId { get; set; }
            [StringLength(10, ErrorMessage = "Invalid IsScheduled")]
            public string? IsScheduled { get; set; }
            [Range(0, 100, ErrorMessage = "Discount should be between 0 and 100")]
            public decimal? DiscountPercentage { get; set; }
            public BonusScheme? BonusScheme { get; set; }
            public TieUpScheme? TieUpScheme { get; set; }
            public decimal? GstPercentage { get; set; }
        }
        public class TieUpScheme
        {
            public long ProductId { get; set; }
            public long SalesQuantity { get; set; }
            public long BonusQuantity { get; set; }

        }
        public class BonusScheme
        {
            public long ProductId { get; set; }

            public string? SchemeFrom { get; set; }

            public string? SchemeTo { get; set; }

            public long SalesQty { get; set; }

            public long BonusQuantity { get; set; }
        }
        public class ProductBatch
        {
            [Required(ErrorMessage = "Mrp Rate is required")]
            [Range(0.01, double.MaxValue, ErrorMessage = "MRP Rate must be greater than zero.")]
            public decimal MrpRate { get; set; }

            [Required(ErrorMessage = "Basic Rate is required")] // Ensures that the property cannot be null or empty
            [Range(0.01, double.MaxValue, ErrorMessage = "Basic Rate must be greater than zero.")]
            public decimal BasicRate { get; set; }
            [Required(ErrorMessage = "Required BatchId")]
            [Range(1, 9999999999999999, ErrorMessage = "Invalid Batch Id")]
            public long BatchId { get; set; }
        }
    }
}
