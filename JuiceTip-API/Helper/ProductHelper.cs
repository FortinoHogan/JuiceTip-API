using JuiceTip_API.Data;
using JuiceTip_API.Model;
using JuiceTip_API.Output;
using Microsoft.AspNetCore.Mvc;
using static JuiceTip_API.Output.AllProductOutput;

namespace JuiceTip_API.Helper
{
    public class ProductHelper
    {
        private JuiceTipDBContext _dbContext;
        public ProductHelper(JuiceTipDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        private Guid GetCategoryId(string targetCategory)
        {
            var category = _dbContext.MsCategory.Where(x => x.Category == targetCategory).FirstOrDefault();

            if(category != null)
            {
                return category.CategoryId;
            }

            var newCategory = new MsCategory
            {
                CategoryId = Guid.NewGuid(),
                Category = targetCategory
            };

            _dbContext.MsCategory.Add(newCategory);
            _dbContext.SaveChanges();

            return newCategory.CategoryId;
        }

        public List<AllProductModel> GetProducts()
        {
            try
            {
                var allData = (from product in _dbContext.MsProduct
                                  join user in _dbContext.MsUser
                                  on product.CustomerId equals user.UserId

                                  join region in _dbContext.MsRegion
                                  on product.RegionId equals region.RegionId

                                  join category in _dbContext.MsCategory
                                  on product.CategoryId equals category.CategoryId
                                  select new AllProductModel
                                  {
                                      ProductId = product.ProductId,
                                      ProductImage = product.ProductImage,
                                      ProductName = product.ProductName,
                                      ProductDescription = product.ProductDescription,
                                      ProductPrice = product.ProductPrice,
                                      CategoryId = product.CategoryId,
                                      CategoryName = category.Category,
                                      RegionId = product.RegionId,
                                      RegionName = region.Region,
                                      CustomerId = user.UserId,
                                      CustomerName = user.FirstName + " " + user.LastName,
                                      Notes = product.Notes,
                                      CreatedAt = product.CreatedAt,
                                      LastUpdatedAt = product.LastUpdatedAt
                                  }).ToList();
                return allData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MsProduct GetCurrentProduct(ProductRequest product)
        {
            var currentProduct = _dbContext.MsProduct.Where(x => x.ProductId == product.ProductId).FirstOrDefault();

            if (currentProduct != null) return currentProduct;

            return null;
        }

        public MsProduct GetDuplicateProduct(ProductRequest product)
        {
            var duplicateProduct = _dbContext.MsProduct.Where(x => x.ProductName == product.ProductName && x.CustomerId == product.CustomerId).FirstOrDefault();

            if (duplicateProduct != null) return duplicateProduct;

            return null;
        }

        public MsProduct UpsertProduct([FromBody] ProductRequest product)
        {
            try
            {
                var currentProduct = GetCurrentProduct(product);

                if(currentProduct != null)
                {
                    currentProduct.ProductImage = product.ProductImage;
                    currentProduct.ProductName = product.ProductName;
                    currentProduct.ProductDescription = product.ProductDescription;
                    currentProduct.ProductPrice = Math.Round(product.ProductPrice, 7);
                    currentProduct.CategoryId = product.CategoryId;
                    currentProduct.CustomerId = product.CustomerId;
                    currentProduct.RegionId = product.RegionId;
                    currentProduct.Notes = product.Notes;
                    currentProduct.LastUpdatedAt = DateTime.Now;
                    _dbContext.SaveChanges();

                    return currentProduct;
                }
                else
                {
                    var duplicateProduct = GetDuplicateProduct(product);

                    if (duplicateProduct == null)
                    {
                        var newProduct = new MsProduct
                        {
                            ProductImage = product.ProductImage,
                            ProductName = product.ProductName,
                            ProductDescription = product.ProductDescription,
                            ProductPrice = Math.Round(product.ProductPrice, 7),
                            CategoryId = product.CategoryId,
                            CustomerId = product.CustomerId,
                            RegionId = product.RegionId,
                            Notes = product.Notes,
                            CreatedAt = DateTime.Now,
                            LastUpdatedAt = DateTime.Now
                        };

                        _dbContext.MsProduct.Add(newProduct);
                        _dbContext.SaveChanges();

                        return newProduct;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
