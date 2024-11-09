using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ModelsDB;


namespace Repository.Interfaces
{
    public interface IProducts
    {
        Task<List<Product>> GetListProducts();
        Task<Product> GetProductDetail(int id);
        Task DeleteProduct(int id);
        Task<Product> NewProduct(Product prpduct);
        Task<Product> UpdateProduct(int id, Product product);
    }
}
