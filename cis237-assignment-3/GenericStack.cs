using System;
using System.Collections.Generic;
using System.Linq;
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
        protected class Node
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
        public void AddModel(T Data)
        {
            Node newNode = new Node();

            newNode.Data = Data;

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
                _size++;
            }
            else
            {
                _head.Next = newNode;
                newNode.Next = _head;
                _head = newNode;
                _size++;
            }
        }

        public T Pop()
        {
            T returnData = default(T);

            Node tempNode = new Node();

            if (this._head != null)
            {
                returnData = this._head.Data;

                tempNode = _head;

                this._head = this._head.Next;

                if (this._head != null)
                {
                    this._head.Next = null;
                }

                tempNode.Next = null;

                this._size--;
            }    
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
