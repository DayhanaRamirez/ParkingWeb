using ParkingWeb.Data.Entities;
using ParkingWeb.Enums;
using ParkingWeb.Helpers;

namespace ParkingWeb.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckVehicleTypesAsync();
            await CheckCampusesAsync();
            await CheckRestrictionsAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1", "D", "R", "dr@yopmail.com", UserType.Admin);
            await CheckUserAsync("2", "J", "I", "ji@yopmail.com", UserType.User);
        }

        private async Task CheckRestrictionsAsync()
        {
            if (!_context.Restrictions.Any())
            {
                _context.Restrictions.Add(new Restriction 
                { 
                    Day = "Lunes",
                    Car1 = "6",
                    Car2 = "9",
                    Motorcycle1 = "6",
                    Motorcycle2 = "9",
                });
                _context.Restrictions.Add(new Restriction
                {
                    Day = "Martes",
                    Car1 = "2",
                    Car2 = "3",
                    Motorcycle1 = "2",
                    Motorcycle2 = "3",
                });
                _context.Restrictions.Add(new Restriction
                {
                    Day = "Miercoles",
                    Car1 = "4",
                    Car2 = "8",
                    Motorcycle1 = "4",
                    Motorcycle2 = "8",
                });
                _context.Restrictions.Add(new Restriction
                {
                    Day = "Jueves",
                    Car1 = "0",
                    Car2 = "7",
                    Motorcycle1 = "0",
                    Motorcycle2 = "7",
                });
                _context.Restrictions.Add(new Restriction
                {
                    Day = "Viernes",
                    Car1 = "5",
                    Car2 = "1",
                    Motorcycle1 = "5",
                    Motorcycle2 = "1",
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckVehicleTypesAsync()
        {
            if (!_context.VehicleTypes.Any())
            {
                _context.VehicleTypes.Add(new VehicleType { Name = "Vehículo" });
                _context.VehicleTypes.Add(new VehicleType { Name = "Motocicleta" });
                _context.VehicleTypes.Add(new VehicleType { Name = "Bicicleta" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);

            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    Document = document,
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
                string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckCampusesAsync()
        {
            if (!_context.Campuses.Any())
            {
                _context.Campuses.Add(new Campus
                {
                    Name = "Campus Fraternidad",
                    Addres = "Calle 54A No. 30 – 01, Barrio Boston",
                    ParkingLots = new List<ParkingLot>()
                    {
                        new ParkingLot
                        {
                            Name = "Carros",
                            ParkingCells = new List<ParkingCell>()
                            {
                                new ParkingCell {Name = "1"},
                                new ParkingCell {Name = "2"},
                                new ParkingCell {Name = "3"},
                                new ParkingCell {Name = "4"},
                                new ParkingCell {Name = "5"},
                                new ParkingCell {Name = "6"},
                                new ParkingCell {Name = "7"},
                                new ParkingCell {Name = "8"},
                                new ParkingCell {Name = "9"},
                                new ParkingCell {Name = "10"},
                            }
                        },

                        new ParkingLot
                        {
                            Name = "Motos",
                            ParkingCells = new List<ParkingCell>()
                            {
                                new ParkingCell {Name = "1"},
                                new ParkingCell {Name = "2"},
                                new ParkingCell {Name = "3"},
                                new ParkingCell {Name = "4"},
                                new ParkingCell {Name = "5"},
                                new ParkingCell {Name = "6"},
                                new ParkingCell {Name = "7"},
                                new ParkingCell {Name = "8"},
                                new ParkingCell {Name = "9"},
                                new ParkingCell {Name = "10"},
                            }
                        },

                        new ParkingLot
                        {
                            Name = "Bicicletas",
                            ParkingCells = new List<ParkingCell>()
                            {
                                new ParkingCell {Name = "1"},
                                new ParkingCell {Name = "2"},
                                new ParkingCell {Name = "3"},
                                new ParkingCell {Name = "4"},
                                new ParkingCell {Name = "5"},
                                new ParkingCell {Name = "6"},
                                new ParkingCell {Name = "7"},
                                new ParkingCell {Name = "8"},
                                new ParkingCell {Name = "9"},
                                new ParkingCell {Name = "10"},
                            }
                        }
                    },
                });

                _context.Campuses.Add(new Campus
                {
                    Name = "Campus Robledo",
                    Addres = "Calle 73 No. 76A – 354, Vía al Volador",
                    ParkingLots = new List<ParkingLot>()
                    {
                        new ParkingLot
                        {
                            Name = "Carros",
                            ParkingCells = new List<ParkingCell>()
                            {
                                new ParkingCell {Name = "1"},
                                new ParkingCell {Name = "2"},
                                new ParkingCell {Name = "3"},
                                new ParkingCell {Name = "4"},
                                new ParkingCell {Name = "5"},
                                new ParkingCell {Name = "6"},
                                new ParkingCell {Name = "7"},
                                new ParkingCell {Name = "8"},
                                new ParkingCell {Name = "9"},
                                new ParkingCell {Name = "10"},
                            }
                        },

                        new ParkingLot
                        {
                            Name = "Motos",
                            ParkingCells = new List<ParkingCell>()
                            {
                                new ParkingCell {Name = "1"},
                                new ParkingCell {Name = "2"},
                                new ParkingCell {Name = "3"},
                                new ParkingCell {Name = "4"},
                                new ParkingCell {Name = "5"},
                                new ParkingCell {Name = "6"},
                                new ParkingCell {Name = "7"},
                                new ParkingCell {Name = "8"},
                                new ParkingCell {Name = "9"},
                                new ParkingCell {Name = "10"},
                            }
                        },

                        new ParkingLot
                        {
                            Name = "Bicicletas",
                            ParkingCells = new List<ParkingCell>()
                            {
                                new ParkingCell {Name = "1"},
                                new ParkingCell {Name = "2"},
                                new ParkingCell {Name = "3"},
                                new ParkingCell {Name = "4"},
                                new ParkingCell {Name = "5"},
                                new ParkingCell {Name = "6"},
                                new ParkingCell {Name = "7"},
                                new ParkingCell {Name = "8"},
                                new ParkingCell {Name = "9"},
                                new ParkingCell {Name = "10"},
                            }
                        }
                    },
                });

                _context.Campuses.Add(new Campus
                {
                    Name = "Sede La Floresta",
                    Addres = "Calle 47A No. 85 – 20, Barrio La Floresta",
                    ParkingLots = new List<ParkingLot>()
                    {
                        new ParkingLot
                        {
                            Name = "Carros",
                            ParkingCells = new List<ParkingCell>()
                            {
                                new ParkingCell {Name = "1"},
                                new ParkingCell {Name = "2"},
                                new ParkingCell {Name = "3"},
                                new ParkingCell {Name = "4"},
                                new ParkingCell {Name = "5"},
                                new ParkingCell {Name = "6"},
                                new ParkingCell {Name = "7"},
                                new ParkingCell {Name = "8"},
                                new ParkingCell {Name = "9"},
                                new ParkingCell {Name = "10"},
                            }
                        },

                        new ParkingLot
                        {
                            Name = "Motos",
                            ParkingCells = new List<ParkingCell>()
                            {
                                new ParkingCell {Name = "1"},
                                new ParkingCell {Name = "2"},
                                new ParkingCell {Name = "3"},
                                new ParkingCell {Name = "4"},
                                new ParkingCell {Name = "5"},
                                new ParkingCell {Name = "6"},
                                new ParkingCell {Name = "7"},
                                new ParkingCell {Name = "8"},
                                new ParkingCell {Name = "9"},
                                new ParkingCell {Name = "10"},
                            }
                        },

                        new ParkingLot
                        {
                            Name = "Bicicletas",
                            ParkingCells = new List<ParkingCell>()
                            {
                                new ParkingCell {Name = "1"},
                                new ParkingCell {Name = "2"},
                                new ParkingCell {Name = "3"},
                                new ParkingCell {Name = "4"},
                                new ParkingCell {Name = "5"},
                                new ParkingCell {Name = "6"},
                                new ParkingCell {Name = "7"},
                                new ParkingCell {Name = "8"},
                                new ParkingCell {Name = "9"},
                                new ParkingCell {Name = "10"},
                            }
                        }
                    },
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}
