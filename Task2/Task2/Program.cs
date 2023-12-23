using System;
public abstract class AbstractClass // abstract class with an abstract method
{
    public abstract void Method(int value);
}

public interface Interface1
{
    void Method(int value);
}

public interface Interface2
{
    void Method(int value);
}

public class MyClass : AbstractClass, Interface1, Interface2 // class that inherits from two interfaces and abstract class
{
     public override void Method(int value) // implementation of method from AbstractClass
    {
        Console.WriteLine("Implementation from AbstractClass: " + value);
    }

    void Interface1.Method(int value)  // implementation of method from Interface1
    {
        Console.WriteLine("Implementation from Interface1: " + value);
    }

    void Interface2.Method(int value) // implementation of method from Interface2
    {
        Console.WriteLine("Implementation from Interface2: " + value);
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyClass myClass = new MyClass();

        ((Interface1)myClass).Method(10); 
        ((Interface2)myClass).Method(20); 
        myClass.Method(30); 
    }
}
