namespace TaxiDetails.Tests;
/// <summary>
/// class for test requests
/// </summary>
public class Requests(TaxiDetailsData dataProvider) : IClassFixture<TaxiDetailsData>
{
    private readonly TaxiDetailsData _dataProvider = dataProvider;
    /// <summary>
    /// info about driver of car
    /// </summary>
    [Fact]
    public void ReturnCarDriverInfo()
    {
        string name = "Максим";
        Assert.NotNull(_dataProvider);
        Assert.NotNull(_dataProvider.Cars);
        Assert.True(_dataProvider.Cars.Any(), "The Cars collection is empty.");
        var expectedData = _dataProvider.Cars
            .FirstOrDefault(c => c.AssignedDriver?.Name == name);
        Assert.NotNull(expectedData);
        var getData = _dataProvider.Cars
            .FirstOrDefault(c => c.AssignedDriver?.Name == name);
        Assert.NotNull(getData);
        Assert.Equal(expectedData, getData);
    }

    /// <summary>
    /// info about passenger of dateinterval
    /// </summary>
    [Fact]
    public void ReturnPassengerInfo()
    {
        DateTime startDate = new(2024, 10, 1);
        DateTime endDate = new(2024, 10, 4);

        var expectedUsersName = new List<string>
        {
            _dataProvider.Users[0].FullName!,
            _dataProvider.Users[2].FullName!,
            _dataProvider.Users[3].FullName!
        };

        var getData = _dataProvider.Travels
            .Where(t => t.TripDate >= startDate && t.TripDate <= endDate)
            .Select(t => t.Client.FullName) 
            .Where(fullName => !string.IsNullOrEmpty(fullName))
            .Cast<string>() 
            .Distinct()
            .OrderBy(u => u)
            .ToList();

        Assert.Equal(expectedUsersName, getData);
    }
    /// <summary>
    /// info about passenger and count of trips
    /// </summary>
    [Fact]
    public void ReturnPassengerTravelsCount()
    {
        var expectedUsersName = new Dictionary<string, int>
        {
            { _dataProvider.Users[0].FullName!, 2 },
            { _dataProvider.Users[2].FullName!, 1 },
            { _dataProvider.Users[3].FullName!, 1 },
   
        };
        var getPassengerTripCounts = _dataProvider.Travels
            .Where(t => !string.IsNullOrEmpty(t.Client.FullName))
            .GroupBy(t => t.Client!)
            .Select(g => new
            {
                Passenger = g.Key,
                TripCount = g.Count()
            })
            .OrderBy(p => p.Passenger.Id)
            .ToDictionary(
                x => x.Passenger.FullName!,
                x => x.TripCount
            );
        Assert.Equal(expectedUsersName, getPassengerTripCounts);
    }
    /// <summary>
    ///  top 5 drivers
    /// </summary>
    [Fact]
    public void ReturnTopFiveDrives()
    {
        var expectedUsersName1 = new Dictionary<string, int>
        {
            { _dataProvider.Drivers[0].Name!, 1 },
            { _dataProvider.Drivers[1].Name!, 1 },
            { _dataProvider.Drivers[2].Name!, 1 },
            { _dataProvider.Drivers[3].Name!, 1 },
        };
        var driverTripCounts1 = _dataProvider.Travels
            .Where(t => t.AssignedCar.AssignedDriver.Name != null) 
            .GroupBy(t => t.AssignedCar.AssignedDriver)
            .Select(g => new
            {
                Driver = g.Key,
                TripCount = g.Count()
            })
            .OrderByDescending(x => x.TripCount)
            .Take(5)
            .ToList();

        var actualUsersName1 = driverTripCounts1
            .ToDictionary(x => x.Driver.Name!, x => x.TripCount);
        Assert.Equal(expectedUsersName1, actualUsersName1);
    }
    /// <summary>
    /// info about avg and max time of drivers
    /// </summary>
    [Fact]
    public void ReturnStatisticTime()
    {
        var expectedData = new List<(string Name, int TripCount, TimeOnly AvgDrivingTime, TimeOnly MaxDrivingTime)>
        {
            (_dataProvider.Drivers[0].Name!, 1, new TimeOnly(0, 20), new TimeOnly(0, 20)),
            (_dataProvider.Drivers[1].Name!, 1, new TimeOnly(0, 16), new TimeOnly(0, 16)),
            (_dataProvider.Drivers[2].Name!, 1, new TimeOnly(0, 26), new TimeOnly(0, 26)),
            (_dataProvider.Drivers[3].Name!, 1, new TimeOnly(0, 30), new TimeOnly(0, 30))
        };

        var driverTripStats = _dataProvider.Travels
            .Where(t => t.AssignedCar.AssignedDriver.Name != null)
            .GroupBy(t => t.AssignedCar.AssignedDriver!)
            .Select(g => (
                Driver: g.Key.Name!,
                TripCount: g.Count(),
                AvgDrivingTime: TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(g.Average(t => t.TravelTime.Value.TotalMinutes))),
                MaxDrivingTime: TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(g.Max(t => t.TravelTime.Value.TotalMinutes)))
            ))
            .ToList();

        Assert.Equal(expectedData, driverTripStats);
    }
    /// <summary>
    /// info of client max trips in dateinterval 
    /// </summary>
    [Fact]
    public void GetClientsMaxTrips()
    {
        var startDate = new DateTime(2024, 10, 1);
        var endDate = new DateTime(2024, 10, 11);

        var expectedData = new List<User>
        {
            _dataProvider.Users[0]
        };

        var topPassengers = _dataProvider.Travels
            .Where(t => t.TripDate >= startDate && t.TripDate <= endDate)
            .GroupBy(t => t.Client)
            .Select(g => new
            {
                Passenger = g.Key,
                TripCount = g.Count()
            })
            .Where(x => x.TripCount ==
                        _dataProvider.Travels
                            .Where(t => t.TripDate >= startDate && t.TripDate <= endDate)
                            .GroupBy(t => t.Client)
                            .Max(g => g.Count()))
            .Select(x => x.Passenger!)
            .ToList();
        Assert.Equal(expectedData, topPassengers);
    }
}

