using System;
using System.Collections.Generic;

public class Room
{
    private string name;
    private double area;

    public Room(string Name, double Area)
    {
        name = Name;
        area = Area;
    }

    public void ShowRoom()
    {
        Console.WriteLine("{0}, which has area of {1} square meters", name, area);
    }
}

public class House
{
    private readonly List<Room> rooms = new();

    public House()
    {
        rooms.Add(new Room("Living Room", 50));
        rooms.Add(new Room("Kitchen", 25));
        rooms.Add(new Room("Bedroom", 30));
    }

    public void Show()
    {
        foreach (var r in rooms)
        {
            r.ShowRoom();
        }
    }
}

public class Course
{
    public string name { get; }

    public Course(string Name)
    {
        name = Name;
    }

    public void ShowCourse()
    {
        Console.WriteLine(name);
    }
}

public class Teacher
{
    private string name;
    private readonly List<Course> courses;

    public Teacher(string Name, List<Course> Courses)
    {
        name = Name;
        courses = Courses; 
    }

    public void ShowCourses()
    {
        Console.WriteLine($"{name} teaches:");
        foreach (var c in courses)
        {
            c.ShowCourse();
        }
    }
}

class Program
{
    static void Main()
    {
        House house = new House();
        Console.WriteLine("House has following rooms:");
        house.Show();

        Console.WriteLine();

        Course math = new Course("Math");
        Course physics = new Course("Physics");
        List<Course> courses = new List<Course> { math, physics };

        Teacher teacher = new Teacher("Annie", courses);
        teacher.ShowCourses();
    }
}

