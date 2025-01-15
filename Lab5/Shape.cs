namespace Lab5;

public abstract class Shape
{
    public abstract void CalulateArea();
}

public class Circle : Shape
{
    public override void CalulateArea()
    {
        Console.WriteLine("That is an area of this circle");
    }
}
    
public class Square : Shape
{
    public override void CalulateArea()
    {
        Console.WriteLine("That is an area of this square");
    }
}