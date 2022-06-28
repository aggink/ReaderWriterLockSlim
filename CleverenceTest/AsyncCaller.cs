namespace CleverenceTest;

/// <summary>
/// 
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
