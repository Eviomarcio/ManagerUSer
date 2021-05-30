using System;
using System.Threading.Tasks;
using Manaege.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                return Ok();
            }
           /*  catch (DomainException ex)
            {
                return BadRequest();
            } */
            catch (Exception)
            {
                
                return StatusCode(500, "Erro");
            }
        }
    }
}