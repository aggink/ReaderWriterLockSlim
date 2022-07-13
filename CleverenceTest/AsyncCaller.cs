namespace CleverenceTest;

/// <summary>
/// Нужно реализовать возможность полусинхронного вызова делегата (написать реализацию класса AsyncCaller).
/// "Полусинхронного" в данном случае означает, что делегат будет вызван, и вызывающий поток будет ждать, пока вызов не выполнится. 
/// Но если выполнение делегата займет больше 5000 миллисекунд, то ac.Invoke выйдет и вернет в completedOK значение false.
/// </summary>
public class AsyncCaller
{
    private readonly EventHandler h;

    public AsyncCaller(EventHandler handler)
    {
        h = handler;
    }

    public bool Invoke(int millisecondsTimeout, object? sender, EventArgs e)
    {
        var task = Task.Factory.StartNew(() => h.Invoke(sender, e));
        return task.Wait(millisecondsTimeout);
    }
}
