using CleverenceTest;

namespace Tests;

[TestClass]
public class AsyncCallerTest
{
    [TestMethod]
    public void AsyncCallerWorks()
    {
        var h = new EventHandler((sender, args) => Thread.Sleep(4000));
        var caller = new AsyncCaller(h);

        var ok = caller.Invoke(5000, null, EventArgs.Empty);
        Assert.IsTrue(ok);
    }
}