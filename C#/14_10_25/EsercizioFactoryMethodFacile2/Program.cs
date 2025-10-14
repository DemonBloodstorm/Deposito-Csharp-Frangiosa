using System;

public interface Ishape
{
    void Draw();
}

public class Circle : Ishape
{
    public void Draw()
    {
        Console.WriteLine("Disegna un cerchio");
    }
}
public class Square : Ishape
{
    public void Draw()
    {
        Console.WriteLine("Disegna un quadrato");
    }
}

public abstract class ShapeCreator
{
    public abstract Ishape CreateShape(string type);
}

public class ConcreteShapeCreator : ShapeCreator
{
    public override Ishape CreateShape(string type)
    {
        switch (type.ToLower())
        {
            case "cerchio":
                return new Circle();
            case "quadrato":
                return new Square();
            default:
                Console.WriteLine("Tipo di forma non valido");
                return null;
        }
    }
}
public class ConcreteShapeCreator2 : ShapeCreator
{
    public override Ishape CreateShape(string type)
    {
        switch (type.ToLower())
        {
            case "cerchio":
                return new Circle();
            case "quadrato":
                return new Square();
            default:
                Console.WriteLine("Tipo di forma non riconosciuto.");
                return null;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ShapeCreator creator = new ConcreteShapeCreator();

        Console.WriteLine("Che forma vuoi disegnare? (cerchio/quadrato)");
        string shapeType = Console.ReadLine();

        Ishape shape = creator.CreateShape(shapeType);

        if (shape != null)
        {
            shape.Draw();
        }
    }
}