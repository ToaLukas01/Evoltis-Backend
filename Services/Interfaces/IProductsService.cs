using Models.DTO;
using Models.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductsService
    {
        Task<List<ProductoDTO>> GetListProducts();
        Task<ProductoDTO> GetProductDetail(int id);
        Task DeleteProduct(int id);
        Task<ProductoDTO> NewProduct(ProductoDTO productDTO);
        Task<ProductoDTO> UpdateProduct(int id, ProductoDTO productDTO);
    }
}
