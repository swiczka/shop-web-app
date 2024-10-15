//Interface with basic fields shared by all kinds of clothing: shoes, shirts, pants, etc..

using shop_web_app.Enums;

namespace shop_web_app.Interfaces
{
    public interface IClothingItem<TSizeQuantity>
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
        List<TSizeQuantity> SizeQuantity { get; set; }
        ClothingGender Gender { get; set; }
        List<Color> Colors { get; set; }
        List<Material> Materials { get; set; }
    }
}
