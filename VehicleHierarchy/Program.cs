abstract public class Vehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public Vehicle(string brand, string model)
    {
        Brand = brand;
        Model = model;
    }
    public virtual void Start()
    {
        Console.WriteLine("Vehicle started.");
    }
    public abstract void Drive();
    public virtual void Stop()
    {
        Console.WriteLine("Vehicle stopped.");
    }
    public virtual void Display()
    {
        Console.WriteLine($"Brand: {Brand}, Model: {Model}");
    }
}


class Car : Vehicle
{
    public int NumberOfDoors { get; set; }
    public Car(string brand, string model, int numberOfDoors) 
    {
        NumberOfDoors = numberOfDoors;
    }
    public override void Drive()
    {
        Console.WriteLine("Car is driving.");
    }
    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Number of Doors: {NumberOfDoors}");
    }
}

class Bike : Vehicle
{
    public bool HasHelmet { get; set; }
    public Bike(string brand, string model, bool hasHelmet) : base(brand, model)
    {
        HasHelmet = hasHelmet;
    }
    public override void Drive()
    {
        Console.WriteLine("Bike is driving.");
    }
    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Has Helmet: {HasHelmet}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Vehicle myCar = new Car("Toyota", "Camry", 4);
        myCar.Start();
        myCar.Drive();
        myCar.Display();
        myCar.Stop();

        Console.WriteLine();

        Vehicle myBike = new Bike("Yamaha", "YZF-R3", true);
        myBike.Start();
        myBike.Drive();
        myBike.Display();
        myBike.Stop();
    }
}