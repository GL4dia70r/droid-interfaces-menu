using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    internal interface IGenericQueue<Model>
    {
        /// <summary>
        ///                     Method
        ///          |*******************************|
        ///          | Adds to the front of the list |
        ///          |*******************************| 
        /// </summary>
        void AddToFront(Model Data);


        /// <summary>
        ///                      Method
        ///          |******************************|
        ///          | Adds to the back of the list |
        ///          |******************************|                                    
        /// </summary>
        void AddToBack(Model Data);


        /// <summary>
        ///                       Method
        ///          |************************************|        
        ///          | Removes from the front of the list |
        ///          |************************************|
        /// </summary>
        Model RemoveFromFront();


        /// <summary>
        ///                       Method
        ///          |***********************************|
        ///          | Removes from the back of the list |
        ///          |***********************************|
        /// </summary>
        Model RemoveFromBack();


        /// <summary>
        ///                   Method
        ///          |***********************|
        ///          | Displays linked lists |      
        ///          |***********************|
        /// </summary>
        void Display();



        /// <summary>
        ///                          Property
        ///          |**************************************|
        ///          |       Is empty? Get information      |      
        ///          |**************************************|
        /// </summary>
        bool IsEmpty { get; }


        /// <summary>
        ///                     Property
        ///          |******************************|
        ///          |         Size Getter          |      
        ///          |******************************|
        /// </summary>
        int Size { get; }
    }
}
