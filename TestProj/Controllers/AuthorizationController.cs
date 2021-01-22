using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestProj.DTO;
using TestProj.Model;

namespace TestProj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorizationController : ControllerBase
    {
        LinkedList<User> AuthorizedUsers;

        public AutorizationController()
        {
            AuthorizedUsers = new LinkedList<User>();
            AuthorizedUsers.AddLast(new User("hodor", "hodor"));
            AuthorizedUsers.AddLast(new User("golum", "golum"));
        }

        [HttpPost]
        public ObjectResult login([FromBody] User user)
        {
            //1. Datanebank nach dem User schauen
            //2. Wenn User vorhanden
            //2.1 incoming user pw hased
            //2.2 vergleich vo PW 
            foreach (User AuthorizedUser in AuthorizedUsers)
            {
                if (AuthorizedUser.Username == user.Username)
                {
                    if (AuthorizedUser.Password == user.Password)
                    {
                        return new ObjectResult(new UserDTO(AuthorizedUser.Username));
                    }
                }
            }

            return StatusCode(401, "Unauthorized: Custom msg");
        }

    }
}
