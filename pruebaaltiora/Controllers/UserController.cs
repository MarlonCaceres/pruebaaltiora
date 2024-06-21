using System;
using Microsoft.AspNetCore.Mvc;
using pruebaaltiora.Models;

namespace pruebaaltiora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;

        public UserController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("AllUser")]
        public ActionResult<ResponseModel> AllUser()
        {
            try
            {
                return Core.Core.GetAllUser(_config);
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

        [HttpPost("UserById")]
        public ActionResult<ResponseModel> UserInformation(int Id)
        {
            try
            {
                UserModel user = new UserModel();
                user.Id = Id;

                return Core.Core.GetUserById(_config, user);
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

        [HttpPost("RegisterUser")]
        public ActionResult<ResponseModel> RegisterUser(UserModel user)
        {
            try
            {
                return Core.Core.Register(_config, user);
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

        [HttpDelete("DeleteUser")]
        public ActionResult<ResponseModel> DeleteUser(int Id)
        {
            try
            {
                return Core.Core.Delete(_config, Id);
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

        [HttpPut("UpdateUser")]
        public ActionResult<ResponseModel> UpdateUser(UserModel user)
        {
            try
            {
                return Core.Core.Update(_config, user);
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

