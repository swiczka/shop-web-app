﻿using shop_web_app.Enums;

namespace shop_web_app.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string ?AppUserId { get; set; }
        public AppUser ?AppUser {  get; set; }
        public int VariantId { get; set; }
        public ProductVariant Variant { get; set; }
        public InternationalSize? InternationalSize { get; set; }
        public ShoeSize? ShoeSize { get; set; }
        public int Quantity { get; set; }
    }
}
