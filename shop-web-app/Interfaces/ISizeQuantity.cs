namespace shop_web_app.Interfaces
{
    public interface ISizeQuantity<TSize>
    {
        TSize Size { get; set; }
        int Quantity { get; set; }
    }
}
