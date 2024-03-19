namespace HaniasBookstore.Models
{
    public class OrderRepository : IOrder
    {
        private readonly HaniasBookstoreDbContext context;
        private readonly IShoppingCart shoppingCart;

        public OrderRepository(HaniasBookstoreDbContext context, IShoppingCart shoppingCart)
        {
            this.context = context;
            this.shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem> items = shoppingCart.ShoppingCartItems;
            order.OrderTotal = shoppingCart.GetTotalPrice();

            order.OrderDetails = new List<OrderDetail>();
            foreach (ShoppingCartItem item in items) 
            {
                var orderDetail = new OrderDetail
                {
                    Amount = item.Amount,
                    BookId = item.Book.Id,
                    Price = item.Book.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}
