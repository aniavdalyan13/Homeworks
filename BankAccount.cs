using System;

class BankAccount
{
    private double _balance;

    public static int TotalAccounts { get; private set; }

    public BankAccount(double initialBalance = 0)
    {
        if (initialBalance >= 0)
            _balance = initialBalance;
        else
            _balance = 0;

        TotalAccounts++;
    }

    public double Balance
    {
        get { return _balance; }
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            _balance += amount;
            Console.WriteLine("Deposited " + amount + ", new balance: " + _balance);
        }
    }

    public void Withdraw(double amount)
    {
        if (amount > 0 && _balance >= amount)
        {
            _balance -= amount;
            Console.WriteLine("Withdrew " + amount + ", new balance: " + _balance);
        }
        else
        {
            Console.WriteLine("Withdraw failed");
        }
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc1 = new BankAccount(1000);
        BankAccount acc2 = new BankAccount(500);
        BankAccount acc3 = new BankAccount();

        Console.WriteLine("Total accounts: " + BankAccount.TotalAccounts);

        Console.WriteLine("acc1 balance: " + acc1.Balance);
        Console.WriteLine("acc2 balance: " + acc2.Balance);
        Console.WriteLine("acc3 balance: " + acc3.Balance);

        acc1.Deposit(200);
        acc2.Withdraw(100);
        acc3.Deposit(50);

        Console.WriteLine("Final acc1 balance: " + acc1.Balance);
        Console.WriteLine("Final acc2 balance: " + acc2.Balance);
        Console.WriteLine("Final acc3 balance: " + acc3.Balance);

        Console.WriteLine("Total accounts created: " + BankAccount.TotalAccounts);
    }
}