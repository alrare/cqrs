using WebApi.Application.Model;
using Microsoft.EntityFrameworkCore;


namespace WebApi.Infraestructure.Persistence.Context
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }

        public async Task<IEnumerable<Product>> GetAllProducts() 
        {
            return await Task.FromResult(Products);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await Task.FromResult(Products.Single(p => p.Id == id));
        }

        public async Task AddProduct(Product product)
        {
            Products.Add(product);
        
            await Task.CompletedTask;
        }

        public async Task UpdateProduct(int id, Product product)
        {
            Products.Update(product);
        
            await Task.CompletedTask;
        }

        public async Task DeleteProduct(int id, Product product)
        {
            Products.Remove(product);
        
            await Task.CompletedTask;
        }
        

        /// <summary>
        /// Manejo de eventos
        /// </summary>
        /// <param name="product"></param>
        /// <param name="evt"></param>
        /// <returns></returns>
        public async Task EventOccured(Product product, string evt)
        {
            Products.Single(p => p.Id == product.Id).Name = $"{product.Name} evt: {evt}";
            await Task.CompletedTask;
        }
    }
}