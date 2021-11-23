using CartDemo.Services.Interface;
using CartDemo.ViewModels.APIBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartDemo.Controllers.WebAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductWebApiController : ControllerBase
    {
        private IProductService _productService;
        public ProductWebApiController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ApiResponse GetAllProduct()
        {
            try
            {
                var result = _productService.GetProductList();
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, false);
            }
        }
    }
}
