using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Data;
using CommandAPI.Models;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo repository;
        public CommandsController(ICommandAPIRepo repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Command>> Get()
        {
            // return new string[] { "this", "is", "hard", "coded" };
            var commandItems = repository.GetAllCommands();
            return Ok(commandItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = repository.GetCommandById(id);

            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(commandItem);
        }
    }
}