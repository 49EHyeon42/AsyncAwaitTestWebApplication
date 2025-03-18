namespace AsyncAwaitTestWebApplication.Repositories
{
    public class TestRepository(ILogger<TestRepository> logger)
    {
        private readonly ILogger<TestRepository> _logger = logger;

        public async Task<string?> TestMethod()
        {
            _logger.LogInformation("[Repository] Before await - Thread ID: {ThreadId}", Environment.CurrentManagedThreadId);

            var result = await GetStringAsync();

            _logger.LogInformation("[Repository] After await - Thread ID: {ThreadId}", Environment.CurrentManagedThreadId);

            return result;
        }

        private async Task<string> GetStringAsync()
        {
            _logger.LogInformation("[Repository] Before delay - Thread ID: {ThreadId}", Environment.CurrentManagedThreadId);

            await Task.Delay(1000); // 1초 대기

            _logger.LogInformation("[Repository] After delay - Thread ID: {ThreadId}", Environment.CurrentManagedThreadId);

            return "Hello, sync/await!";
        }
    }
}
