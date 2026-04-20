using System;
using System.Collections.Generic;

public enum Currency
{
    AMD,
    USD,
    EUR,
}

public class Payment
{
    public decimal Amount { get; set; }
    public Currency Currency { get; set; }

    public Payment(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public virtual void ProcessPayment()
    {
        decimal fee = Amount * 0.02m;
        Console.WriteLine($"Generic Payment: {Amount} {Currency} | Fee: {fee} | Total: {Amount + fee}");
    }
}

public class CreditCardPayment : Payment
{
    public CreditCardPayment(decimal amount, Currency currency)
        : base(amount, currency) { }

    public override void ProcessPayment()
    {
        decimal fee = Amount * 0.02m;
        Console.WriteLine($"Credit Card: {Amount} {Currency} | Fee: {fee} | Total: {Amount + fee}");
    }
}

public class PaypalPayment : Payment
{
    public PaypalPayment(decimal amount, Currency currency)
        : base(amount, currency) { }

    public override void ProcessPayment()
    {
        decimal fee = Amount * 0.03m;
        Console.WriteLine($"PayPal: {Amount} {Currency} | Fee: {fee} | Total: {Amount + fee}");
    }
}

public class CryptoPayment : Payment
{
    public CryptoPayment(decimal amount, Currency currency)
        : base(amount, currency) { }

    public override void ProcessPayment()
    {
        decimal fee = Amount * 0.05m;
        Console.WriteLine($"Crypto: {Amount} {Currency} | Fee: {fee} | Total: {Amount + fee}");
    }
}

class Program
{
    static void Main()
    {
        List<Payment> payments = new List<Payment>()
        {
            new CreditCardPayment(100, Currency.USD),
            new PaypalPayment(200, Currency.EUR),
            new CryptoPayment(300, Currency.AMD)
        };

        foreach (var payment in payments)
        {
            payment.ProcessPayment();
        }

        Console.ReadLine();
    }
}