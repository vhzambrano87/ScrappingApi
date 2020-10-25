using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using BusinessEntity;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrappingApi.Model;

namespace ScrappingApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private UserLogic objUserLogic = new UserLogic();
        private User objUser=new User();
       
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var objUser = objUserLogic.Get(id);
                if (objUser.id == 0)                
                    return NotFound();  
                else
                    return Ok(JsonSerializer.Serialize(objUser));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }            
        }

        [HttpPost]
        public IActionResult Register([FromBody]UserRequest objUserRequest)
        {
            try
            {
                objUser.firstname = objUserRequest.firstname;
                objUser.lastname = objUserRequest.lastname;
                objUser.email = objUserRequest.email;
                objUser.active = true;
                objUser.username = objUserRequest.username;
                objUser.password = objUserRequest.password;

                return Ok(objUserLogic.Insert(objUser));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
