using shop_web_app.Enums;
using System.ComponentModel.DataAnnotations;

namespace shop_web_app.ViewModels
{
    public class InternationalSizeQuantityViewModel
    {
        public InternationalSize Size { get; set; }  // Na przykład: "S", "M", "L" lub rozmiary butów "35", "36"

        [Range(0, int.MaxValue, ErrorMessage = "Count has to be a positive integer")]
        public int Quantity { get; set; }
    }
}
