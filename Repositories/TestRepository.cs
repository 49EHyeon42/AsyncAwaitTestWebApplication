namespace AsyncAwaitTestWebApplication.Repositories
{
    public class TestRepository(ILogger<TestRepository> logger)
    {
        private readonly ILogger<TestRepository> _logger = logger;

        public string TestMethod()
        {
            int beforeThreadId = Environment.CurrentManagedThreadId;

            var result = GetStringAsync().Result;

            int afterThreadId = Environment.CurrentManagedThreadId;

            if (beforeThreadId != afterThreadId)
            {
                _logger.LogInformation("[Repository] beforeThreadId: {BeforeThreadId}, afterThreadId: {AfterThreadId}", beforeThreadId, afterThreadId);
            }

            return result;
        }

        public async Task<string> TestMethodAsync()
        {
            int beforeThreadId = Environment.CurrentManagedThreadId;

            var result = await GetStringAsync();

            int afterThreadId = Environment.CurrentManagedThreadId;

            if (beforeThreadId != afterThreadId)
            {
                _logger.LogInformation("[Repository-A] beforeThreadId: {BeforeThreadId}, afterThreadId: {AfterThreadId}", beforeThreadId, afterThreadId);
            }

            return result;
        }

        private async Task<string> GetStringAsync()
        {
            await Task.Delay(1000);

            return "Hello, sync/await!";
        }
    }
}
