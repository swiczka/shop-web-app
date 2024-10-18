﻿using shop_web_app.Enums;
using System.ComponentModel.DataAnnotations;
using shop_web_app.Models.SizeQuantity;

namespace shop_web_app.Models
{
    public class ProductVariant
    {
        [Key]
        public int Id { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public ICollection<VariantMaterial> VariantMaterials { get; set; } = new List<VariantMaterial>();
        public ICollection<VariantColor> VariantColors { get; set; } = new List<VariantColor>();

        //depending of clothing kind, one remains null
        public ICollection<InternationalSizeQuantity> ?InternationalSizeQuantity { get; set; }
        public ICollection<ShoeSizeQuantity> ?ShoeSizeQuantity { get; set; }
    }
}
