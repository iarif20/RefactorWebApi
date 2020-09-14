using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RefactorThis.Data.Repositories;
using RefactorThis.Models.Product;
using RefactorThis.Models.ProductOption;
using RefactorThis.Service.Services.Product;
using RefactorThis.Service.Services.Product.Dtos;
using RefactorThis.Service.Services.ProductOption;
using RefactorThis.Service.Services.ProductOption.Dtos;

namespace RefactorThis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _aMapper;
        private readonly IProductOptionService _aProductOptionService;
        private readonly IProductService _aProductService;
        private readonly IUnitOfWork _aUnitOfWork;

        public ProductsController(IUnitOfWork aUnitOfWork,
            IProductService aProductService,
            IProductOptionService aProductOptionService,
            IMapper aMapper)
        {
            _aUnitOfWork = aUnitOfWork;
            _aProductService = aProductService;
            _aProductOptionService = aProductOptionService;
            _aMapper = aMapper;
        }

        [HttpGet]
        public async Task<ActionResult<GetProductsOutputModel>> Get(string name = null)
        {
            try
            {
                var output = new GetProductsOutputModel();
                var result = await _aProductService.GetAllProductsAsync(new GetAllProductsInputDto
                {
                    ProductName = name
                });

                if (result.ResultSuccess)
                {
                    output.Items = _aMapper.Map<List<ProductItemModel>>(result.Items);
                    return output;
                }

                return StatusCode(StatusCodes.Status500InternalServerError, result.ResultErrors.Messages.First());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error :" + e.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetProductItemOutputModel>> Get(Guid id)
        {
            try
            {
                var output = new GetProductItemOutputModel();
                var result = await _aProductService.GetProductAsync(new GetProductInputDto
                {
                    Id = id
                });

                if (result.ResultSuccess) output = _aMapper.Map<GetProductItemOutputModel>(result);
                return output;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error: " + e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CreateProductItemOutputModel>> Post(CreateProductItemInputModel aModel)
        {
            try
            {
                var input = _aMapper.Map<AddProductInputDto>(aModel);
                var result = await _aProductService.AddProductAsync(input);
                if (result.ResultSuccess)
                {
                    var output = _aMapper.Map<CreateProductItemOutputModel>(result);
                    return StatusCode(StatusCodes.Status201Created, output);
                }

                return StatusCode(StatusCodes.Status500InternalServerError, result.ResultErrors.Messages.First());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error: " + e.Message);
            }
        }

        [HttpDelete("{aId}")]
        public async Task<ActionResult<RemoveProductItemOutputModel>> Delete(Guid aId)
        {
            try
            {
                var result = await _aProductService.RemoveProductAsync(new RemoveProductInputDto
                {
                    Id = aId
                });
                if (result.ResultSuccess)
                    return _aMapper.Map<RemoveProductItemOutputModel>(result);
                return StatusCode(StatusCodes.Status500InternalServerError, result.ResultErrors.Messages.First());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpPut("{aId}")]
        public async Task<ActionResult<UpdateProductItemOutputModel>> Put(Guid aId, UpdateProductItemInputModel aModel)
        {
            try
            {
                var input = _aMapper.Map<UpdateProductInputDto>(aModel);
                var result = await _aProductService.UpdateProductAsync(new UpdateProductInputDto
                {
                    Id = aId,
                    DeliveryPrice = aModel.DeliveryPrice,
                    Description = aModel.Description,
                    Name = aModel.Name,
                    Price = aModel.Price
                });
                UpdateProductItemOutputModel output;
                if (result.ResultSuccess) output = _aMapper.Map<UpdateProductItemOutputModel>(result);
                else return StatusCode(StatusCodes.Status500InternalServerError, result.ResultErrors.Messages.First());
                return output;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        // 8. `GET /products/{id}/options/{optionId}` - finds the specified product option for the specified product.

        [HttpGet("{aProductId}/options/{aOptionId}")]
        public async Task<ActionResult<GetProductOptionItemOutputByIdAndProductIdModel>> Get(Guid aProductId, Guid aOptionId)
        {
            try
            {
                GetProductOptionDetailOutputDto result = await _aProductOptionService.GetProductOptionDetail(new GetProductOptionDetailInputDto()
                {
                    Id = aOptionId
                });

                if (result.ResultSuccess)
                {
                    var output = _aMapper.Map<GetProductOptionItemOutputByIdAndProductIdModel>(result);
                    return output;
                }

                return StatusCode(StatusCodes.Status500InternalServerError, result.ResultErrors.Messages.First());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error :" + e.Message);
            }
        }


        // 9. `POST /products/{id}/options` - adds a new product option to the specified product.
        [HttpPost("{aProductId}/options")]
        public async Task<ActionResult<CreateProductOptionItemOutputModel>> Post(Guid aProductId, CreateProductOptionItemInputModel aModel)
        {
            try
            {
                AddProductOptionOutputDto result = await _aProductOptionService.AddProductOption(new AddProductOptionInputDto()
                {
                    Description = aModel.Description,
                    Name = aModel.Name,
                    ProductId = aModel.ProductId
                });

                if (result.ResultSuccess)
                {
                    CreateProductOptionItemOutputModel output = _aMapper.Map<CreateProductOptionItemOutputModel>(result);
                    return output;
                }

                return StatusCode(StatusCodes.Status500InternalServerError, result.ResultErrors.Messages.First());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error :" + e.Message);
            }
        }


        // 10. `PUT /products/{id}/options/{optionId}` - updates the specified product option.
        [HttpPut("{aProductId}/options/{aOptionId}")]
        public async Task<ActionResult<UpdateProductOptionItemOutputModel>> Put(Guid aProductId, Guid aOptionId, UpdateProductOptionItemInputModel aModel)
        {
            try
            {
                UpdateProductOptionOutputDto result = await _aProductOptionService.UpdateProductOption(new UpdateProductOptionInputDto()
                {
                    Id = aOptionId,
                    Description = aModel.Description,
                    Name = aModel.Name,
                    ProductId = aProductId
                });

                if (result.ResultSuccess)
                {
                    UpdateProductOptionItemOutputModel output = _aMapper.Map<UpdateProductOptionItemOutputModel>(result);
                    return output;
                }

                return StatusCode(StatusCodes.Status500InternalServerError, result.ResultErrors.Messages.First());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error :" + e.Message);
            }
        }

        [HttpDelete("{aProductId}/options/{aOptionId}")]
        public async Task<ActionResult<RemoveProductOptionItemOutputModel>> Delete(Guid aProductId, Guid aOptionId)
        {
            try
            {
                RemoveProductOptionOutputDto result = await _aProductOptionService.RemoveProductOption(new RemoveProductOptionInputDto()
                {
                    Id = aOptionId
                });
                if (result.ResultSuccess)
                    return _aMapper.Map<RemoveProductOptionItemOutputModel>(result);
                return StatusCode(StatusCodes.Status500InternalServerError, result.ResultErrors.Messages.First());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

    }
}