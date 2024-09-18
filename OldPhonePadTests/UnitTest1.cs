using NUnit.Framework;
using OldPhonePadNamespace;

namespace OldPhonePadTests
{
    public class OldPhonePadTests
    {
        [Test]
        public void Test_ValidInputs()
        {
            Assert.AreEqual("E", OldPhonePadSolution.OldPhonePad("33#"));
            Assert.AreEqual("B", OldPhonePadSolution.OldPhonePad("227*"));
            Assert.AreEqual("HELLO", OldPhonePadSolution.OldPhonePad("4433555 555666#"));
            Assert.AreEqual("TURING", OldPhonePadSolution.OldPhonePad("8 88777444666*664#"));
        }
        
        [Test]
        public void Test_InvalidInputs()
        {
            Assert.AreEqual("A", OldPhonePadSolution.OldPhonePad("2#"));
            Assert.AreEqual("B", OldPhonePadSolution.OldPhonePad("22#"));
            Assert.AreEqual("E", OldPhonePadSolution.OldPhonePad("337*"));
        }
    }
}