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

        public static string ToFriendlyString(this TopType t)
        {
            return t switch
            {
                TopType.TShirt => "T-Shirt",
                TopType.Shirt => "Koszula",
                TopType.Longsleeve => "Koszulka z długim rękawem",
                TopType.Crewneck => "Crewneck",
                TopType.Hoodie => "Bluza z kapturem",
                TopType.Sweater => "Sweter",
                TopType.Jacket => "Kurtka",
                TopType.Coat => "Płaszcz",
                TopType.Suit => "Garnitur",
                TopType.Dress => "Sukienka",
                _ => throw new NotImplementedException()
            };
        }

        public static string ToFriendlyString(this ShoeType s)
        {
            return s switch
            {
                ShoeType.Sneakers => "Sneakersy",
                ShoeType.Boots => "Botki",
                ShoeType.Sandals => "Sandały",
                ShoeType.Loafers => "Mokasyny",
                ShoeType.Heels => "Obcasy",
                ShoeType.Flats => "Płaskie buty",
                ShoeType.Slippers => "Kapcie",
                ShoeType.RunningShoes => "Buty do biegania",
                ShoeType.WorkShoes => "Buty robocze",
                _ => throw new NotImplementedException()
            };
        }

        public static string ToFriendlyString(this BottomType b)
        {
            return b switch
            {
                BottomType.Jeans => "Dżinsy",
                BottomType.Trousers => "Spodnie",
                BottomType.Shorts => "Szorty",
                BottomType.Skirt => "Spódnica",
                BottomType.Leggings => "Legginsy",
                BottomType.Sweatpants => "Spodnie dresowe",
                _ => throw new NotImplementedException()
            };
        }

        public static string ToFriendlyString(this AccessoryType a)
        {
            return a switch
            {
                AccessoryType.Belt => "Pasek",
                AccessoryType.Hat => "Czapka",
                AccessoryType.Scarf => "Szalik",
                AccessoryType.Gloves => "Rękawice",
                AccessoryType.Sunglasses => "Okulary przeciwsłoneczne",
                AccessoryType.Watch => "Zegarek",
                AccessoryType.Bag => "Torebka",
                AccessoryType.Jewelry => "Biżuteria",
                _ => throw new NotImplementedException()
            };
        }
    }
}
