namespace AsyncAwaitTestWebApplication.Repositories
{
    public class TestRepository
    {
        public async Task<string?> TestMethod()
        {
            return await GetStringAsync();
        }

        private async Task<string> GetStringAsync()
        {
            await Task.Delay(1000);

            return "Hello, sync/await!";
        }
    }
}
