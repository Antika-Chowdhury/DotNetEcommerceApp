using DotnetEcommerceApp.DataLayer.Repositors;
using DotnetEcommerceApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerceApp.DataLayer.Repositories
{
    public class MockProductRepository : IProductRepository
    {
        // Mock data
        private static readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 899, Stock = 100 },
            new Product { Id = 2, Name = "Smartphone", Price = 499, Stock = 103 },
            new Product { Id = 3, Name = "Headphones", Price = 199, Stock = 110 }
        };

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            // Return mock data
            return await Task.FromResult(_products);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            // Find product by id
            var product = _products.FirstOrDefault(p => p.Id == id);
            return await Task.FromResult(product);
        }

        public async Task AddProductAsync(Product product)
        {
            // Add product to mock data
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task UpdateProductAsync(Product product)
        {
            // Find the product in mock data and update it
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteProductAsync(int id)
        {
            // Find the product in mock data and delete it
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
            await Task.CompletedTask;
        }
    }
}
