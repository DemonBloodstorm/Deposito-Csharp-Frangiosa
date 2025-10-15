using System;
using System.Collections.Generic;

public interface INewsSubscriber
{
    public void Update(string news);
}

public class NewsAgency
{
    private static NewsAgency _instance;
    private List<INewsSubscriber> _subscribers = new List<INewsSubscriber>();
    private string _news;

    public static NewsAgency Instance{
        get{   
            if(_instance == null)
            _instance = new NewsAgency();
            return _instance;
        }
    }   

    public string News{
        get{return _news;}
        set
        {
            _news = value;
            NotificaAgliIscritti();
        }
    }
    public void Iscirviti(INewsSubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }
    public void Disiscrivi(INewsSubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }
    private void NotificaAgliIscritti()
    {
        foreach(var subscriber in _subscribers){
            subscriber.Update(_news);
        }
    }
}  

public class MobileApp : INewsSubscriber
    {
        void INewsSubscriber.Update(string news){
            Console.WriteLine($"Notification on mobile: Hello there! Here is the news: {news}");
        }
    }
public class EmailClient : INewsSubscriber
    {
        void INewsSubscriber.Update(string news){
            Console.WriteLine($"email sent: General Kenoby, here is the news: {news}");
        }
    }

public class Program{
    public static void Main(string[] args)
    {
        var newsAgency = NewsAgency.Instance;
        var mobileApp = new MobileApp();
        var emailClient = new EmailClient();
        newsAgency.Iscirviti(mobileApp);
        newsAgency.Iscirviti(emailClient);
        newsAgency.News = "Stardestroyer is coming!";
    }
}