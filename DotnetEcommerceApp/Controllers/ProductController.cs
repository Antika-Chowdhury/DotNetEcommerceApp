using DotnetEcommerceApp.DataLayer.Repositors;
using DotnetEcommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetEcommerceApp.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : Controller  // Change ControllerBase to Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: /Product
        [HttpGet]
        public async Task<IActionResult> GetProducts()  // Return a view
        {
            var products = await _productRepository.GetAllProductsAsync();
            return View("Index", products);  // Pass the data to the view
        }

        // GET: /Product/Details/1
        [HttpGet]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();  // If not found, return 404 error page
            }
            return View(product);  // Return a view with the product details
        }

        // POST: /Product/Create
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.AddProductAsync(product);
                return RedirectToAction(nameof(GetProducts));  // Redirect to the product list page after adding
            }
            return View(product);  // Return the same page if the model is not valid
        }

        // PUT: /Product/Edit/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Product product, int id)
        {
            if (id != product.Id)
                return BadRequest();  // Return 400 if IDs don't match

            if (ModelState.IsValid)
            {
                await _productRepository.UpdateProductAsync(product);
                return RedirectToAction(nameof(GetProducts));  // Redirect to the product list after updating
            }
            return View(product);  // Return to the same page if the model is not valid
        }

        // DELETE: /Product/Delete/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProductAsync(id);
            return RedirectToAction(nameof(GetProducts));  // Redirect to the product list after deletion
        }
    }
}
