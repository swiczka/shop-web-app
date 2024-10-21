namespace shop_web_app.Enums
{
    public static class EnumExtensions
    {
        public static string ToFriendlyString(this Gender g)
        {
            return g switch
            {
                Gender.F => "Kobieta",
                Gender.M => "Mężczyzna",
                _ => throw new NotImplementedException()
            };
        }

        public static string ToFriendlyString(this ClothingGender g)
        {
            return g switch
            {
                ClothingGender.F => "Kobieta",
                ClothingGender.M => "Mężczyzna",
                ClothingGender.U => "Uniseks",
                _ => throw new NotImplementedException()
            };
        }


        public static string ToFriendlyString(this Voivodship v)
        {
            return v switch
            {
                Voivodship.LowerSilesia => "dolnośląskie",
                Voivodship.KuyaviaPomerania => "kujawsko-pomorskie",
                Voivodship.Lodzkie => "łódzkie",
                Voivodship.Lublin => "lubelskie",
                Voivodship.Lubusz => "lubuskie",
                Voivodship.LesserPoland => "małopolskie",
                Voivodship.Masovia => "mazowieckie",
                Voivodship.Subcarpathia => "podkarpackie",
                Voivodship.Pomerania => "pomorskie",
                Voivodship.Silesia => "śląskie",
                Voivodship.WarmiaMasuria => "warmińsko-mazurskie",
                Voivodship.GreaterPoland => "wielkopolskie",
                Voivodship.WestPomerania => "zachodniopomorskie",
                _ => throw new NotImplementedException()
            };
        }

        public static string ToFriendlyString(this Material m)
        {
            return m switch
            {
                Material.Linen => "Len",
                Material.Leather => "Skóra naturalna",
                Material.Cotton => "Bawełna",
                Material.Plastic => "Tworzywo sztuczne",
                Material.Polyester => "Poliester",
                Material.Rubber => "Guma",
                Material.Viscoze => "Wiskoza",
                _ => throw new NotImplementedException()
            };
        }

        public static string ToFriendlyString(this Color c)
        {
            return c switch
            {
                Color.Red => "Czerwony",
                Color.Green => "Zielony",
                Color.Blue => "Niebieski",
                Color.Yellow => "Zółty",
                Color.White => "Biały",
                Color.Black => "Czarny",
                Color.Gray => "Szary",
                Color.Purple => "Fioletowy",
                Color.Pink => "Różowy",
                _ => throw new NotImplementedException()
            };
        }

        public static string ToFriendlyString(this InternationalSize s)
        {
            return s.ToString();
        }

        public static string ToFriendlyString(this ShoeSize s)
        {
            string s1 = s.ToString();
            s1 = s1.Substring(4);
            if(s1.Contains('_'))
            {
                s1 = s1.Replace('_', '.');
            }
            return s1;
        }

        public static string ToFriendlyString(this SubCategory s)
        {
            return s switch
            {
                SubCategory.TTShirt => "T-Shirt",
                SubCategory.TShirt => "Koszula",
                SubCategory.TLongsleeve => "Koszulka z długim rękawem",
                SubCategory.TCrewneck => "Crewneck",
                SubCategory.THoodie => "Bluza z kapturem",
                SubCategory.TSweater => "Sweter",
                SubCategory.TJacket => "Kurtka",
                SubCategory.TCoat => "Płaszcz",
                SubCategory.TSuit => "Garnitur",
                SubCategory.TDress => "Sukienka",
                SubCategory.BJeans => "Dżinsy",
                SubCategory.BTrousers => "Spodnie",
                SubCategory.BShorts => "Szorty",
                SubCategory.BSkirt => "Spódnica",
                SubCategory.BLeggings => "Legginsy",
                SubCategory.BSweatpants => "Spodnie dresowe",
                SubCategory.ABelt => "Pasek",
                SubCategory.AHat => "Czapka",
                SubCategory.AScarf => "Szalik",
                SubCategory.AGloves => "Rękawice",
                SubCategory.ASunglasses => "Okulary przeciwsłoneczne",
                SubCategory.AWatch => "Zegarek",
                SubCategory.ABag => "Torebka",
                SubCategory.AJewelry => "Biżuteria",
                SubCategory.SSneakers => "Sneakersy",
                SubCategory.SBoots => "Botki",
                SubCategory.SSandals => "Sandały",
                SubCategory.SLoafers => "Mokasyny",
                SubCategory.SHeels => "Obcasy",
                SubCategory.SFlats => "Płaskie buty",
                SubCategory.SSlippers => "Kapcie",
                SubCategory.SRunningShoes => "Buty do biegania",
                SubCategory.SWorkShoes => "Buty robocze",
                _ => throw new NotImplementedException()
            };
        }

        public static string ToFriendlyString(this ShoeType s)
        {
            return s switch
            {
                
                _ => throw new NotImplementedException()
            };
        }

        public static string ToFriendlyString(this Category c)
        {
            return c switch
            {
                Category.Top => "Góra",
                Category.Bottom => "Dół",
                Category.Shoes => "Buty",
                Category.Accessory => "Akcesoria",
                _ => throw new NotImplementedException()
            };
        }
    }
}
