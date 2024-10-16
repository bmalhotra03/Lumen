using Microsoft.VisualStudio.TestTools.UnitTesting;
using lumenClass;

namespace LumenClass.Tests
{
    [TestClass]
    public class LumenTests
    {
        [TestMethod]
        public void TestInitialState()
        {
            Lumen lumen = new Lumen();
            Assert.AreEqual(100, lumen.glow());
        }
        
        [TestMethod]
        public void TestActiveState()
        {
            Lumen lumen = new Lumen(p: 20);
            Assert.IsTrue(lumen.glow() > 0);
            Assert.IsTrue(lumen.glow() > 0);
            Assert.IsFalse(lumen.glow() > 0);
        }
        
        [TestMethod]
        public void TestStableState()
        {
            Lumen lumen = new Lumen(s: 2);
            Assert.IsTrue(lumen.glow() > 0);
            Assert.IsTrue(lumen.glow() > 0);
            Assert.IsTrue(lumen.glow() > 0);
            Assert.IsTrue(lumen.glow() > 0);
            Assert.IsFalse(lumen.glow() > 0);
        }
        
        [TestMethod]
        public void TestErraticPower()
        {
            Lumen lumen = new Lumen(b: 50, p: 100);
            Assert.AreEqual(25, lumen.glow());
            Assert.AreEqual(12, lumen.glow());
            Assert.AreEqual(6, lumen.glow());
            Assert.AreEqual(3, lumen.glow());
            Assert.AreEqual(1, lumen.glow());
            Assert.AreEqual(0, lumen.glow());
        }
        
        [TestMethod]
        public void TestDimnessValue()
        {
            Lumen lumen = new Lumen(b: 100, p: 1);
            Assert.AreEqual(50, lumen.glow());
            Assert.AreEqual(25, lumen.glow());
            Assert.AreEqual(12, lumen.glow());
            Assert.AreEqual(6, lumen.glow());
            Assert.AreEqual(3, lumen.glow());
            Assert.AreEqual(1, lumen.glow());
            Assert.AreEqual(0, lumen.glow());
        }
        
        [TestMethod]
        public void TestReset()
        {
            Lumen lumen = new Lumen(p: 10);
            Assert.AreEqual(10, lumen.glow());
            Assert.AreEqual(9, lumen.glow());
            Assert.AreEqual(8, lumen.glow());
            Assert.AreEqual(7, lumen.glow());
            Assert.AreEqual(6, lumen.glow());
            Assert.AreEqual(5, lumen.glow());
            Assert.AreEqual(4, lumen.glow());
            Assert.AreEqual(3, lumen.glow());
            Assert.AreEqual(2, lumen.glow());
            Assert.AreEqual(1, lumen.glow());
            lumen.Reset();
            Assert.AreEqual(100, lumen.glow());
            Assert.AreEqual(99, lumen.glow());
            Assert.AreEqual(98, lumen.glow());
            Assert.AreEqual(97, lumen.glow());
            Assert.AreEqual(96, lumen.glow());
            Assert.AreEqual(95, lumen.glow());
            Assert.AreEqual(94, lumen.glow());
            Assert.AreEqual(93, lumen.glow());
            Assert.AreEqual(92, lumen.glow());
            Assert.AreEqual(91, lumen.glow());
        }
    }
}