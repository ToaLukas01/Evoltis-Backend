using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Models.ModelsDB;

namespace Models.DTO
{
    public class Mapeo: Profile
    {
        public Mapeo()
        {
            CreateMap<Product, ProductoDTO>();
            CreateMap<ProductoDTO, Product>();
        }
    }
}
