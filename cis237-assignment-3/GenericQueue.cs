using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    internal class GenericQueue<T> : IGenericQueue<T>
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
        ///          |       This may not be working           |      
        ///          |*****************************************|
        /// </summary>
        public void Enqueue(T Data)
        {
            /// <summary>
            ///          |**************************************************************|
            ///          |  Make a new variable to also reference the tail of the list  |      
            ///          |**************************************************************|
            /// </summary>
            Node oldtail = _tail;


            /// <summary>
            ///          |**************************************************************|
            ///          |      Make a new node and assign it to the tail variable      |      
            ///          |**************************************************************|
            /// </summary>
            _tail = new Node();


            /// <summary>
            ///          |**************************************************************|
            ///          |            Set the data on the new node (_tail)              |      
            ///          |**************************************************************|
            /// </summary>
            _tail.Data = Data;


            /// <summary>
            ///          |******************************************************************************************|
            ///          |     Make the next property of the new node point to null to equat the end of the list    |      
            ///          |******************************************************************************************|
            /// </summary>
            _tail.Next = null;


            /// <summary>
            ///          |**************************************************************|
            ///          |     Check to see if the list is empty. If so, make the       |
            ///          |     head point to the same location as the tail.             |      
            ///          |**************************************************************|
            /// </summary>
            if (IsEmpty)
            {
                _head = _tail;
            }
            //  |**************************************************************|
            //  |     We need to take the oldTail and make it's next           |
            //  |     property point to the tail that we just created.         |      
            //  |**************************************************************|
            else
            {
                oldtail.Next = _tail;
            }


            /// <summary>
            ///          |**************************************************************|
            ///          |                Increment the size of the list                |      
            ///          |**************************************************************|
            /// </summary>
            _size++;
        }

        /// <summary>
        ///          |*****************************************|
        ///          |       This has a big 'O' of O(1)        |      
        ///          |*****************************************|
        /// </summary>
        public T Dequeue()
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
