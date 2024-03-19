using HaniasBookstore.Models;

namespace HaniasBookstore.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IShoppingCart ShoppingCart { get; }
        public float ShoppingCartTotal { get; }
    
        public ShoppingCartViewModel(IShoppingCart shoppingCart, float shoppingCartTotal)
        {
            ShoppingCart = shoppingCart;
            ShoppingCartTotal = shoppingCartTotal;
        }
    }
}
