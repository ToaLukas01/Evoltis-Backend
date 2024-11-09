using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.ModelsDB;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ProductsRepository : IProducts
    {
        private readonly EvoltisContext _context;
        private readonly IMapper _mapper;

        public ProductsRepository(EvoltisContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task DeleteProduct(int id)
        {
            
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                }
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR CATCH UPDATE --> {ex.Message} \n {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception --> {ex.InnerException.Message}");
                }
                return;
            }
        }

        public async Task<List<Product>> GetListProducts()
        {
            
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR CATCH UPDATE --> {ex.Message} \n {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception --> {ex.InnerException.Message}");
                }
                return null;
            }
        }

        public async Task<Product> GetProductDetail(int id)
        {
            
            try
            {
                return await _context.Products.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR CATCH UPDATE --> {ex.Message} \n {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception --> {ex.InnerException.Message}");
                }
                return null;
            }
        }

        public async Task<Product> NewProduct(Product product)
        { 
            try
            {
                product.Id = 0;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR CATCH UPDATE --> {ex.Message} \n {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception --> {ex.InnerException.Message}");
                }
                return null;
            }
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            try
            {
                var producto = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (producto != null)
                {
                    producto.Name = product.Name;
                    producto.Price = product.Price;
                    producto.Description = product.Description;
                    await _context.SaveChangesAsync();
                    return producto;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR CATCH UPDATE --> {ex.Message} \n {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception --> {ex.InnerException.Message}");
                }
                return null;
            }


        }
    }
}
