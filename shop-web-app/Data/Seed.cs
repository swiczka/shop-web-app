using Microsoft.AspNetCore.Identity;
using shop_web_app.Data;
using shop_web_app.Enums;
using shop_web_app.Models;
using shop_web_app.Models.SizeQuantity;
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
                                    ImageUrl = "https://www.hipanda.pl/wp-content/uploads/2021/07/019_42_101_f-2018_01.jpg_l.jpg",
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
                                    }
                                },
                                new ProductVariant()
                                {
                                    ImageUrl = "https://www.hipanda.pl/wp-content/uploads/2024/10/koszulka-damska-Grzaniec-Dzwoni-biala.png",
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
                                    ImageUrl = "https://www.hipanda.pl/wp-content/uploads/2021/07/019_42_101_f-2018_01.jpg_l.jpg",
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
            //    //Roles
            //    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //    if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
            //        await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            //    if (!await roleManager.RoleExistsAsync(UserRoles.User))
            //        await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            //    //Users
            //    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            //    string adminUserEmail = "teddysmithdeveloper@gmail.com";

            //    var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
            //    if (adminUser == null)
            //    {
            //        var newAdminUser = new AppUser()
            //        {
            //            UserName = "teddysmithdev",
            //            Email = adminUserEmail,
            //            EmailConfirmed = true,
            //            Address = new Address()
            //            {
            //                Street = "123 Main St",
            //                City = "Charlotte",
            //                State = "NC"
            //            }
            //        };
            //        await userManager.CreateAsync(newAdminUser, "Coding@1234?");
            //        await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
            //    }

            //    string appUserEmail = "user@etickets.com";

            //    var appUser = await userManager.FindByEmailAsync(appUserEmail);
            //    if (appUser == null)
            //    {
            //        var newAppUser = new AppUser()
            //        {
            //            UserName = "app-user",
            //            Email = appUserEmail,
            //            EmailConfirmed = true,
            //            Address = new Address()
            //            {
            //                Street = "123 Main St",
            //                City = "Charlotte",
            //                State = "NC"
            //            }
            //        };
            //        await userManager.CreateAsync(newAppUser, "Coding@1234?");
            //        await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
            //    }
            }
        }
    }
}
