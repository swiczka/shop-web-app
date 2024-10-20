namespace shop_web_app.Enums
{
    public enum Gender
    {
        M,
        F  
    }

    public enum Voivodship
    {
        LowerSilesia,
        KuyaviaPomerania,
        Lodzkie,
        Lublin,
        Lubusz,
        LesserPoland,
        Masovia,
        Subcarpathia,
        Pomerania,
        Silesia,
        WarmiaMasuria,
        GreaterPoland,
        WestPomerania
    }

    public enum ClothingGender
    {
        M,
        F,
        U
    }

    public enum Material
    {
        Cotton,       
        Polyester,    
        Leather,      
        Linen,        
        Viscoze,      
        Plastic,     
        Rubber,
        Wool
    }

    public enum Color
    {
        Red,
        Green,
        Blue,
        Yellow,
        White,
        Black,
        Gray,
        Purple,
        Pink
    }

    public enum InternationalSize
    {
        XS,
        S,
        M,
        L,
        XL,
        XXL,
        OneSize
    }

    public enum ShoeSize
    {
        Size35,
        Size35_5,
        Size36,
        Size36_5,
        Size37,
        Size37_5,
        Size38,
        Size38_5,
        Size39,
        Size39_5,
        Size40,
        Size40_5,
        Size41,
        Size41_5,
        Size42,
        Size42_5,
        Size43,
        Size43_5,
        Size44,
        Size44_5,
        Size45,
        Size45_5,
        Size46
    }

    public enum Category
    {
        Top,
        Bottom,
        Accessory,
        Shoes,
    }

    public enum SubCategory
    {
        // tops
        TTShirt,
        TShirt,
        TLongsleeve,
        TCrewneck,
        THoodie,
        TSweater,
        TJacket,
        TCoat,
        TSuit,
        TDress,
        // bottoms
        BJeans,
        BTrousers,
        BShorts,
        BSkirt,
        BLeggings,
        BSweatpants,
        // accessories
        ABelt,
        AHat,
        AScarf,
        AGloves,
        ASunglasses,
        AWatch,
        ABag,
        AJewelry,
        // shoes
        SSneakers,
        SBoots,
        SSandals,
        SLoafers,
        SHeels,
        SFlats,
        SSlippers,
        SRunningShoes,
        SWorkShoes
    }


    public enum ClothingType
    {
        // tops
        TShirt,      
        Shirt,       
        Longsleeve,  
        Crewneck,    
        Hoodie,      
        Sweater,     
        Jacket,      
        Coat,        
        Suit,
        Dress,
        // bottoms
        Jeans,
        Trousers,
        Shorts,
        Skirt,
        Leggings,
        Sweatpants,
        // accessories
        Belt,
        Hat,
        Scarf,
        Gloves,
        Sunglasses,
        Watch,
        Bag,
        Jewelry
    }

    public enum ShoeType
    {
        Sneakers,     
        Boots,        
        Sandals,      
        Loafers,      
        Heels,        
        Flats,        
        Slippers,     
        RunningShoes, 
        WorkShoes     
    }

    public enum OrderStatus
    {
        OrderPlaced,
        OrderConfirmed,
        Shipped,
        InTransit,
        Out,
        Delivered,
        Canceled,
        Delayed,
        Lost
    }
}
