using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace cis237_assignment_3
{
    internal interface IGenericStack<T>
    {
        /// <summary>
        ///                     Method
        ///          |*******************************|
        ///          | Adds to the front of the list |
        ///          |*******************************| 
        /// </summary>
        void Push(T Data);

        /// <summary>
        ///                       Method
        ///          |********************************|        
        ///          | Pop from the front of the list |
        ///          |********************************|
        /// </summary>
        T Pop();

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
