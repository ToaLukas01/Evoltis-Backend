using AutoMapper;
using Models.DTO;
using Models.ModelsDB;
using Repository.Interfaces;
using Repository.Repository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProducts _productsRepository;
        private readonly IMapper _mapper;

        public ProductsService(IProducts productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductoDTO>> GetListProducts()
        {
            var products = await _productsRepository.GetListProducts();
            return (List<ProductoDTO>)_mapper.Map<IEnumerable<ProductoDTO>>(products);
        }

        public async Task<ProductoDTO> GetProductDetail(int id)
        {
            var product = await _productsRepository.GetProductDetail(id);
            return _mapper.Map<ProductoDTO>(product);
        }

        public async Task<ProductoDTO> NewProduct(ProductoDTO productDTO)
        {
            productDTO.Id = 0;
            var product = _mapper.Map<Product>(productDTO);
            var createdProduct = await _productsRepository.NewProduct(product);

            if (createdProduct == null) return null;

            return _mapper.Map<ProductoDTO>(createdProduct);
        }

        public async Task<ProductoDTO> UpdateProduct(int id, ProductoDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            var updatedProduct = await _productsRepository.UpdateProduct(id, product);
            return _mapper.Map<ProductoDTO>(updatedProduct);
        }

        public async Task DeleteProduct(int id)
        {
            await _productsRepository.DeleteProduct(id);
        }
    }
}
