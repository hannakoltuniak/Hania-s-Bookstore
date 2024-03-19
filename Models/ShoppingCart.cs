
using Microsoft.EntityFrameworkCore;

namespace HaniasBookstore.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly HaniasBookstoreDbContext haniasBookstoreDbContext;
        
        public string? ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        public ShoppingCart(HaniasBookstoreDbContext haniasBookstoreDbContext)
        {
            this.haniasBookstoreDbContext = haniasBookstoreDbContext;
        }

        public static ShoppingCart GetCart (IServiceProvider services) //when user is going to visit the site its check if it's already an Id called CartId available fot that user
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            HaniasBookstoreDbContext context = services.GetService<HaniasBookstoreDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Book book)
        {
            ShoppingCartItem shoppingCartItem = haniasBookstoreDbContext.ShoppingCartItems.SingleOrDefault(s => s.Book.Id == book.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Book = book,
                    Amount = 1
                };

                haniasBookstoreDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
                shoppingCartItem.Amount++;
            
            haniasBookstoreDbContext.SaveChanges();
        }

        public int RemoveFromCart(Book book)
        {
            ShoppingCartItem shoppingCartItem = haniasBookstoreDbContext.ShoppingCartItems.SingleOrDefault(s => s.Book.Id == book.Id && s.ShoppingCartId == ShoppingCartId);

            int localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                    haniasBookstoreDbContext.ShoppingCartItems.Remove(shoppingCartItem);
            }

            haniasBookstoreDbContext.SaveChanges();
            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??= haniasBookstoreDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Include(s => s.Book).ToList();
        }

        public void ClearCart()
        {
            var cartItems = haniasBookstoreDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);

            haniasBookstoreDbContext.ShoppingCartItems.RemoveRange(cartItems);

            haniasBookstoreDbContext.SaveChanges();
        }

        public float GetTotalPrice()
        {
            var total = haniasBookstoreDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Select(c => c.Book.Price * c.Amount).Sum();
            return total;
        }
    }
}
