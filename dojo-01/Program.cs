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

            System.Diagnostics.Debug.WriteLine("Stack Length after Push: " + test.GetLength().ToString());
            System.Diagnostics.Debug.WriteLine("Stack Peek after Push: " + test.Peek().ToString());

            test.Pop();

            System.Diagnostics.Debug.WriteLine("Stack Length after Pop: " + test.GetLength().ToString());
            System.Diagnostics.Debug.WriteLine("Stack Peek afteer Pop: " + test.Peek().ToString());
        }
    }
}
