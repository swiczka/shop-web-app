//Class with basic fields shared by all kinds of clothing: shoes, shirts, pants, etc..

using shop_web_app.Enums;
using shop_web_app.Models.SizeQuantity;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.Models.Clothing
{
    public class Clothing : ClothingItem<InternationalSizeQuantity, ClothingType>
    {
    }
}
