namespace HaniasBookstore.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Book book);

        int RemoveFromCart(Book book);

        List<ShoppingCartItem> GetShoppingCartItems();

        void ClearCart();

        float GetTotalPrice();

        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
