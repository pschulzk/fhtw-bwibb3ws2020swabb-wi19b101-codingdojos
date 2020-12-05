using System.Collections.Generic;

namespace dojo01
{
    public interface ICustomStackInterface<T>
    {
        /// <summary>Returns the object from the top of the stack</summary>
        T Peek();
        /// <summary>Adds a new object to the stack</summary>
        void Push(T v);
        /// <summary>Removes an object from the stack</summary>
        void Pop();
    }
}
