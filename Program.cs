using System;

public class Animal
{
    public string Name { get; }
    public int Lifespan { get; }
    public int SleepTime { get; }

    public Animal(string name, int lifespan, int sleepTime)
    {
        Name = name;
        Lifespan = lifespan;
        SleepTime = sleepTime;
    }

    public virtual void Eat()
    {
        Console.WriteLine($"{Name} eats.");
    }

    public void Sleep()
    {
        Console.WriteLine($"{Name} sleeps {SleepTime} hours");
    }

    public virtual void Voice()
    {
        Console.WriteLine($"{Name} voices");
    }
}

public class Aquatic : Animal
{
    private int swimming_speed;

    public Aquatic(string name, int lifespan, int sleepTime, int swimming_speed)
        : base(name, lifespan, sleepTime)
    {
        this.swimming_speed = swimming_speed;
    }

    public void Swim()
    {
        Console.WriteLine($"{Name} swimming speed is {swimming_speed}.");
    }
}

public class Terrestrial : Animal
{
    private bool has_fur;

    public Terrestrial(string name, int lifespan, int sleepTime, bool has_fur)
        : base(name, lifespan, sleepTime)
    {
        this.has_fur = has_fur;
    }

    public void Fur()
    {
        Console.WriteLine($"{Name} Furs : {has_fur}");
    }
}

public class Bird : Animal
{
    private int flying_height;

    public Bird(string name, int lifespan, int sleepTime, int flying_height)
        : base(name, lifespan, sleepTime)
    {
        this.flying_height = flying_height;
    }

    public void Fly()
    {
        Console.WriteLine($"{Name} flying_height is {flying_height}.");
    }

    public override void Eat()
    {
        Console.WriteLine($"{Name} eats worm.");
    }
}

public class Amphibian : Animal
{
    private bool has_gills;

    public Amphibian(string name, int lifespan, int sleepTime, bool has_gills)
        : base(name, lifespan, sleepTime)
    {
        this.has_gills = has_gills;
    }

    public void Gill()
    {
        Console.WriteLine($"{Name} gills : {has_gills}");
    }
}

public class Dog : Terrestrial
{
    public Dog(string name, int lifespan, int sleepTime, bool has_fur)
        : base(name, lifespan, sleepTime, has_fur) { }

    public override void Voice()
    {
        Console.WriteLine("Dog barks.");
    }

    public override void Eat()
    {
        Console.WriteLine($"{Name} eats bones.");
    }
}

public class Eagle : Bird
{
    public Eagle(string name, int lifespan, int sleepTime, int flying_height)
        : base(name, lifespan, sleepTime, flying_height) { }

    public override void Eat()
    {
        Console.WriteLine($"{Name} eats sheeps.");
    }
}

class Program
{
    static void Main()
    {
        Aquatic aquatic = new Aquatic("Sig", 5, 8, 10);
        Bird bird = new Bird("Parrot", 4, 5, 50);
        Amphibian amphibian = new Amphibian("Frog", 4, 6, true);
        Dog dog = new Dog("Dog", 15, 8, true);
        Eagle eagle = new Eagle("Eagle", 40, 5, 4000);

        Console.WriteLine();
        aquatic.Eat();
        aquatic.Sleep();
        aquatic.Swim();

        Console.WriteLine();

        dog.Eat();
        dog.Sleep();
        dog.Voice();

        Console.WriteLine();

        bird.Eat();
        bird.Voice();

        Console.WriteLine();

        eagle.Eat();
        eagle.Voice();
        eagle.Sleep();

        Console.WriteLine();

        amphibian.Eat();
        amphibian.Voice();
    }
}
