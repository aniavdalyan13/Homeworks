using System;
class BigObject
{
    private int[] data = new int[100000];

    public BigObject()
    {
        Console.WriteLine("Object created. Gen: " + GC.GetGeneration(this));
    }
}

class Program
{
    static void Main()
    {
        CreateObjects();

        Console.WriteLine("\nBefore GC");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("After GC");

        Console.WriteLine("Gen 0 collections: " + GC.CollectionCount(0));
        Console.WriteLine("Gen 1 collections: " + GC.CollectionCount(1));
        Console.WriteLine("Gen 2 collections: " + GC.CollectionCount(2));
    }

    static void CreateObjects()
    {
        for (int i = 0; i < 10; i++)
        {
            BigObject obj = new BigObject();
            obj = null;
        }
    }
}