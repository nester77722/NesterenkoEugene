using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UserRegistration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IDataService _dataService;
        private readonly ILogger<UserController> _logger;


        public UserController(ILogger<UserController> logger, IDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [HttpPost]
        public User AddUser([FromForm] User user)
        {
            return _dataService.Create(user);
        }
    }
}
