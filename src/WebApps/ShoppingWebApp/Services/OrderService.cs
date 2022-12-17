using ShoppingWebApp.Extensions;
using ShoppingWebApp.Models;

namespace ShoppingWebApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            this._client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
        {
            var response = await _client.GetAsync($"/Order/{userName}");
            return await response.ReadContentAs<List<OrderResponseModel>>();
        }
    }
}
