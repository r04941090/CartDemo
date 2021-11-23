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
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class LoginWebApiController : ControllerBase
    {
        private ILoginService _loginService;
        public LoginWebApiController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpGet]
        public ApiResponse GetUserId(string Account)
        {
            try
            {
                var result = _loginService.GetUserId(Account);
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch(Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, false);
            }

        }
    }
}
