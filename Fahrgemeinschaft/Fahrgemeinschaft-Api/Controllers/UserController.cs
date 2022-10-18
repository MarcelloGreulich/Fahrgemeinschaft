using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TecAlliance.Carpool.Business.Models;
using TecAlliance.Carpool.Business.Services;

namespace Fahrgemeinschaft_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        UserBusinessServices businessServices;

        public UserController()
        {
            
            businessServices = new UserBusinessServices();

        }

        [HttpPost]
        public async Task<ActionResult<User>> PostTodoItem(User todoItem)
        {
            businessServices.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

    }
}
