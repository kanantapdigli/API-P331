using AutoMapper;
using Business.DTOs.Common;
using Business.DTOs.Product.Request;
using Business.DTOs.Product.Response;
using Business.Exceptions;
using Business.Services.Abstract;
using Business.Validators.Product;
using Common.Entities;
using DataAccess.Repositories.Abstract;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<ProductDTO>>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return new Response<List<ProductDTO>>
            {
                Data = _mapper.Map<List<ProductDTO>>(products)
            };
        }

        public async Task<Response<ProductDTO>> GetAsync(int id)
        {
            var product = await _productRepository.GetAsync(id);
            if (product is null)
                throw new NotFoundException("Məhsul tapılmadı");

            return new Response<ProductDTO>
            {
                Data = _mapper.Map<ProductDTO>(product)
            };
        }

        public async Task<Response> CreateAsync(ProductCreateDTO model)
        {
            var result = await new ProductCreateDTOValidator().ValidateAsync(model);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var product = _mapper.Map<Product>(model);
            await _productRepository.CreateAsync(product);
            await _unitOfWork.CommitAsync();

            return new Response
            {
                Message = "Məhsul uğurla yaradıldı"
            };
        }

        public async Task<Response> UpdateAsync(int id, ProductUpdateDTO model)
        {
            var result = await new ProductUpdateDTOValidator().ValidateAsync(model);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            var product = await _productRepository.GetAsync(id);
            if (product is null)
                throw new NotFoundException("Məhsul tapılmadı");

            _mapper.Map(model, product);
            product.ModifiedAt = DateTime.Now;

            _productRepository.Update(product);
            await _unitOfWork.CommitAsync();

            return new Response
            {
                Message = "Məhsul uğurla redaktə olundu"
            };
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var product = await _productRepository.GetAsync(id);
            if (product is null)
                throw new NotFoundException("Məhsul tapılmadı");

            _productRepository.Delete(product);
            await _unitOfWork.CommitAsync();

            return new Response
            {
                Message = "Məhsul uğurla silindi"
            };
        }
    }
}
