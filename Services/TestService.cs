using AsyncAwaitTestWebApplication.Repositories;

namespace AsyncAwaitTestWebApplication.Services
{
    public class TestService(ILogger<TestService> logger, TestRepository testRepository)
    {
        private readonly ILogger<TestService> _logger = logger;
        private readonly TestRepository _repository = testRepository;

        public async Task<string?> TestMethod()
        {
            int beforeThreadId = Environment.CurrentManagedThreadId;

            var result = await _repository.TestMethod();

            int afterThreadId = Environment.CurrentManagedThreadId;

            if (beforeThreadId != afterThreadId)
            {
                _logger.LogInformation("[Service] beforeThreadId: {BeforeThreadId}, afterThreadId: {AfterThreadId}", beforeThreadId, afterThreadId);
            }

            return result;
        }
    }
}
