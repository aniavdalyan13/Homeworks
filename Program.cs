using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomCollectionSystem;

class Program
{
    static void Main()
    {
        StudentCollection group1 = new StudentCollection();

        group1.Add(new Student("Anna", 20));
        group1.Add(new Student("David", 17));

        StudentCollection group2 = new StudentCollection();

        group2.Add(new Student("Mariam", 22));
        group2.Add(new Student("Gor", 18));

        Console.WriteLine("First student:");
        Console.WriteLine(group1[0]);

        StudentCollection allStudents = group1 + group2;

        Console.WriteLine("\nMerged Collection:");
        allStudents.Print();

        List<Student> list = allStudents;

        Console.WriteLine("\nCSV FORMAT:");
        Console.WriteLine(list.ToCsvString());

        var result = from s in list
            select new
            {
                s.Name,
                IsAdult = s.Age >= 18
            };

        Console.WriteLine("Anonymous Type Result:");

        foreach (var item in result)
        {
            Console.WriteLine($"{item.Name} -> Adult: {item.IsAdult}");
        }
    }
}