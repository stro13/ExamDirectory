using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser(@"C:\Users\Yaroslav Fedorchenko\Desktop\Вопросы.txt");
            parser.start();
            parser.show();

        }
    }
}
