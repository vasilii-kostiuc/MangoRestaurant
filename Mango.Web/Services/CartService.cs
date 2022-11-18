﻿using Mango.Web.Models;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services;

public class CartService : BaseService, ICartService
{
    public CartService(IHttpClientFactory httpClient) : base(httpClient)
    {
    }

    public async Task<T> GetCartByUserIdAsync<T>(string userId, string token = null)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            ApiUrl = SD.ShoppinCartApiBase + "/api/cart/GetCart" + userId,
            AccessToken = token
        });
    }

    public async Task<T> AddToCartAsync<T>(CartDto cartDto, string token = null)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = cartDto,
            ApiUrl = SD.ShoppinCartApiBase + "/api/cart/AddCart",
            AccessToken = token
        });
    }

    public async Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = cartDto,
            ApiUrl = SD.ShoppinCartApiBase + "/api/cart/AddCart",
            AccessToken = token
        });
    }

    public async Task<T> RemoveFromCartAsync<T>(int cartId, string token = null)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = cartId,
            ApiUrl = SD.ShoppinCartApiBase + "/api/cart/UpdateCart",
            AccessToken = token
        });
    }
}