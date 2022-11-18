using Mango.Services.ShoppingCartApi.Models.Dto;

namespace Mango.Services.ShoppingCartApi.Repository
{
    public interface ICartRepository
    {
        public Task<CartDto> GetCartByUserId(string userId);
        public Task<CartDto> CreateUpdateCart(CartDto cartDto);
        public Task<bool> RemoveFromCart(int cartDetailsId);
        public Task<bool> ClearCart(string userId);
    }
}
