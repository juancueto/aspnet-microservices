using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client)
        {
            _client = client?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            var response = await _client.GetAsync("/api/v1/Catalog");
            var result = await response.ReadContentAs<IEnumerable<CatalogModel>>();
            return result;
        }

        public async Task<CatalogModel> GetCatalog(string id)
        {
            var response = await _client.GetAsync($"/api/v1/Catalog/{id}");
            var result = await response.ReadContentAs<CatalogModel>();
            return result;
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
        {
            var response = await _client.GetAsync($"/api/v1/Catalog/GetProductByCategory/{category}");
            var result = await response.ReadContentAs<IEnumerable<CatalogModel>>();
            return result;
        }
    }
}
