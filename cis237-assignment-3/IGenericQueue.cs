using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    internal interface IGenericQueue<T>
    {
        /// <summary>
        ///                     Method
        ///          |*******************************|
        ///          | Adds to the front of the list |
        ///          |*******************************| 
        /// </summary>
        void Enqueue(T Data);

        /// <summary>
        ///                       Method
        ///          |*************************************|        
        ///          | Dequeues from the front of the list |
        ///          |*************************************|
        /// </summary>
        T Dequeue();

        /// <summary>
        ///                   Method
        ///          |***********************|
        ///          | Displays linked lists |      
        ///          |***********************|
        /// </summary>
        void Display();

        /// <summary>
        ///                     Property
        ///          |******************************|
        ///          |         Size Getter          |      
        ///          |******************************|
        /// </summary>
        int Size { get; }
    }
}
