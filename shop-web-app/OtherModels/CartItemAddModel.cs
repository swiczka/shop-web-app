namespace shop_web_app.OtherModels
{
    public class CartItemAddModel
    {
        public int ProductVariantId { get; set; }
        public int ProductId { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
