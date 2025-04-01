using DotnetEcommerceApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DotnetEcommerceApp.DataLayer.Repositors
{
    

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task AddProductAsync (Product product);
    Task UpdateProductAsync (Product product);
    Task DeleteProductAsync (int id);
}
}