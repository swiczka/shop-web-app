using shop_web_app.Enums;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.ViewModels
{
    public class ShoeSizeQuantityViewModel
    {
        public int? Id { get; set; }
        public ShoeSize Size { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Count has to be a positive integer")]
        public int Quantity { get; set; }
    }
}
