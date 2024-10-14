//Interface with basic fields shared by all kinds of clothing: shoes, shirts, pants, etc..

using shop_web_app.Enums;

namespace shop_web_app.Interfaces
{
    public interface IClothingItem<TSize>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public TSize Size { get; set; }
        public ClothingGender Gender { get; set; }
        public List<Color> Colors { get; set; }
        public List<Material> Materials { get; set; }
    }
}
