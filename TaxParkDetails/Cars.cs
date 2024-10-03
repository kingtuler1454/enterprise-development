namespace TaxParkDetails.Domain;
public class Car
{
	public string Plate { get; set; }
	public string Model { get; set; }
	public string Color { get; set; }
	public Driver AssignedDriver { get; set; }

	public Car(string plate, string model, string color, Driver assignedDriver)
	{
		Plate = plate;
		Model = model;
		Color = color;
		AssignedDriver = assignedDriver;
	}
}