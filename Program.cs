using System;

public class Employee {
    protected double Salary { get; }   
    
    public Employee(double salary){
        if (salary <= 0){
            Console.WriteLine("Invalid salary: Default salary = $500");
            Salary = 500;
        }
        else{
            Salary = salary; 
        }
    }

    public double GetSalary() {
        return Salary;
    }
    
    public double getBonus(){
        Console.Write("Enter bonus percent: ");
        return Convert.ToDouble(Console.ReadLine());
    }
}

public class Developer : Employee {
    private string Language { get; } 

    public Developer(double salary, string language) : base(salary){
        Language = language;  
    }

    public string GetLanguage(){
        return Language;
    }

    public double BonusSalary(){
        double bonus = base.getBonus();
        return Salary + Salary * bonus / 100;
    }
}

public class Manager : Employee {
    private int TeamSize { get; set; }

    public Manager(double salary, int teamSize) : base(salary){
        TeamSize = teamSize;
    }

    public double BonusSalary(){
        double bonus = base.getBonus();
        if (TeamSize > 5){
            return Salary + Salary * (bonus + 10) / 100;
        }
        return Salary + Salary * bonus / 100;
    }
}

class Program {
    static void Main() {

        Console.WriteLine("=== Developers ===");

        Developer d1 = new Developer(1000.0, "C#");
        Console.WriteLine($"Language: {d1.GetLanguage()}, Salary: {d1.GetSalary()}");
        Console.WriteLine($"Final Salary: {d1.BonusSalary()}\n");

        Console.WriteLine("=== Managers ===");

        Manager m1 = new Manager(2000.0, 6);
        Console.WriteLine($"Salary: {m1.GetSalary()}");
        Console.WriteLine($"Final Salary: {m1.BonusSalary()}");
    }
}