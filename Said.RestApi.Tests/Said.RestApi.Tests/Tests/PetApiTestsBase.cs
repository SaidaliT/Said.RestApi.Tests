using NUnit.Framework;
using Said.RestApi.Client.Requests.Pet;

namespace Said.RestApi.Tests.Tests
{
    public abstract class PetApiTestsBase
    {
        protected string? _baseUrl;
        protected PetApiRequests? _petApiRequests;

        [OneTimeSetUp]
        public void BeforeFixture()
        {
            _baseUrl = TestContext.Parameters["baseUrl"]!;
            _petApiRequests = new PetApiRequests(_baseUrl!);
        }
    }
}