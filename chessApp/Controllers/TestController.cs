using chessApp.ChessServices;
using Microsoft.AspNetCore.Mvc;

namespace chessApp.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _testService.GetData();
            return Ok(data);
        }
    }
}
