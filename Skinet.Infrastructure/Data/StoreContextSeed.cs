using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Skinet.Core.Entities;
using Skinet.Infrastucuture.Data;

namespace Skinet.Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllBytes("../Skinet.Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRange(brands);
            }

            if (!context.ProductTypes.Any())
            {
                var productsTypeData = File.ReadAllBytes("../Skinet.Infrastructure/Data/SeedData/types.json");
                var productsType = JsonSerializer.Deserialize<List<ProductType>>(productsTypeData);
                context.ProductTypes.AddRange(productsType);
            }

            if (!context.Products.Any())
            {
                var productsData = File.ReadAllBytes("../Skinet.Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products);
            }

            if (context.ChangeTracker.HasChanges())
                await context.SaveChangesAsync();
        }
    }
}