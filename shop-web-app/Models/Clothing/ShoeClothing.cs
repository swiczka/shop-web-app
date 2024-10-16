using shop_web_app.Enums;
using shop_web_app.Interfaces;
using shop_web_app.Models.SizeQuantity;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.Models.Clothing
{
    public class ShoeClothing : ClothingItem
    {
        public new List<ShoeSizeQuantity> SizeQuantity { get; set; } = new List<ShoeSizeQuantity>();   
        public new ShoeType Type { get; set; }
    }
}
