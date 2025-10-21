using System;

public interface IExportFormatter // Interfaccia per il formato di esportazione
{
    string Format(Data data); // Metodo per formattare i dati dell'ordine
}

public class Data // Classe per rappresentare i dati dell'ordine
{
    public DateTime Date { get; set; }
    public string Form { get; set; }
}

public class DataExporter // Classe per esportare i dati in diversi formati tramite inniezione del metodo
{
    public string Export(Data data, IExportFormatter formatter)
    {
        Console.WriteLine($"[INFO] Tipo di formattazione iniettato: {formatter.GetType().Name}");
        return formatter.Format(data);
    }
}
public class JsonExportFormatter : IExportFormatter // Implementazione del formato JSON
{
    public string Format(Data data)
    {
        return $"{data.Date:yyyy-MM-dd HH:mm:ss}, Form: {data.Form}";
    }
}

public class XmlExportFormatter : IExportFormatter // Implementazione del formato XML
{
    public string Format(Data data)
    {
        return $"{data.Date:yyyy-MM-dd HH:mm:ss}, Form: {data.Form}";
    }
}



public class Program
{
    public static void Main(string[] args)
    {
        var data = new Data { Date = DateTime.Now, Form = "Ordine 66" };
        var exporter = new DataExporter();

        Console.WriteLine(exporter.Export(data, new JsonExportFormatter())); // qui inietti JSON
        Console.WriteLine(exporter.Export(data, new XmlExportFormatter()));  // qui inietti XML
    }
}