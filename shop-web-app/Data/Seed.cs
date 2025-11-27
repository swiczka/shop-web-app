using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using shop_web_app.Data;
using shop_web_app.Enums;
using shop_web_app.Models;
using shop_web_app.Models.SizeQuantity;
using System;
using System.Diagnostics;

namespace shop_web_app.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Koszulka basic",
                            Price = 79.90m,
                            Description = "Wykonana z najlepszej bawełny.",
                            Category = Category.Top,
                            SubCategory = SubCategory.TTShirt,
                            Gender = ClothingGender.M,
                            ProductMaterials = new List<ProductMaterial>()
                            {
                                new ProductMaterial()
                                {
                                    Material = Material.Cotton
                                },
                                new ProductMaterial()
                                {
                                    Material = Material.Polyester
                                }
                            },
                            ProductVariants = new List<ProductVariant>()
                            {
                                new ProductVariant()
                                {
                                    Name = "Czarny",
                                    VariantColors = new List<VariantColor>()
                                    {
                                        new VariantColor()
                                        {
                                            Color = Color.Black
                                        }
                                    },
                                    InternationalSizeQuantity = new List<InternationalSizeQuantity>()
                                    {
                                        new InternationalSizeQuantity()
                                        {
                                            Size = InternationalSize.XS,
                                            Quantity = 5
                                        },
                                        new InternationalSizeQuantity()
                                        {
                                            Size = InternationalSize.S,
                                            Quantity = 10
                                        },
                                        new InternationalSizeQuantity()
                                        {
                                            Size = InternationalSize.M,
                                            Quantity = 20
                                        },
                                        new InternationalSizeQuantity()
                                        {
                                            Size = InternationalSize.L,
                                            Quantity = 5
                                        },
                                        new InternationalSizeQuantity()
                                        {
                                            Size = InternationalSize.XL,
                                            Quantity = 13
                                        },
                                        new InternationalSizeQuantity()
                                        {
                                            Size = InternationalSize.XXL,
                                            Quantity = 3
                                        }
                                    },
                                    Photos = new List<Photo>()
                                    {
                                        new Photo()
                                        {
                                            PhotoUrl = "https://image.hm.com/assets/hm/44/42/4442fbac4e3080ec20b2f14e353fea267249b0dd.jpg?imwidth=2160"
                                        }
                                    }
                                },
                                new ProductVariant()
                                {
                                    Name = "Biały z nadrukiem",
                                    VariantColors = new List<VariantColor>()
                                    {
                                        new VariantColor()
                                        {
                                            Color = Color.White
                                        }
                                    },
                                    InternationalSizeQuantity = new List<InternationalSizeQuantity>()
                                    {
                                        new InternationalSizeQuantity()
                                        {
                                            Size = InternationalSize.XS,
                                            Quantity = 0
                                        },
                                        new InternationalSizeQuantity()
                                        {
                                            Size = InternationalSize.S,
                                            Quantity = 4
                                        },
                                        new InternationalSizeQuantity()
                                        {
                                            Size = InternationalSize.M,
                                            Quantity = 20
                                        },
                                        new InternationalSizeQuantity()
                                        {
                                            Size = InternationalSize.L,
                                            Quantity = 14
                                        },
                                        new InternationalSizeQuantity()
                                        {
                                            Size = InternationalSize.XL,
                                            Quantity = 9
                                        },
                                        new InternationalSizeQuantity()
                                        {
                                            Size = InternationalSize.XXL,
                                            Quantity = 0
                                        }
                                    },
                                    Photos = new List<Photo>()
                                    {
                                        new Photo()
                                        {
                                            PhotoUrl = "https://image.hm.com/assets/hm/bd/e4/bde4ef42f917ccb678c4ff1d218520ce2f10ff6d.jpg?imwidth=2160"
                                        }
                                    }
                                },
                            }
                        },
                        new Product()
                        {
                            Name = "Spodnie eleganckie fest",
                            Price = 349.90m,
                            Description = "Granatowe spodnie marki Vestus to doskonały wybór do formalnych stylizacji. Wykonane z wysokiej jakości wełny z dodatkiem poliestru, łączą elegancję z funkcjonalnością.",
                            Category = Category.Bottom,
                            SubCategory = SubCategory.BTrousers,
                            Gender = ClothingGender.M,
                            ProductMaterials = new List<ProductMaterial>()
                            {
                                new ProductMaterial()
                                {
                                    Material = Material.Wool
                                },
                                new ProductMaterial()
                                {
                                    Material = Material.Polyester
                                }
                            },
                            ProductVariants = new List<ProductVariant>()
                            {
                                new ProductVariant()
                                {
                                    Name = "Granatowe",
                                    VariantColors = new List<VariantColor>()
                                    {
                                        new VariantColor()
                                        {
                                            Color = Color.Blue
                                        }
                                    },
                                    InternationalSizeQuantity = new List<InternationalSizeQuantity>()
                                    {
                                        new InternationalSizeQuantity()
                                        {
                                            Size = InternationalSize.XS,
                                            Quantity = 0
                                        },
                                        new InternationalSizeQuantity()
                                        {
                                            Size = InternationalSize.S,
                                            Quantity = 5
                                        },
                                        new InternationalSizeQuantity()
                                        {
                                            Size = InternationalSize.M,
                                            Quantity = 10
                                        },
                                        new InternationalSizeQuantity()
                                        {
                                            Size = InternationalSize.L,
                                            Quantity = 30
                                        },
                                        new InternationalSizeQuantity()
                                        {
                                            Size = InternationalSize.XL,
                                            Quantity = 12
                                        },
                                        new InternationalSizeQuantity()
                                        {
                                            Size = InternationalSize.XXL,
                                            Quantity = 4
                                        }
                                    },
                                    Photos = new List<Photo>()
                                    {
                                        new Photo()
                                        {
                                            PhotoUrl = "https://vistula.pl/mis/b/-30392.webp"
                                        }
                                    }
                                }
                            }
                        },


                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.Customer))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Customer));
                if (!await roleManager.RoleExistsAsync(UserRoles.Employee))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Employee));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "ak@ak.pl";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        Name = "Anna",
                        Surname = "Kowalska",
                        UserName = adminUserEmail.Split('@')[0],
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Gender = Gender.M,
                        Address = new Address()
                        {
                            Street = "Polna 1",
                            City = "Kraków",
                            PostalCode = "33-333",
                            Voivodship = Voivodship.LesserPoland
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Abc-1234");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "jk@jk.pl";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        Name = "Jan",
                        Surname = "Kowalski",
                        UserName = appUserEmail.Split('@')[0],
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Gender = Gender.M,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Charlotte",
                            PostalCode = "33-333",
                            Voivodship = Voivodship.Masovia
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "Abc-1234");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.Customer);
                }

                string appEmployeeEmail = "dj@dj.pl";

                var appEmployee = await userManager.FindByEmailAsync(appUserEmail);
                if (appEmployee == null)
                {
                    var newEmployeeUser = new AppUser()
                    {
                        Name = "Dominik",
                        Surname = "Jachaś",
                        UserName = appEmployeeEmail.Split('@')[0],
                        Email = appEmployeeEmail,
                        EmailConfirmed = true,
                        Gender = Gender.M,
                        Address = new Address()
                        {
                            Street = "W. Pola 4",
                            City = "Rzeszów",
                            PostalCode = "35-333",
                            Voivodship = Voivodship.Subcarpathia
                        }
                    };
                    await userManager.CreateAsync(newEmployeeUser, "Abc-1234");
                    await userManager.AddToRoleAsync(newEmployeeUser, UserRoles.Employee);
                }
            }
        }


        private struct SeedProduct
        {
            public string Name { get; set; }
            public string Url { get; set; }
            public SubCategory Category { get; set; }
            public string Description { get; set; }
            public const string descriptionBase = "Nowoczesny design, wygodny krój i najwyższej jakości materiały. Idealny wybór na każdą okazję.";


            public SeedProduct(string name, SubCategory category, string url, string description = "")
            {
                Name = name;
                Category = category;
                Url = url;
                Description = descriptionBase + " " + description;
            }
        }


        public static async Task SeedProductsAsync(IApplicationBuilder applicationBuilder)
        {

            List<Product> products = new List<Product>();

            List<List<SeedProduct>> maleProducts = new List<List<SeedProduct>>()
            {
                new List<SeedProduct>()
                {
                    new SeedProduct( "Koszulka", SubCategory.TTShirt, "https://cdn.pixabay.com/photo/2025/06/06/06/07/t-shirt-9644090_1280.jpg", "Źródło: https://t-shirtbedrucken.ch/"),
                    new SeedProduct( "Koszula długa", SubCategory.TShirt, "https://cdn.pixabay.com/photo/2020/10/18/15/55/man-5665175_1280.jpg", "Źródło: Virat Maurya"),
                    new SeedProduct( "Bluza oversize", SubCategory.THoodie, "https://cdn.pixabay.com/photo/2019/06/09/06/02/black-4261521_1280.jpg", "Źródło: unpetitvoyou"),
                },

                new List<SeedProduct>()
                {
                    new SeedProduct( "Jeansy długie", SubCategory.BJeans, "https://pixabay.com/photos/fashion-shooting-guy-man-male-601563/", "Źródło: stokpic"),
                    new SeedProduct( "Szorty sportowe", SubCategory.BShorts, "https://images.pexels.com/photos/1103832/pexels-photo-1103832.jpeg", "Zdjęcie dodane przez Oliver Sjöström"),
                    new SeedProduct( "Spodnie do garnituru", SubCategory.BTrousers,"https://images.pexels.com/photos/26336888/pexels-photo-26336888.jpeg", "Zdjęcie dodane przez Pro5 vn"),
                },

                new List<SeedProduct>()
                {
                    new SeedProduct( "Buty zimowe", SubCategory.SBoots, "https://images.pexels.com/photos/30272896/pexels-photo-30272896.jpeg", "Zdjęcie dodane przez 丹 师"),
                    new SeedProduct( "Sneakersy firmowe", SubCategory.SSneakers, "https://images.pexels.com/photos/1306248/pexels-photo-1306248.jpeg", "Zdjęcie dodane przez Hassan OUAJBIR"),
                    new SeedProduct( "Mokasyny", SubCategory.SLoafers, "https://images.pexels.com/photos/9003700/pexels-photo-9003700.jpeg", "Zdjęcie dodane przez Nida Kurt"),
                },
            };

            List<List<SeedProduct>> femaleProducts = new List<List<SeedProduct>>()
            {
                new List<SeedProduct>()
                {
                    new SeedProduct( "Koszulka z nadrukiem", SubCategory.TTShirt, "https://images.pexels.com/photos/17243664/pexels-photo-17243664.jpeg", "Zdjęcie dodane przez PeopleByOwen"),
                    new SeedProduct( "Koszula dżinsowa", SubCategory.TShirt, "https://images.pexels.com/photos/17245475/pexels-photo-17245475.jpeg", "Zdjęcie dodane przez PeopleByOwen"),
                    new SeedProduct("Płaszcz", SubCategory.TCoat, "https://images.pexels.com/photos/31539427/pexels-photo-31539427.jpeg", "Zdjęcie dodane przez Mohammed Hassan" ),
                },

                new List<SeedProduct>()
                {
                    new SeedProduct( "Luźne spodnie", SubCategory.BTrousers, "https://images.pexels.com/photos/5566711/pexels-photo-5566711.jpeg", "Zdjęcie dodane przez Thegiansepillo"),
                    new SeedProduct("Spódnica tenisowa sportowa", SubCategory.BSkirt, "https://images.pexels.com/photos/17243494/pexels-photo-17243494.jpeg", "Zdjęcie dodane przez PeopleByOwen"),
                    new SeedProduct("Dresy sportowe", SubCategory.BSweatpants, "https://images.pexels.com/photos/17039171/pexels-photo-17039171.jpeg", "Zdjęcia dodane przez Navid Sohrabi"),
                },

                new List<SeedProduct>()
                {
                    new SeedProduct( "Szpilki skórzane", SubCategory.SHeels, "https://images.pexels.com/photos/33505984/pexels-photo-33505984.jpeg", "Zdjęcie dodane przez Mert Coşkun"),
                    new SeedProduct("Sandały", SubCategory.SSandals, "https://images.pexels.com/photos/4943900/pexels-photo-4943900.jpeg", "Zdjęcie dodane przez Anastasia Shuraeva"),
                    new SeedProduct("Sneakersy skórzane", SubCategory.SSneakers, "https://cdn.pixabay.com/photo/2018/12/05/13/41/woman-3857758_1280.jpg0"),
                },
            };


            Random rnd = new Random();

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                await context.Database.EnsureCreatedAsync();

                for (int i = 0; i < 300; i++)
                {
                    var gender = rnd.Next(2); //0 - female, 1 - male
                    var category = rnd.Next(3); //0 - top, 1 - bottom, 2 - shoes

                    string name = "", photo = "", description= "";
                    SubCategory subcategory = SubCategory.TShirt;

                    var rndIndex = rnd.Next(3);
                    if (gender == 0)
                    {
                        name = femaleProducts[category][rndIndex].Name;
                        photo = femaleProducts[category][rndIndex].Url;
                        subcategory = femaleProducts[category][rndIndex].Category;
                        description = femaleProducts[category][rndIndex].Description;
                    }
                    else if (gender == 1)
                    {
                        name = maleProducts[category][rndIndex].Name;
                        photo = maleProducts[category][rndIndex].Url;
                        subcategory = maleProducts[category][rndIndex].Category;
                        description = maleProducts[category][rndIndex].Description;
                    }

                    List<ShoeSizeQuantity> ssq = null;
                    List<InternationalSizeQuantity> isq = null;

                    if(category == 2)
                    {
                        ssq = new List<ShoeSizeQuantity>();
                        foreach(ShoeSize size in Enum.GetValues(typeof(ShoeSize)))
                        {
                            ssq.Add(new ShoeSizeQuantity()
                            {
                                Size = size,
                                Quantity = rnd.Next(10)
                            });
                        }
                    }
                    else
                    {
                        isq = new List<InternationalSizeQuantity>();
                        foreach (InternationalSize size in Enum.GetValues(typeof(InternationalSize)))
                        {
                            isq.Add(new InternationalSizeQuantity()
                            {
                                Size = size,
                                Quantity = rnd.Next(10)
                            });
                        }
                    }
 
                    products.Add
                    (
                        new Product()
                        {
                            Name = name,
                            Price = Math.Round((decimal)(rnd.NextDouble() * 350 + 50), 2),
                            Description = description,
                            Category = category == 2 ? Category.Shoes : (Category)category,
                            SubCategory = subcategory,
                            Gender = gender == 0 ? ClothingGender.F : ClothingGender.M,
                            ProductMaterials = new List<ProductMaterial>()
                            {
                                new ProductMaterial()
                                {
                                    Material = (Material)rnd.Next(0, Enum.GetValues(typeof(Material)).Length)
                                },
                            },
                            ProductVariants = new List<ProductVariant>()
                            {
                                new ProductVariant()
                                {
                                    Name = "Wariant " + rnd.Next(100000).ToString("X"),
                                    VariantColors = new List<VariantColor>()
                                    {
                                        new VariantColor()
                                        {
                                            Color = (Color)rnd.Next(0, Enum.GetValues(typeof(Color)).Length)
                                        }
                                    },
                                    InternationalSizeQuantity = isq,
                                    ShoeSizeQuantity = ssq,
                                    Photos = new List<Photo>()
                                    {
                                        new Photo()
                                        {
                                            PhotoUrl = photo
                                        }
                                    }
                                },
                            }
                        }
                    );
                 
                }

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }
    }
}
