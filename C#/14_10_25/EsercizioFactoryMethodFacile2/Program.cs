using System;

public interface Ishape // Interfaccia del design pattern Factory Method
{
    void Draw();
}

public class Circle : Ishape // Classe concreta che implementa l'interfaccia Ishape
{
    public void Draw()
    {
        Console.WriteLine("Disegna un cerchio");
    }
}
public class Square : Ishape // Classe concreta che implementa l'interfaccia Ishape
{
    public void Draw()
    {
        Console.WriteLine("Disegna un quadrato");
    }
}

public abstract class ShapeCreator // Classe astratta che implementa il design pattern Factory Method
{
    public abstract Ishape CreateShape(string type);
}

public class ConcreteShapeCreator : ShapeCreator // Classe concreta che implementa il design pattern Factory Method
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
public class ConcreteShapeCreator2 : ShapeCreator // Classe concreta che implementa il design pattern Factory Method 
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

public class Program // Classe principale che utilizza il design pattern Factory Method
{
    public static void Main(string[] args)
    {
        ShapeCreator creator = new ConcreteShapeCreator();

        Console.WriteLine("Che forma vuoi disegnare? (cerchio/quadrato)"); //chiedo all'utente di inserire il tipo di forma
        string shapeType = Console.ReadLine(); // leggo il tipo di forma inserito dall'utente

        Ishape shape = creator.CreateShape(shapeType); // utilizzo il design pattern Factory Method per creare l'oggetto della forma richiesta

        if (shape != null) // se l'oggetto della forma è stato creato con successo
        {
            shape.Draw(); // utilizzo il metodo Draw() dell'oggetto della forma per disegnarla
        }
    }
}