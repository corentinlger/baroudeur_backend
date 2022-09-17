using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using baroudeurs.Models;

namespace baroudeurs.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new baroudeursContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<baroudeursContext>>()))
            {
                // Look for any students.
                if (context.Cities.Any())
                {
                    return;   // DB has been seeded
                }

                // City
                context.Cities.AddRange(
                    new City
                    {
                        Id = 1,
                        Name = "Bordeaux",
                        Description = "Bordeaux, au cœur de la région viticole, est une ville portuaire située sur la Garonne, dans le sud-ouest de la France. ",
                    },

                    new City
                    {
                        Id = 2,
                        Name = "Paris",
                        Description = "Paris, capitale de la France, est une grande ville européenne et un centre mondial de l'art, de la mode, de la gastronomie et de la culture.",
                    }
                );

                // Points of Interest

                context.PointOfInterests.AddRange(
                    new PointOfInterest
                    {
                        Id = 1,
                        Name = "Grand Theatre",
                        Description = "Théâtre majestueux dont la façade date de 1780, accueillant des opéras, concerts et spectacles de danse.",
                        IsEssential = true,
                        Theme = Theme.Culture,
                        PointType = PointType.Monument,
                        Latitude = "44.84313851912286",
                        Longitude = "-0.5711948257750703",
                        CityId = 1,                
                    },

                    new PointOfInterest
                    {
                        Id = 2,
                        Name = "Musée d'Aquitaine",
                        Description = "...",
                        IsEssential = false,
                        Theme = Theme.Culture,
                        PointType = PointType.Musée,
                        Latitude = "44.8360765535521",
                        Longitude = "-0.5719515257750704",
                        CityId = 1,
                    },
                    new PointOfInterest
                    {
                        Id = 3,
                        Name = "Chez Coluche",
                        Description = "Élu meilleur kebab de Bordeaux",
                        IsEssential = false,
                        Theme = Theme.Gastronomie,
                        PointType = PointType.Monument,
                        Latitude = "44.83926163301515",
                        Longitude = "-0.5718834870490354",
                        CityId = 1,
                    },
                    new PointOfInterest
                    {
                        Id = 4,
                        Name = "Place de la comédie",
                        Description = "La Place de la Comédie est belle de jour mais, elles est sublime en soirée. A l'époque romaine, la Place de la Comédie était occupée par un temple gallo-romain.",
                        IsEssential = false,
                        Theme = Theme.Architecture,
                        PointType = PointType.Place,
                        Latitude = "44.84282186704597",
                        Longitude = "-0.5743382597215225",
                        CityId = 1,
                    },
                    new PointOfInterest
                    {
                        Id = 5,
                        Name = "Quais de Bordeaux",
                        Description = "Les quais de Bordeaux sont les voies aménagées en bord de la Garonne",
                        IsEssential = true,
                        Theme = Theme.Architecture,
                        PointType = PointType.Place,
                        Latitude = "44.85080668398512",
                        Longitude = " -0.5696786600606973",
                        CityId = 1,
                    },
                    new PointOfInterest
                    {
                        Id = 6,
                        Name = "Pont de Pierre",
                        Description = "Le pont de pierre est un pont à voûtes en maçonnerie franchissant la Garonne à Bordeaux. Il permet de relier le centre-ville au quartier de La Bastide, sur la rive droite.",
                        IsEssential = false,
                        Theme = Theme.Histoire,
                        PointType = PointType.Monument,
                        Latitude = "44.83870174227385",
                        Longitude = " -0.562592273555117",
                        CityId = 1,
                    },
                    new PointOfInterest
                    {
                        Id = 7,
                        Name = "Cathédrale Saint André",
                        Description = "La cathédrale primatiale Saint-André de Bordeaux, située sur la place Pey-Berland, est le lieu de culte le plus imposant de Bordeaux. Il s'agit de l'église-cathédrale de l'archidiocèse de Bordeaux.",
                        IsEssential = true,
                        Theme = Theme.Histoire,
                        PointType = PointType.Eglise,
                        Latitude = "  44.83778922900349",
                        Longitude = "-0.5775622140369405",
                        CityId = 1,
                    },

                    new PointOfInterest
                    {
                        Id = 8,
                        Name = "Tour Eiffel",
                        Description = "La tour Eiffel est une tour de fer puddlé de 324 mètres de hauteur située à Paris, à l’extrémité nord-ouest du parc du Champ-de-Mars en bordure de la Seine dans le 7ᵉ arrondissement.",
                        IsEssential = true,
                        Theme = Theme.Histoire,
                        PointType = PointType.Monument,
                        Latitude = "48.858518312682094",
                        Longitude = "2.2944920266071485",
                        CityId = 2,
                    },

                    new PointOfInterest
                    {
                        Id = 9,
                        Name = "Musée d'Orsay",
                        Description = "Le musée d’Orsay est un musée national inauguré en 1986. ",
                        IsEssential = false,
                        Theme = Theme.Culture,
                        PointType = PointType.Musée,
                        Latitude = "48.86007431546632",
                        Longitude = "2.3265935842779464",
                        CityId = 2,
                    },

                    new PointOfInterest
                    {
                        Id = 10,
                        Name = " La terrasse panoramique du Printemps - Haussmann",
                        Description = "Le magasin amiral se situe boulevard Haussmann dans le 9e arrondissement de Paris.",
                        IsEssential = true,
                        Theme = Theme.Architecture,
                        PointType = PointType.PointdeVue,
                        Latitude = "48.87399640088461",
                        Longitude = "2.328064948053239",
                        CityId = 2,
                    },

                    new PointOfInterest
                    {
                        Id = 11,
                        Name = "Cathédrale Notre-Dame de Paris",
                        Description = "La cathédrale Notre-Dame de Paris, communément appelée Notre-Dame, est l'un des monuments les plus emblématiques de Paris et de la France.",
                        IsEssential = true,
                        Theme = Theme.Culture,
                        PointType = PointType.Eglise,
                        Latitude = "48.853095250220406",
                        Longitude = "2.3499664707837224",
                        CityId = 2,
                    },

                    new PointOfInterest
                    {
                        Id = 12,
                        Name = " La Table de Colette",
                        Description = "Restaurant écoresponsable et gastronomique doté d'une terrasse, proposant des menus de 3 à 7 plats avec des accords mets et vins.",
                        IsEssential = false,
                        Theme = Theme.Gastronomie,
                        PointType = PointType.Monument,
                        Latitude = "48.84745274544771",
                        Longitude = " 2.3472187977713608",
                        CityId = 2,
                    }

                );

                // Users
                context.Users.AddRange(
                    new User
                    {
                        Id = 1,
                        Username = "blaran",
                        AccountCreation = DateTime.Parse("2021-01-01"),
                        LastConnection = DateTime.Today,
                        IsOnline = true
                    },
                    new User
                    {
                        Id = 2,
                        Username = "cleger",
                        AccountCreation = DateTime.Parse("2021-01-05"),
                        LastConnection = DateTime.Today,
                        IsOnline = true
                    },
                    new User
                    {
                        Id = 3,
                        Username = "snimal",
                        AccountCreation = DateTime.Parse("2021-05-07"),
                        LastConnection = DateTime.Parse("2021-06-07"),
                        IsOnline = false
                    },
                    
                    new User
                    {
                        Id = 4,
                        Username = "emischis",
                        AccountCreation = DateTime.Parse("2021-08-28"),
                        LastConnection = DateTime.Parse("2021-12-15"),
                        IsOnline = false
                    },
                    new User
                    {
                        Id = 5,
                        Username = "ebrossard",
                        AccountCreation = DateTime.Parse("2022-01-05"),
                        LastConnection = DateTime.Today,
                        IsOnline = true

                    }
                );

                // Discoveries

                var discoveries = new Discovery[]
               {
                    new Discovery
                    {
                        Id = 1,
                        UserId = 1,
                        PointId = 1,
                        TimeOfDiscovery = DateTime.Parse("2021-01-01 07:22:16")
                    },

                    new Discovery
                    {
                        Id = 2,
                        UserId = 1,
                        PointId = 4,
                        TimeOfDiscovery = DateTime.Parse("2021-01-01 07:55:36")
                    },

                    new Discovery
                    {
                        Id = 3,
                        UserId = 1,
                        PointId = 5,
                        TimeOfDiscovery = DateTime.Parse("2021-01-01 08:17:54")
                    },

                    new Discovery
                    {
                        Id = 4,
                        UserId = 2,
                        PointId = 7,
                        TimeOfDiscovery = DateTime.Parse("2021-01-06 13:11:54")
                    },

                    new Discovery
                    {
                        Id = 5,
                        UserId = 2,
                        PointId = 8,
                        TimeOfDiscovery = DateTime.Parse("2021-01-06 16:29:30")
                    },

                    new Discovery
                    {
                        Id = 6,
                        UserId = 3,
                        PointId = 3,
                        TimeOfDiscovery = DateTime.Parse("2021-06-07 12:25:54")
                    },

                    new Discovery
                    {
                        Id = 7,
                        UserId = 4,
                        PointId = 3,
                        TimeOfDiscovery = DateTime.Parse("2021-06-07 12:25:29")
                    }
               };

                context.AddRange(discoveries);
                context.SaveChanges();
            }
        }
    }
}