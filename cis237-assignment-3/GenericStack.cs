using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    internal class GenericStack<T> : IGenericStack<T>
    {
        /// <summary>
        ///          |***********************************|
        ///          | Make node class as an inner class |      
        ///          |***********************************|
        /// </summary>
        public class Node
        {
            public T Data { get; set; }

            public Node Next { get; set; }
        }

        /// <summary>
        ///          |**************************************************************|
        ///          | A couple of pointers to the head and tail of the linked list |      
        ///          |**************************************************************|
        /// </summary>
        protected Node _head;
        protected Node _tail;
        protected int _size;

        public bool IsEmpty
        {
            get
            {
                /// <summary>
                ///          |**************************************************************|
                ///          | To check whether or not it is empty we can check to see if   |
                ///          | the head pointer is null.If so, there are no nodes in the    |
                ///          | list, so it must be empty.                                   |
                ///          |**************************************************************|
                /// </summary>
                return _head == null;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        /// <summary>
        ///          |*****************************************|
        ///          |       This has a big 'O' of O(1)        |      
        ///          |*****************************************|
        /// </summary>
        public void Push(T Data)
        {
            /// <summary>
            ///          |**************************************************************|
            ///          |  Make a new variable to also reference the head of the list  |      
            ///          |**************************************************************|
            /// </summary>
            Node oldHead = _head;


            /// <summary>
            ///          |**************************************************************|
            ///          |      Make a new node and assign it to the head variable      |      
            ///          |**************************************************************|
            /// </summary>
            _head = new Node();


            /// <summary>
            ///          |**************************************************************|
            ///          |            Set the data on the new node (_head)              |      
            ///          |**************************************************************|
            /// </summary>
            _head.Data = Data;


            /// <summary>
            ///          |**************************************************************|
            ///          | Make the next property of the new node point to the old head |      
            ///          |**************************************************************|
            /// </summary>
            _head.Next = oldHead;


            /// <summary>
            ///          |**************************************************************|
            ///          |                Increment the size of the list                |      
            ///          |**************************************************************|
            /// </summary>
            _size++;


            /// <summary>
            ///          |**************************************************************|
            ///          |   Ensure that if we are adding the very first node to the    |
            ///          |   list that the tail will be pointing to the new node we     |
            ///          |   create. But only on first add.                             |
            ///          |**************************************************************|
            /// </summary>
            if (_size == 1)
            {
                _tail = _head;
            }
        }

        /// <summary>
        ///          |*****************************************|
        ///          |       This has a big 'O' of O(1)        |      
        ///          |*****************************************|
        /// </summary>
        public T Pop()
        {
            /// <summary>
            ///          |*******************************|
            ///          |  If it is empty, throw error  |      
            ///          |*******************************|
            /// </summary>
            if (IsEmpty)
            {
                throw new Exception("List is empty...");
            }


            /// <summary>
            ///          |*******************************|
            ///          |    Get the data to return     |      
            ///          |*******************************|
            /// </summary>
            T returnData = _head.Data;


            /// <summary>
            ///          |*************************************************************|
            ///          |        Move the head pointer to the next in the list        |      
            ///          |*************************************************************|
            /// </summary>
            _head = _head.Next;


            /// <summary>
            ///          |*******************************|
            ///          |      Decrease the size        |      
            ///          |*******************************|
            /// </summary>
            _size--;


            /// <summary>
            ///          |****************************************************************|
            ///          |   Check to see if we just removed the last node from the list  |      
            ///          |****************************************************************|
            /// </summary>
            if (IsEmpty)
            {
                _tail = null;
            }


            /// <summary>
            ///          |*************************************************************|
            ///          |   Return the returnData we pulled out from the first node   |      
            ///          |*************************************************************|
            /// </summary>
            return returnData;
        }

        /// <summary>
        ///          |*****************************************|
        ///          |       This has a big 'O' of O(N)        |      
        ///          |*****************************************|
        /// </summary>
        public void Display()
        {
            Console.WriteLine("This list is: ");

            /// <summary>
            ///          |*****************************************|
            ///          | Setup a currentNode to talk the list.   |
            ///          | Start if at the head node.              |      
            ///          |*****************************************|
            /// </summary>
            Node current = _head;


            /// <summary>
            ///          |*****************************************|
            ///          |  Loop through the nodes until we hit    |
            ///          |  null which will signify the end of the |
            ///          |  list.                                  |      
            ///          |*****************************************|
            /// </summary>
            while (current != null)
            {
                Console.WriteLine(current.Data);
                //   |*****************************************|
                //   |            Move to next node            |      
                //   |*****************************************|
                current = current.Next;
            }
            Console.WriteLine();
        }
        
    }
}
