namespace CleverenceTest;

/// <summary>
/// Есть "сервер" в виде статического класса.  
/// У него есть переменная count(тип int) и два метода, которые позволяют эту переменную читать и писать: GetCount() и AddToCount(int value). 
/// К серверу стучатся множество параллельных клиентов, которые в основном читают, но некоторые добавляют значение к count.
/// Нужно реализовать GetCount / AddToCount так, чтобы: 
/// * читатели могли читать параллельно, без выстраивания в очередь по локу;
/// * писатели писали только последовательно и никогда одновременно; 
/// * пока писатели добавляют и пишут, читатели должны ждать окончания записи.
/// </summary>
public static class Server
{
    private static int count;
    private static readonly ReaderWriterLockSlim _lock = new();

    public static int GetCount()
    {
        try
        {
            _lock.EnterReadLock();
            return count;
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }

    public static void AddToCount(int value)
    {
        try
        {
            _lock.EnterWriteLock();
            count = checked(count + value);
        }
        finally
        {
            _lock.ExitWriteLock();
        }
    }
}