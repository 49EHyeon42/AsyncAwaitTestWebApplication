using AsyncAwaitTestWebApplication.Repositories;

namespace AsyncAwaitTestWebApplication.Services
{
    public class TestService(ILogger<TestService> logger, TestRepository testRepository)
    {
        private readonly ILogger<TestService> _logger = logger;
        private readonly TestRepository _repository = testRepository;

        public async Task<string?> TestMethod()
        {
            _logger.LogInformation("[Service] Before await - Thread ID: {ThreadId}", Environment.CurrentManagedThreadId);

            var result = await _repository.TestMethod();

            _logger.LogInformation("[Service] After await - Thread ID: {ThreadId}", Environment.CurrentManagedThreadId);

            return result;
        }
    }
}
