using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using SerialNumber.Components;
using Assert = NUnit.Framework.Assert;

namespace UnitTestSerialNumber
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void GetSerialNumber()
        {
            int startNumber = 2;
            SerialNumberBase.SetStartNumber(startNumber);
            Assert.AreEqual(startNumber,SerialNumberBase.GetNumber());           
        }

        [Test]
        public void DecrimentManyTimes()
        {
            int startNumber = 2;
            SerialNumberBase.SetStartNumber(startNumber);

            for (int i = 0; i < 10; i++)
            {
                SerialNumberBase.Dicrement();
            }

            Assert.AreEqual(1,SerialNumberBase.GetNumber());
        }

        [Test]
        public void GetNumbersInStream()
        {
            var range = new List<int> { 1,2,3,4,5,6,7,8,9,10};
            var act = new List<int>();
            int startNumber = 1;
            SerialNumberBase.SetStartNumber(startNumber);

            Thread[] threads = new Thread[10];

            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(() =>act.Add(SerialNumberBase.GetNumber()));
                threads[i].Name = string.Format("Работает поток: #{0}", i);
            }

            foreach (Thread t in threads)
            {   t.Start();}
          
            Assert.AreEqual(range,act);
        }
    }
}
