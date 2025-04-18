using System;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RedisService.DataAccess.Data;
using RedisService.DataAccess.Repository.IRepository;
using RedisService.Models;
using RedisService.Utilities.ResponseDTO.GetProductDetails;
using static RedisService.Utilities.ResponseDTO.GetProductDetails.GetProductDetails;

namespace RedisService.DataAccess.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<GetProductDetails.ProductDetails>> GetAllProductDetails()
        {
            // Fetch data from the database
            var productDetails = await _context.Products.Select(p => new
            {
                p.ProductId,
                p.SubdivisionId,
                p.Scheduled,
                p.DiscountPercentage,
                p.BonusScheme,
                p.TieUpScheme,
                p.GstPercentage
            }).ToListAsync(); // Materializes the IQueryable into a List asynchronously

            // Convert to ProductDetails list
            return productDetails.Select(p => new GetProductDetails.ProductDetails
            {
                ProductId = p.ProductId,
                SubDivisionId = p.SubdivisionId,
                IsScheduled = p.Scheduled,
                DiscountPercentage = p.DiscountPercentage,
                BonusScheme = string.IsNullOrEmpty(p.BonusScheme) ? null : JsonConvert.DeserializeObject<BonusScheme>(p.BonusScheme),
                TieUpScheme = string.IsNullOrEmpty(p.TieUpScheme)? null: JsonConvert.DeserializeObject<TieUpScheme>(p.TieUpScheme), // Deserialize JSON
                GstPercentage = p.GstPercentage
            }).ToList();
        }
        public async Task<List<GetProductDetails.ProductBatch>> GetProductBatches()
        {
            return await _context.ProductBatches.Select(x => new GetProductDetails.ProductBatch
            {
                MrpRate = x.MrpRate,
                BasicRate = x.BasicRate,
                BatchId = x.ProductBatchId
            }).ToListAsync(); 
        }



    }
}
