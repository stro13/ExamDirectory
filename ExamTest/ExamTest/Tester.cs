using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTest
{
    [TestFixture]
    public class Tester
    {
        [Test]
        public void Empty()
        {
            Parser parser = new Parser(@"C:\Users\Yaroslav Fedorchenko\Desktop\Empty.txt");
            parser.start();

            Assert.AreEqual(0, parser.words.Count);


        }

        [Test]
        public void WrongFile()
        {
            Parser parser = new Parser(@"C:\Users\Yaroslav Fedorchenko\Desktop\wrong.bmp");
            parser.start();

            Assert.AreEqual(-1, parser.Exception);
        }

        [Test]
        public void HomosapiensCount()
        {
            Parser parser = new Parser(@"C:\Users\Yaroslav Fedorchenko\Desktop\Homosapiens.txt");
            parser.start();

            string f = "Homosapiens";

            Assert.AreEqual(2, parser.words[f]);

        }




    }
}
