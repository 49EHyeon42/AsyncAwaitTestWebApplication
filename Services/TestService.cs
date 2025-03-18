using AsyncAwaitTestWebApplication.Repositories;

namespace AsyncAwaitTestWebApplication.Services
{
    public class TestService(TestRepository testRepository)
    {
        private readonly TestRepository _repository = testRepository;

        public async Task<string?> TestMethod()
        {
            return await _repository.TestMethod();
        }
    }
}
