//-----------------------------------------------------------------------
// <copyright file="ShoppingCartViewModel.cs" company="Hibernating Rhinos LTD">
//     Copyright (c) Hibernating Rhinos LTD. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System.Collections.Generic;
using MvcMusicStore.Models;

namespace MvcMusicStore.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCart.ShoppingCartLine> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}
