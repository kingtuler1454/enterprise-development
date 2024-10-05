namespace TaxiDetailsClass.Domain;
public class Car
{
    public int Id { get; set; }
    public string Plate { get; set; }
	public string Model { get; set; }
	public string Color { get; set; }
	public Driver AssignedDriver { get; set; }

	public Car(int id, string plate, string model, string color, Driver assignedDriver)
	{
		Id = id;
		Plate = plate;
		Model = model;
		Color = color;
		AssignedDriver = assignedDriver;
	}
}