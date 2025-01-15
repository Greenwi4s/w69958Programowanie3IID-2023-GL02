namespace Lab5;

public interface IIVehicle
{
    public int MaxSpeed { get; set; }
    public void Start();
    public void Stop();
}

public class Car : IIVehicle
{
    public int MaxSpeed { get; set; }
    public int CurrentSpeed { get; set; }
    public string Color { get; set; }

    public void Start()
    {
        Console.WriteLine("Car started");
    }

    public void ChangeSpeed(int speed)
    {
        CurrentSpeed = speed;
    }

    public void ChangeColor(string color)
    {
        Color = color;
    }

    public void Stop()
    {
        Console.WriteLine("Car stopped");
    }
}

public class Bike : IIVehicle
{
    public int MaxSpeed { get; set; }
    public bool CurrentStateNormal { get; set; }
    public bool BreakingNow { get; set; }
    public string Color { get; set; }

    public void Start()
    {
        Console.WriteLine("Bike started");
    }

    public void ChangeCurrentStateNormal(bool state)
    {
        CurrentStateNormal = state;
    }

    public void ChangeColor(string color)
    {
        Color = color;
    }

    public void IsBreakingNow()
    {
        if (BreakingNow)
        {
            Console.WriteLine("Bike is breaking");
        }
        else
        {
            Console.WriteLine("Bike is NOT breaking");
        }
    }

    public void Stop()
    {
        Console.WriteLine("Bike stopped");
    }
}