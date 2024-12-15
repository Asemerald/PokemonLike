// IObserver.cs
public interface IObserver
{
    void OnNotify(string eventType, object eventData);
}