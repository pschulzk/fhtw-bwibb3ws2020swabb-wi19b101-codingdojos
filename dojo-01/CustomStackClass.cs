using System;
using System.Collections.Generic;

namespace dojo01
{
    public class CustomStackClass<T> : ICustomStackInterface<T>
    {
        /// <summary>Internal stack object</summary>
        private readonly List<T> stack;

        public CustomStackClass()
        {
            stack = new List<T>();
        }

        public int GetLength()
        {
            return stack.Count;
        }

        public T Peek()
        {
            if (GetLength() > 0)
            {
                return stack[GetLength() - 1];
            }
            else
            {
                throw new Exception("Stack is empty.");
            }
        }

        public void Pop()
        {
            if (GetLength() > 0)
            {
                stack.RemoveAt(GetLength() - 1);
            }
            else
            {
                throw new Exception("Stack is empty.");
            }
        }

        public void Push(T v)
        {
            stack.Insert(GetLength(), v);
        }
    }
}
