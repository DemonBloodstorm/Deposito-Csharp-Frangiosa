using System;


public interface IStorageServices
{
    void SalvaFile();
}

public class DiskStorageServices : IStorageServices
{
    public void SalvaFile()
    {
        Console.WriteLine("Salvo i dati su disco");
    }
}
public class MemoryStorageServices : IStorageServices
{
    public void SalvaFile()
    {
        Console.WriteLine("Salvo i dati in memoria");
    }
}
public class FileUploader
{
    private IStorageServices _storageServices;
    public void SetStorageServices(IStorageServices storageServices)
    {
        _storageServices = storageServices;
    }
    public void UploadFile(string fileName, byte[] content)
    {
        _storageServices.SalvaFile();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var fileUploader = new FileUploader();
        fileUploader.SetStorageServices(new DiskStorageServices());
        fileUploader.UploadFile("test.txt", new byte[0]);
        fileUploader.SetStorageServices(new MemoryStorageServices());
        fileUploader.UploadFile("test.txt", new byte[0]);
    }
}