using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LunaPetShop.Domain.Commands;
using LunaPetShop.Domain.Commands.Contracts;
using LunaPetShop.Domain.Commands.Produtcs;
using LunaPetShop.Domain.Handlers;
using LunaPetShop.Domain.Handlers.Products;
using LunaPetShop.Domain.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LunaPetShop.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRespository _productRespository;
        public ProductController(IProductRespository productRespository)
        {
            _productRespository = productRespository;
        }

        [HttpPost]
        public async Task<ActionResult> Post(
            [FromServices] CreateProductHandler handler,
            [FromBody] CreateProductCommand command)
        {
            try
            {
                var result = (CommandResult)handler.handle(command);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("{Id}")]

        public async Task<ActionResult> GetById(Guid Id)
        {
            return Ok(_productRespository.GetById(Id));
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult> Delete([FromServices] DeleteProductHandler handler, Guid Id)
        {
            try
            {

                var result = (CommandResult)handler.handle(Id);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(_productRespository.GetAll());
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<ActionResult> Update([FromServices] UpdateProductHandler handler,
                                                [FromBody] UpdateProductCommand command)
        {
            try
            {
                var result = (CommandResult)handler.handle(command);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}