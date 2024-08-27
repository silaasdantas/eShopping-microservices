﻿using Basket.Core.Entities;

namespace Basket.Application.Responses;

public class ShoppingCartResponse
{
    public string UserName { get; set; }
    public List<ShoppingCartItem> Items { get; set; } = [];

    public ShoppingCartResponse() { }
    public ShoppingCartResponse(string userName)
    {
        UserName = userName;
    }

    public decimal TotalPrice
    {
        get
        {
            decimal total = 0;
            foreach (var item in Items)
                total += item.Price * item.Quantity;
            return total;
        }
    }
}
