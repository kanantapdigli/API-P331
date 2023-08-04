using Business.DTOs.Common;
using Business.DTOs.Product.Request;
using Business.DTOs.Product.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IProductService
    {
        Task<Response<List<ProductDTO>>> GetAllAsync();
        Task<Response<ProductDTO>> GetAsync(int id);
        Task<Response> CreateAsync(ProductCreateDTO model);
        Task<Response> UpdateAsync(int id, ProductUpdateDTO model);
        Task<Response> DeleteAsync(int id);
    }
}
