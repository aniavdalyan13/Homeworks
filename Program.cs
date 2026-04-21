using System;
using System.Collections.Generic;

public class Bank_Account
{
    public int Id { get; }
    public string OwnerName { get; }
    private decimal Balance;
    private int transactionCount = 0;
    
    protected List<Transaction> transactions = new List<Transaction>();
    
    
    public Bank_Account(int id, string ownerName, decimal balance)
    {
        Id = id;
        OwnerName = ownerName;
        Balance = balance;
         
    }
    
    public void Deposit(decimal amount){
        transactions.Add(new Transaction(amount, DateTime.Now, "Deposit"));
        transactionCount++;
        Balance += amount;
        Console.WriteLine($"Deposit {amount}$");
        
    }
    
    public void Withdraw(decimal amount){
        transactions.Add(new Transaction(amount, DateTime.Now, "Deposit"));
        transactionCount++;

        if (amount > Balance)
        {
            Console.WriteLine("Insufficient funds");
        }
        else
        {
            Balance -= amount;
            Console.WriteLine($"Withdraw {amount}$");
        }
    }

    public void GetTransactionCount()
    {
        Console.WriteLine($"Transactions: {transactionCount}");
    }

    public void ShowBalance()
    {
        Console.WriteLine($"Balance: {Balance}$");
    }
    
    public override string ToString() => $"Bank_Account {Id} | Transactions: {transactionCount}";
    
    public class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Type { get; }

        public Transaction(decimal amount, DateTime date, string type)
        {
            Amount = amount;
            Date = date;
            Type = type;
        }
    }

    public override bool Equals(object obj)
    {
        return Id == ((Bank_Account)obj).Id;
    }   
    
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

public sealed class AccountStatement : Bank_Account
{
    public AccountStatement(int id, string ownerName, decimal balance)
        : base(id, ownerName, balance) {}

    public void Print()
    {
        foreach (var t in transactions)
        {
            Console.WriteLine($"{t.Type}: {t.Amount}$ on {t.Date}");
        }
    }
}

class Program
{
    static void Main()
    {
        Bank_Account account = new Bank_Account(10, "Ani", 100);
        account.Deposit(100);
        account.Withdraw(100);
        account.GetTransactionCount();
        
        Bank_Account account2 = new Bank_Account(10, "Ani", 100);
        
        Console.WriteLine(Bank_Account.Equals (account, account2));
        
        AccountStatement accountStatement = new AccountStatement(10, "Mari", 100);
        accountStatement.Print();
        
    }
}
