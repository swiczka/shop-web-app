﻿using Microsoft.AspNetCore.Identity;
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
                                            PhotoUrl = "https://www.hipanda.pl/wp-content/uploads/2021/07/019_42_101_f-2018_01.jpg_l.jpg"
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
                                            PhotoUrl = "https://www.hipanda.pl/wp-content/uploads/2024/10/koszulka-damska-Grzaniec-Dzwoni-biala.png"
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
                string adminUserEmail = "teddysmithdeveloper@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        Name = "Teddy",
                        Surname = "Smith",
                        UserName = adminUserEmail.Split('@')[0],
                        Email = adminUserEmail,
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
    }
}
