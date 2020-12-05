using System;

namespace dojo01
{
    class MainClass
    {
        public static void Main()
        {
            CustomStackClass<string> test = new CustomStackClass<string>();

            test.Push("AAA");
            test.Push("BBB");

            Console.WriteLine("Stack Length after Push: " + test.GetLength().ToString());
            Console.WriteLine("Stack Peek after Push: " + test.Peek().ToString());

            test.Pop();

            Console.WriteLine("Stack Length after Pop: " + test.GetLength().ToString());
            Console.WriteLine("Stack Peek afteer Pop: " + test.Peek().ToString());
        }
    }
}
// test commit