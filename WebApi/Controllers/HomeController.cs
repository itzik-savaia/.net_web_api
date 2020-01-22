using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        DB.DB db = new DB.DB();

        // GET: api/Home
        [Route("GetUsers")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            UserService userService = new UserService();
            List<User> ListOfUsers = new List<User>();

            try
            {
                ListOfUsers = userService.GetUsers();
                
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok(ListOfUsers);
        }


        [Route("GetUser/{id}")]
        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            UserService userService = new UserService();
            User user = new User();

            string data = "";
            try
            {
                user = userService.GetUser(id);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
            
            return Ok(user);
        }


        // POST: api/Home
        [HttpPost]
        [Route("PostUser")]
        public object PostUser([FromBody]User user)
        {
            UserService userService = new UserService();

            try
            {
                if (user.username != "")
                {
                    user = userService.PostUser(user.username, user.password, user.role_option_1, user.role_option_2);
                    //return StatusCode(202, new{result = user});
                }else
                {
                    return StatusCode(401, new { result = "something is missing" });
                }
            }catch(Exception ex)
            {
                return BadRequest();
            }
            return StatusCode(201);


        }


        // PUT: api/Home/5
        [HttpPut("PutUser/{id}")]
        public object PutUser(int id, [FromBody] User user)
        {
            
            UserService userService = new UserService();
            try
            {
                user = userService.PutUser(id,user.username,user.password,user.role_option_1,user.role_option_2);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return StatusCode(200);

        }
        // DELETE: api/ApiWithActions/5
        [Route("DeleteUser/{id}")]
        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            UserService userService = new UserService();
            User user = new User();

            try
            {
                user = userService.DeleteUser(id);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return StatusCode(200, new { result = $"user {id} delete from data" });
        }
    }
}
