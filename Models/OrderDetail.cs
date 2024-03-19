namespace HaniasBookstore.Models
{
    public class OrderDetail
    {
        public int OrderDetailId {  get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Amount {  get; set; }
        public float Price { get; set; }
        public Order Order { get; set; } = default!;
    }
}