using CleverenceTest;

namespace Tests;

[TestClass]
public class ServerTest
{
    [TestMethod]
    public void AddToCount()
    {
        List<Task> tasks = new();
        for(int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 10; j++)
                tasks.Add(Task.Factory.StartNew(() => Server.GetCount()));
            
            tasks.Add(Task.Factory.StartNew(() => Server.AddToCount(1)));
        }

        Task.WaitAll(tasks.ToArray());
        Assert.AreEqual(100, Server.GetCount());
    }
}