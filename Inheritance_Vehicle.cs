using System;

public class Vehicle
{
    public string name { get; }
    protected int speed;

    public Vehicle(string Name, int Speed)
    {
        name = Name;
        speed = Speed;
    }

    public void Start()
    {
        Console.WriteLine("{0} is starting at speed {1} km/h.", name,  speed);
    }
}

public class Car : Vehicle
{
    private int numberOfSeats;

    public Car(string Name, int Speed, int NumberOfSeats)
        : base(Name, Speed)
    {
        numberOfSeats = NumberOfSeats;
    }

    public void ShowCar()
    {
        Console.WriteLine("{0} has {1} doors.", name, numberOfSeats);
    }
}

public class Bike : Vehicle
{
    private bool hasPedals;

    public Bike(string Name, int Speed, bool HasPedals)
        : base(Name, Speed)
    {
        hasPedals = HasPedals;
    }

    public void ShowBike()
    {
        Console.WriteLine ("{0} has pedals: {1}", name, hasPedals);
    }
}

public class Truck : Vehicle
{
    private int loadCapacity;

    public Truck(string Name, int Speed, int LoadCapacity)
        : base(Name, Speed)
    {
        loadCapacity = LoadCapacity;
    }

    public void ShowTruck()
    {
        Console.WriteLine("{0} has {1} trucks.", name, loadCapacity);
    }
}

class Program
{
    static void Main()
    {
        Car car = new Car("Porsche 911 GT3", 120, 4);
        Bike bike = new Bike("Giant bike", 15, true);
        Truck truck = new Truck("Volvo truck", 70,  15);

        car.Start();
        car.ShowCar();
        
        bike.Start();
        bike.ShowBike();
        
        truck.Start();
        truck.ShowTruck();
        
    }
}