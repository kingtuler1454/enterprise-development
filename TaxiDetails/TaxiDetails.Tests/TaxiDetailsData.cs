namespace TaxiDetails.Tests;
public class TaxiDetailsData
{
    public List<Driver> Drivers { get; set; }
    public List<Car> Cars { get; set; }
    public List<User> Users { get; set; }
    public List<Travel> Travels { get; set; }

    public TaxiDetailsData()
    {
        Drivers =
        [
            new()
            {
                Id = 1,
                Name = "Максим",
                Surname = "Смирнов",
                Patronymic = "Александрович",
                Passport = "1234567890",
                Address = "ул. Пушкина, д. 1",
                Phone = "+7 123 456 78 90"
            },
            new()
            {
                Id = 2,
                Name = "Артем",
                Surname = "Кузнецов",
                Patronymic = "Олегович",
                Passport = "0987654321",
                Address = "ул. Лермонтова, д. 5",
                Phone = "+7 987 654 32 10"
            },
            new()
            {
                Id = 3,
                Name = "Даниил",
                Surname = "Новиков",
                Patronymic = "Игоревич",
                Passport = "1522334455",
                Address = "ул. Чехова, д. 10",
                Phone = "+7 111 222 33 44"
            },
            new()
            {
                Id = 4,
                Name = "Кирилл",
                Surname = "Морозов",
                Patronymic = "Владимирович",
                Passport = "130587654",
                Address = "ул. Лесная, д. 12",
                Phone = "+7 555 777 88 99"
            },
            new()
            {
                Id = 5,
                Name = "Илья",
                Surname = "Соколов",
                Patronymic = "Андреевич",
                Passport = "4455665758",
                Address = "ул. Цветочная, д. 8",
                Phone = "+7 123 789 45 67"
            },
            new()
            {
                Id = 6,
                Name = "Никита",
                Surname = "Орлов",
                Patronymic = "Павлович",
                Passport = "9388775655",
                Address = "ул. Южная, д. 3",
                Phone = "+7 333 444 55 66"
            },
            new()
            {
                Id = 7,
                Name = "Матвей",
                Surname = "Попов",
                Patronymic = "Александрович",
                Passport = "2633443566",
                Address = "ул. Центральная, д. 6",
                Phone = "+7 111 222 11 33"
            },
            new()
            {
                Id = 8,
                Name = "Тимофей",
                Surname = "Васильев",
                Patronymic = "Владиславович",
                Passport = "6677439930",
                Address = "ул. Полевая, д. 7",
                Phone = "+7 999 888 77 44"
            },
            new()
            {
                Id = 9,
                Name = "Александр",
                Surname = "Зайцев",
                Patronymic = "Николаевич",
                Passport = "5566578899",
                Address = "ул. Овражная, д. 4",
                Phone = "+7 222 333 44 11"
            },
            new()
            {
                Id = 10,
                Name = "Егор",
                Surname = "Смирнов",
                Patronymic = "Сергеевич",
                Passport = "3344356611",
                Address = "ул. Радужная, д. 9",
                Phone = "+7 777 666 55 99"
            }
        ];

        Drivers =
        [
            new()
            {
                Id = 1,
                Name = "Максим",
                Surname = "Смирнов",
                Patronymic = "Александрович",
                Passport = "1234567890",
                Address = "ул. Пушкина, д. 1",
                Phone = "+7 123 456 78 90"
            },
            new()
            {
                Id = 2,
                Name = "Артем",
                Surname = "Кузнецов",
                Patronymic = "Олегович",
                Passport = "0987654321",
                Address = "ул. Лермонтова, д. 5",
                Phone = "+7 987 654 32 10"
            },
            new()
            {
                Id = 3,
                Name = "Даниил",
                Surname = "Новиков",
                Patronymic = "Игоревич",
                Passport = "1522334455",
                Address = "ул. Чехова, д. 10",
                Phone = "+7 111 222 33 44"
            },
            new()
            {
                Id = 4,
                Name = "Кирилл",
                Surname = "Морозов",
                Patronymic = "Владимирович",
                Passport = "130587654",
                Address = "ул. Лесная, д. 12",
                Phone = "+7 555 777 88 99"
            },
            new()
            {
                Id = 5,
                Name = "Илья",
                Surname = "Соколов",
                Patronymic = "Андреевич",
                Passport = "4455665758",
                Address = "ул. Цветочная, д. 8",
                Phone = "+7 123 789 45 67"
            },
            new()
            {
                Id = 6,
                Name = "Никита",
                Surname = "Орлов",
                Patronymic = "Павлович",
                Passport = "9388775655",
                Address = "ул. Южная, д. 3",
                Phone = "+7 333 444 55 66"
            },
            new()
            {
                Id = 7,
                Name = "Матвей",
                Surname = "Попов",
                Patronymic = "Александрович",
                Passport = "2633443566",
                Address = "ул. Центральная, д. 6",
                Phone = "+7 111 222 11 33"
            },
            new()
            {
                Id = 8,
                Name = "Тимофей",
                Surname = "Васильев",
                Patronymic = "Владиславович",
                Passport = "6677439930",
                Address = "ул. Полевая, д. 7",
                Phone = "+7 999 888 77 44"
            },
            new()
            {
                Id = 9,
                Name = "Александр",
                Surname = "Зайцев",
                Patronymic = "Николаевич",
                Passport = "5566578899",
                Address = "ул. Овражная, д. 4",
                Phone = "+7 222 333 44 11"
            },
            new()
            {
                Id = 10,
                Name = "Егор",
                Surname = "Смирнов",
                Patronymic = "Сергеевич",
                Passport = "3344356611",
                Address = "ул. Радужная, д. 9",
                Phone = "+7 777 666 55 99"
            }
        ];

        Users =
         [
            new()
            {
                Id = 1,
                Phone = "+7 912 345 67 89",
                FullName = "Анна Сергеева"
            },
            new()
            {
                Id = 2,
                Phone = "+7 923 456 78 90",
                FullName = "Елена Михайлова"
            },
            new()
            {
                Id = 3,
                Phone = "+7 934 567 89 01",
                FullName = "Дмитрий Воронов"
            },
            new()
            {
                Id = 4,
                Phone = "+7 945 678 90 12",
                FullName = "Марина Кузьмина"
            },
            new()
            {
                Id = 5,
                Phone = "+7 956 789 01 23",
                FullName = "Алексей Петров"
            },
            new()
            {
                Id = 6,
                Phone = "+7 967 890 12 34",
                FullName = "Ольга Лебедева"
            },
            new()
            {
                Id = 7,
                Phone = "+7 978 901 23 45",
                FullName = "Юлия Павлова"
            },
            new()
            {
                Id = 8,
                Phone = "+7 989 012 34 56",
                FullName = "Иван Иванов"
            },
            new()
            {
                Id = 9,
                Phone = "+7 999 123 45 67",
                FullName = "Светлана Смирнова"
            },
            new()
            {
                Id = 10,
                Phone = "+7 900 234 56 78",
                FullName = "Константин Волков"
            }
        ];

        Travels =
        [
            new()
            {
                Id = 1,
                DeparturePoint = "ул. Новая, д. 5",
                DestinationPoint = "пр-т Мира, д. 10",
                TripDate = new DateTime(2024, 10, 1),
                TravelTime = new TimeSpan(0, 20, 0),
                Cost = 400,
                AssignedCar = Cars[0],
                Client = Users[0]
            },
            new()
            {
                Id = 12,
                DeparturePoint = "пр-т Суворова, д. 6",
                DestinationPoint = "ул. Кирова, д. 9",
                TripDate = new DateTime(2024, 10, 13),
                TravelTime = new TimeSpan(0, 26, 0),
                Cost = 500,
                AssignedCar = Cars[0],
                Client = Users[1]
            },
            new()
            {
                Id = 13,
                DeparturePoint = "ул. Орлова, д. 13",
                DestinationPoint = "ул. Цветочная, д. 2",
                TripDate = new DateTime(2024, 10, 14),
                TravelTime = new TimeSpan(0, 50, 0),
                Cost = 550,
                AssignedCar = Cars[0],
                Client = Users[2]
            },
            new()
            {
                Id = 2,
                DeparturePoint = "ул. Лесная, д. 8",
                DestinationPoint = "ул. Рябиновая, д. 3",
                TripDate = new DateTime(2024, 10, 2),
                TravelTime = new TimeSpan(0, 16, 0),
                Cost = 300,
                AssignedCar = Cars[1],
                Client = Users[0]
            },
            new()
            {
                Id = 14,
                DeparturePoint = "ул. Колхозная, д. 7",
                DestinationPoint = "пр-т Победы, д. 4",
                TripDate = new DateTime(2024, 10, 15),
                TravelTime = new TimeSpan(0, 30, 0),
                Cost = 600,
                AssignedCar = Cars[1],
                Client = Users[0]
            },
            new()
            {
                Id = 11,
                DeparturePoint = "ул. Речная, д. 18",
                DestinationPoint = "ул. Полевая, д. 5",
                TripDate = new DateTime(2024, 10, 12),
                TravelTime = new TimeSpan(0, 20, 0),
                Cost = 400,
                AssignedCar = Cars[2],
                Client = Users[0]
            },
            new()
            {
                Id = 3,
                DeparturePoint = "ул. Школьная, д. 12",
                DestinationPoint = "ул. Солнечная, д. 4",
                TripDate = new DateTime(2024, 10, 3),
                TravelTime = new TimeSpan(0, 26, 0),
                Cost = 500,
                AssignedCar = Cars[2],
                Client = Users[2]
            },
            new()
            {
                Id = 4,
                DeparturePoint = "пр-т Ленина, д. 21",
                DestinationPoint = "ул. Клубничная, д. 7",
                TripDate = new DateTime(2024, 10, 4),
                TravelTime = new TimeSpan(0, 30, 0),
                Cost = 600,
                AssignedCar = Cars[3],
                Client = Users[3]
            },
            new()
            {
                Id = 5,
                DeparturePoint = "ул. Парковая, д. 9",
                DestinationPoint = "пр-т Гагарина, д. 15",
                TripDate = new DateTime(2024, 10, 5),
                TravelTime = new TimeSpan(0, 20, 0),
                Cost = 350,
                AssignedCar = Cars[4],
                Client = Users[4]
            },
            new()
            {
                Id = 6,
                DeparturePoint = "ул. Лермонтова, д. 2",
                DestinationPoint = "ул. Чехова, д. 10",
                TripDate = new DateTime(2024, 10, 6),
                TravelTime = new TimeSpan(0, 26, 0),
                Cost = 450,
                AssignedCar = Cars[5],
                Client = Users[5]
            },
            new()
            {
                Id = 7,
                DeparturePoint = "ул. Речная, д. 18",
                DestinationPoint = "ул. Полевая, д. 5",
                TripDate = new DateTime(2024, 10, 7),
                TravelTime = new TimeSpan(0, 20, 0),
                Cost = 400,
                AssignedCar = Cars[6],
                Client = Users[6]
            },
            new()
            {
                Id = 8,
                DeparturePoint = "пр-т Суворова, д. 6",
                DestinationPoint = "ул. Кирова, д. 9",
                TripDate = new DateTime(2024, 10, 8),
                TravelTime = new TimeSpan(0, 26, 0),
                Cost = 500,
                AssignedCar = Cars[7],
                Client = Users[7]
            },
            new()
            {
                Id = 9,
                DeparturePoint = "ул. Орлова, д. 13",
                DestinationPoint = "ул. Цветочная, д. 2",
                TripDate = new DateTime(2024, 10, 9),
                TravelTime = new TimeSpan(0, 30, 0),
                Cost = 550,
                AssignedCar = Cars[8],
                Client = Users[8]
            },
            new()
            {
                Id = 10,
                DeparturePoint = "ул. Колхозная, д. 7",
                DestinationPoint = "пр-т Победы, д. 4",
                TripDate = new DateTime(2024, 10, 11),
                TravelTime = new TimeSpan(0, 30, 0),
                Cost = 600,
                AssignedCar = Cars[9],
                Client = Users[9]
            }
        ];

    }
}

