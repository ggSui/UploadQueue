using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace UnitTestProjectUpload
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ConcurrentQueue<int> concurrentQueue = new ConcurrentQueue<int>();
            Parallel.For(1, 100, x => { concurrentQueue.Enqueue(x); });
            int value = 0;
            concurrentQueue.TryDequeue(out value);
            Assert.AreNotEqual(0, value);
            Assert.AreEqual(98, concurrentQueue.Count);

            concurrentQueue.TryDequeue(out value);
            Assert.AreEqual(2, value);
            Assert.AreEqual(97, concurrentQueue.Count);
        }
    }
}
