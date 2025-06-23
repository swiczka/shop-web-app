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

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "aw@aw.pl";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        Name = "Anita",
                        Surname = "Włodarczyk",
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

                string appUserEmail = "user@etickets.com";

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
            }
        }

        private struct SeedProduct
        {
            public string Name { get; set; }
            public string Url { get; set; }
            public SubCategory Category { get; set; }

            public SeedProduct(string name, SubCategory category, string url)
            {
                Name = name;
                Category = category;
                Url = url;
            }
        }

        public static async Task SeedProductsAsync(IApplicationBuilder applicationBuilder)
        {

            List<Product> products = new List<Product>();

            List<List<SeedProduct>> maleProducts = new List<List<SeedProduct>>()
            {
                new List<SeedProduct>()
                {
                    new SeedProduct( "Koszulka", SubCategory.TTShirt, "https://image.hm.com/assets/hm/bd/e4/bde4ef42f917ccb678c4ff1d218520ce2f10ff6d.jpg?imwidth=2160"),
                    new SeedProduct( "Koszula krótka", SubCategory.TShirt, "https://image.hm.com/assets/003/cd/a2/cda2e1faeca59c0d2c122bf276692bc60f929290.jpg?imwidth=2160"),
                    new SeedProduct( "Bluza oversize", SubCategory.THoodie, "https://image.hm.com/assets/hm/db/ff/dbffa3571b9d73c6762519abda9ce3a75a30be0c.jpg?imwidth=2160"),
                },

                new List<SeedProduct>()
                {
                    new SeedProduct( "Jeansy długie", SubCategory.BJeans, "https://image.hm.com/assets/003/12/66/12666c1a776145d3c39ef0f2845c4771c465fb69.jpg?imwidth=2160"),
                    new SeedProduct( "Szorty dresowe", SubCategory.BShorts, "https://image.hm.com/assets/hm/0f/88/0f88b5de0e3d346f47acf4a549f9783fccbe6695.jpg?imwidth=2160"),
                    new SeedProduct( "Spodnie do garnituru luźne", SubCategory.BTrousers,"https://image.hm.com/assets/003/20/ba/20ba3499ffc465d3070a0a3e334ac69d7ff33787.jpg?imwidth=2160"),
                },

                new List<SeedProduct>()
                {
                    new SeedProduct( "Półbuty", SubCategory.SFlats, "https://image.hm.com/assets/006/0a/53/0a53025a1a93e9ab5ec44d9a64c1b2f1b6005056.jpg?imwidth=2160"),
                    new SeedProduct( "Sneakersy firmowe", SubCategory.SSneakers, "https://image.hm.com/assets/hm/f1/23/f123c2924cef1ac4cdb18281a525ffd24db9b345.jpg?imwidth=1260"),
                    new SeedProduct( "Kapcie", SubCategory.SSlippers, "https://image.hm.com/assets/hm/19/bd/19bd62900b43c4dc4025cd4bfe50bc240fdfe9b5.jpg?imwidth=1260"),
                },
            };

            List<List<SeedProduct>> femaleProducts = new List<List<SeedProduct>>()
            {
                new List<SeedProduct>()
                {
                    new SeedProduct( "Koszulka V-neck", SubCategory.TTShirt, "https://image.hm.com/assets/001/65/e7/65e7a06a2a34707ed4c60e4f1f1241e6b2f2a6d7.jpg?imwidth=2160"),
                    new SeedProduct( "Koszula kopertowa", SubCategory.TShirt, "https://image.hm.com/assets/005/9f/36/9f364f6c4f71adffbe4910432d4417a1fa883633.jpg?imwidth=2160"),
                    new SeedProduct("Sukienka", SubCategory.TDress, "https://image.hm.com/assets/hm/93/48/9348e116430b21343f1335e9d4cddccce3529b88.jpg?imwidth=2160"),
                },

                new List<SeedProduct>()
                {
                    new SeedProduct( "Jeansy szerokie", SubCategory.BJeans, "https://image.hm.com/assets/hm/e7/9b/e79bf614691fa1b4ca4ef9603ad0a1bce3d8375b.jpg?imwidth=2160"),
                    new SeedProduct("Spódnica tenisowa sportowa", SubCategory.BSkirt, "https://image.hm.com/assets/hm/cf/cd/cfcd7d7c46c5ffdca5cef001af235b78faeea301.jpg?imwidth=1260"),
                    new SeedProduct("Legginsy", SubCategory.BLeggings, "https://image.hm.com/assets/hm/20/c1/20c1de12d91f5b350aacc7886f020b49b59e2b69.jpg?imwidth=2160"),
                },

                new List<SeedProduct>()
                {
                    new SeedProduct( "Szpilki", SubCategory.SHeels, "https://image.hm.com/assets/hm/32/cb/32cbb7522957f90e3bbe554c6498ff7710c775d9.jpg?imwidth=1260"),
                    new SeedProduct("Sandały", SubCategory.SSandals, "https://image.hm.com/assets/hm/49/a6/49a61c2ea20f5f9d235ac9084138b2d04d274064.jpg?imwidth=1260"),
                    new SeedProduct("Sneakersy na podbiciu", SubCategory.SSneakers, "https://image.hm.com/assets/hm/dd/13/dd13c749d3375df744d4033f589f02560d6e3c47.jpg?imwidth=1260"),
                },
            };

            string descriptionBase = "Nowoczesny design, wygodny krój i najwyższej jakości materiały. Idealny wybór na każdą okazję.";

            Random rnd = new Random();

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                await context.Database.EnsureCreatedAsync();

                for (int i = 0; i < 300; i++)
                {
                    var gender = rnd.Next(2); //0 - female, 1 - male
                    var category = rnd.Next(3); //0 - top, 1 - bottom, 2 - shoes

                    string name = "", photo = "";
                    SubCategory subcategory = SubCategory.TShirt;

                    var rndIndex = rnd.Next(3);
                    if (gender == 0)
                    {
                        name = femaleProducts[category][rndIndex].Name;
                        photo = femaleProducts[category][rndIndex].Url;
                        subcategory = femaleProducts[category][rndIndex].Category;
                    }
                    else if (gender == 1)
                    {
                        name = maleProducts[category][rndIndex].Name;
                        photo = maleProducts[category][rndIndex].Url;
                        subcategory = maleProducts[category][rndIndex].Category;
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
                            Description = descriptionBase,
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
