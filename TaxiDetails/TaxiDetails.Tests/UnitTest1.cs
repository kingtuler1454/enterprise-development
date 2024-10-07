namespace TaxiDetails.Tests;

using System.Diagnostics.CodeAnalysis;
using TaxiDetailsClass.Domain;


public class UnitTest1(TaxiDetailsData dataProvider) : IClassFixture<TaxiDetailsData>
{
    private readonly TaxiDetailsData _dataProvider = dataProvider;
    [Fact]
    //Вывести все сведения о конкретном водителе и его автомобиле.
    public void ReturnCarDriverInfo()
    {
        string name = "Максим";
        var expectedData = _dataProvider.Cars[0];
        var getData = _dataProvider.Cars.Where(c => c.AssignedDriver.Name == name).Select(c => c).First();
        Assert.Equal(expectedData, getData);
    }
    //Вывести всех пассажиров, совершивших поездки за заданный период, упорядочить по ФИО.

    [Fact]
    public void ReturnPassengetInfo()
    {
        DateTime startDate = new DateTime(2024, 10, 1);
        DateTime endDate = new DateTime(2024, 10, 4);

        var expectedUsersName = new List<string>
        {
            _dataProvider.Users[0].FullName,
            _dataProvider.Users[2].FullName,
            _dataProvider.Users[1].FullName,
            _dataProvider.Users[3].FullName
        };

        var getData = _dataProvider.Travels
            .Where(t => t.TripDate >= startDate && t.TripDate <= endDate)
            .Select(t => t.Client.FullName) // Извлекаем клиентов (пассажиров)
            .Distinct() // Убираем дубликаты
            .OrderBy(u => u) // Сортируем по ФИО
            .ToList();

        Assert.Equal(expectedUsersName, getData);
    }

    //Вывести количество поездок каждого пассажира.

    [Fact]
    public void ReturnPassengetTravelsCount()
    {

        var expectedUsersName = new Dictionary<string, int>
{
    { _dataProvider.Users[0].FullName, 2 },
    { _dataProvider.Users[1].FullName, 2 },
    { _dataProvider.Users[2].FullName, 2 }, 
    { _dataProvider.Users[3].FullName, 2 }, 
    { _dataProvider.Users[4].FullName, 1 }, 
    { _dataProvider.Users[5].FullName, 1 },
    { _dataProvider.Users[6].FullName, 1 }, 
    { _dataProvider.Users[7].FullName, 1 }, 
    { _dataProvider.Users[8].FullName, 1 }, 
    { _dataProvider.Users[9].FullName, 1 }  
};

        var getPassengerTripCounts = _dataProvider.Travels
         .GroupBy(t => t.Client) // Группируем по клиентам
         .Select(g => new
         {
             Passenger = g.Key,
             TripCount = g.Count() // Считаем количество поездок
         }).OrderBy(p => p.Passenger.Id)
         .ToDictionary(x => x.Passenger.FullName, x => x.TripCount); // Преобразуем в словарь

        Assert.Equal(expectedUsersName,getPassengerTripCounts );
    }
    [Fact]
    //Вывести топ 5 водителей по совершенному количеству поездок.

}

