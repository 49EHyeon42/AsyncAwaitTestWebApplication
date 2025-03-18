using AsyncAwaitTestWebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace AsyncAwaitTestWebApplication.Controllers
{
    [ApiController]
    [Route("/api/test")]
    public class TestController(TestService testService) : ControllerBase
    {
        private readonly TestService _testService = testService;

        [HttpGet]
        public async Task<IActionResult> TestMethod()
        {
            var result = await _testService.TestMethod();
            return Ok(result);
        }
    }
}
