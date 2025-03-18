using AsyncAwaitTestWebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace AsyncAwaitTestWebApplication.Controllers
{
    [ApiController]
    [Route("/api/test")]
    public class TestController(ILogger<TestController> logger, TestService testService) : ControllerBase
    {
        private readonly ILogger<TestController> _logger = logger;
        private readonly TestService _testService = testService;

        [HttpGet]
        public async Task<IActionResult> TestMethod()
        {
            _logger.LogInformation("[Controller] Before await - Thread ID: {ThreadId}", Environment.CurrentManagedThreadId);

            var result = await _testService.TestMethod();

            _logger.LogInformation("[Controller] After await - Thread ID: {ThreadId}", Environment.CurrentManagedThreadId);

            return Ok(result);
        }
    }
}
