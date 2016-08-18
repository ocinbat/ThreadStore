using System;
using System.Threading;

namespace ThreadStore
{
    public class ThreadStore
    {
        public static T Get<T>(string key)
        {
            if (String.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), "You need to provide a key to get values from thread data store.");
            }

            object threadData = Thread.GetData(Thread.GetNamedDataSlot(String.Format("{0}-{1}", Thread.CurrentThread.ManagedThreadId, key)));

            if (threadData == null)
            {
                return default(T);
            }

            return (T)threadData;
        }

        public static void Set(string key, object value)
        {
            if (String.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), "You need to provide a key to get values from thread data store.");
            }

            Thread.SetData(Thread.GetNamedDataSlot(String.Format("{0}-{1}", Thread.CurrentThread.ManagedThreadId, key)), value);
        }
    }
}
