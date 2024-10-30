using System.ComponentModel.DataAnnotations;
using shop_web_app.Enums;

namespace shop_web_app.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string Description { get; set; } = "";
        public ClothingGender Gender { get; set; }
        public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
        public ICollection<ProductMaterial> ProductMaterials { get; set; } = new List<ProductMaterial>();
        public Category Category { get; set; }
        public SubCategory SubCategory { 
            //get
            //{
            //    return SubCategory;
            //}
            //set 
            //{
            //    if(Category == null)
            //    {
            //        throw new Exception("Category has to be picked first");
            //    }
                
            //    if (Category.ToString()[0] != value.ToString()[0])
            //    {
            //        throw new Exception("No valid Subcategory was picked");
            //    }
            //    SubCategory = value;
            //}
            get; set;
        }
         
    }
}
