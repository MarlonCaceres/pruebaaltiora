using System;
using Microsoft.AspNetCore.Mvc;
using pruebaaltiora.Models;

namespace pruebaaltiora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IConfiguration _config;

        public ProductController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("Register")]
        public ActionResult<ResponseModel> Register(ProductModel product)
        {
            try
            {
                return Core.Core.Register(_config, product);
            }
            catch (Exception err)
            {
                ResponseModel lo_retorno = new ResponseModel();
                lo_retorno.status = false;
                lo_retorno.data = "";
                lo_retorno.error = 1;
                lo_retorno.message = "ERROR: " + err;

                return lo_retorno;
            }

        }
    }
}

