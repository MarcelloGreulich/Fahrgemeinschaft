using Microsoft.AspNetCore.Mvc;
using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Business.Services;

namespace TecAlliance.Carpool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Glogal
        UserBusinessServices businessServices;

        //Constructor
        public UserController()
        {
            businessServices = new UserBusinessServices();
        }

        // POST: api/User
        [HttpPost]
        public ActionResult<UserDto> PostUserDto(UserDto user)
        {
            //Add UserDto in businessServices
            businessServices.AddUser(user);

            return Created($"api/User/{user.Id}", user);
        }

        [HttpGet]
        public ActionResult<List<UserDto>> GetAllUsers()
        {
            return businessServices.GetAllUsers();
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUserDto(int id)
        {
            return businessServices.GetUserdtoById(id);      
        }
    }

}
