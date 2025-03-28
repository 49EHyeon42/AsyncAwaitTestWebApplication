﻿using AsyncAwaitTestWebApplication.Services;
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
        public IActionResult TestMethod()
        {
            int beforeThreadId = Environment.CurrentManagedThreadId;

            var result = _testService.TestMethod();

            int afterThreadId = Environment.CurrentManagedThreadId;

            if (beforeThreadId != afterThreadId)
            {
                _logger.LogInformation("[Controller] beforeThreadId: {BeforeThreadId}, afterThreadId: {AfterThreadId}", beforeThreadId, afterThreadId);
            }

            return Ok(result);
        }

        [HttpGet("A")]
        public async Task<IActionResult> TestMethodAsync()
        {
            int beforeThreadId = Environment.CurrentManagedThreadId;

            var result = await _testService.TestMethodAsync();

            int afterThreadId = Environment.CurrentManagedThreadId;

            if (beforeThreadId != afterThreadId)
            {
                _logger.LogInformation("[Controller-A] beforeThreadId: {BeforeThreadId}, afterThreadId: {AfterThreadId}", beforeThreadId, afterThreadId);
            }

            return Ok(result);
        }
    }
}
