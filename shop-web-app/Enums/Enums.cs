using System.ComponentModel.DataAnnotations;

namespace shop_web_app.Enums
{
    public enum Gender
    {
        [Display(Name = "Mężczyzna")]
        M,
        [Display(Name = "Kobieta")]
        F  
    }

    public enum Voivodship
    {
        [Display(Name = "dolnośląskie")] ///
        LowerSilesia,

        [Display(Name = "kujawsko-pomorskie")] ///
        KuyaviaPomerania,

        [Display(Name = "łódzkie")]
        Lodzkie,

        [Display(Name = "lubelskie")]
        Lublin,

        [Display(Name = "lubuskie")] ///
        Lubusz,

        [Display(Name = "małopolskie")]
        LesserPoland,

        [Display(Name = "mazowieckie")] ///
        Masovia,

        [Display(Name = "podkarpackie")]
        Subcarpathia,

        [Display(Name = "pomorskie")] ///
        Pomerania,

        [Display(Name = "śląskie")]
        Silesia,
         
        [Display(Name = "warmińsko-mazurskie")] ///
        WarmiaMasuria,

        [Display(Name = "wielkopolskie")] ///
        GreaterPoland,

        [Display(Name = "zachodnio-pomorskie")] ///
        WestPomerania,

        [Display(Name = "podlaskie")] ///
        Podlaskie,

        [Display(Name = "świętokrzyskie")]
        Swietokrzyskie,

        [Display(Name = "opolskie")]
        Opolskie
    }

    public enum ClothingGender
    {
        M,
        F,
        U
    }

    public enum Material
    {
        [Display(Name = "Bawełna")]
        Cotton,

        [Display(Name = "Poliester")]
        Polyester,

        [Display(Name = "Skóra")]
        Leather,

        [Display(Name = "Len")]
        Linen,

        [Display(Name = "Wiskoza")]
        Viscoze,

        [Display(Name = "Tworzywo sztuczne")]
        Plastic,

        [Display(Name = "Guma")]
        Rubber,

        [Display(Name = "Wełna")]
        Wool
    }

    public enum Color
    {
        [Display(Name = "Czerwony")]
        Red,

        [Display(Name = "Zielony")]
        Green,

        [Display(Name = "Niebieski")]
        Blue,

        [Display(Name = "Zółty")]
        Yellow,

        [Display(Name = "Biały")]
        White,

        [Display(Name = "Czarny")]
        Black,

        [Display(Name = "Szary")]
        Gray,

        [Display(Name = "Fioletowy")]
        Purple,

        [Display(Name = "Różowy")]
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
        [Display(Name = "T-Shirt")]
        TTShirt,

        [Display(Name = "Koszula")]
        TShirt,

        [Display(Name = "Koszulka z długim rękawem")]
        TLongsleeve,

        [Display(Name = "Crewneck")]
        TCrewneck,

        [Display(Name = "Bluza z kapturem")]
        THoodie,

        [Display(Name = "Sweter")]
        TSweater,

        [Display(Name = "Kurtka")]
        TJacket,

        [Display(Name = "Płaszcz")]
        TCoat,

        [Display(Name = "Garnitur")]
        TSuit,

        [Display(Name = "Sukienka")]
        TDress,

        // bottoms
        [Display(Name = "Dżinsy")]
        BJeans,

        [Display(Name = "Spodnie")]
        BTrousers,

        [Display(Name = "Szorty")]
        BShorts,

        [Display(Name = "Spódnica")]
        BSkirt,

        [Display(Name = "Legginsy")]
        BLeggings,

        [Display(Name = "Spodnie dresowe")]
        BSweatpants,

        // accessories
        [Display(Name = "Pasek")]
        ABelt,

        [Display(Name = "Czapka")]
        AHat,

        [Display(Name = "Szalik")]
        AScarf,

        [Display(Name = "Rękawice")]
        AGloves,

        [Display(Name = "Okulary przeciwsłoneczne")]
        ASunglasses,

        [Display(Name = "Zegarek")]
        AWatch,

        [Display(Name = "Torebka")]
        ABag,

        [Display(Name = "Biżuteria")]
        AJewelry,

        // shoes
        [Display(Name = "Sneakersy")]
        SSneakers,

        [Display(Name = "Botki")]
        SBoots,

        [Display(Name = "Sandały")]
        SSandals,

        [Display(Name = "Mokasyny")]
        SLoafers,

        [Display(Name = "Obcasy")]
        SHeels,

        [Display(Name = "Płaskie buty")]
        SFlats,

        [Display(Name = "Kapcie")]
        SSlippers,

        [Display(Name = "Buty do biegania")]
        SRunningShoes,

        [Display(Name = "Buty robocze")]
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
