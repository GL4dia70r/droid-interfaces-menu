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
        public class Node<T>
        {
            public T Data { get; set; }

            public Node<T> Next { get; set; }
        }

        /// <summary>
        ///          |**************************************************************|
        ///          | A couple of pointers to the head and tail of the linked list |      
        ///          |**************************************************************|
        /// </summary>
        protected Node<T> _head;
        protected Node<T> _tail;
        protected int _size;

        public int Size
        {
            get
            {
                return _size;
            }
        }

        public GenericQueue<T>.Node<T> Head
        {
            get { return _head; }

            set { _head = value; }
        }

        public GenericQueue<T>.Node<T> Tail
        {
            get { return _tail; }

            set { _tail = value; }
        }

        public int Length
        {
            get { return _size; }

            set { _size = value; }
        }

        /// <summary>
        ///          |*****************************************|
        ///          |       This may not be working           |      
        ///          |*****************************************|
        /// </summary>
        public void Add(T Data)
        {
            Node<T> newNode = new Node<T>();

            newNode.Data = Data;

            if (_head == null)
            {
                Head = newNode;
                Tail = newNode;
                Length++;
            }
            else
            {
                _tail = newNode;
                newNode.Next = Tail;
                Tail = newNode;
                Length++;
            }
        }

        /// <summary>
        ///          |*****************************************|
        ///          |       This may not be working           |      
        ///          |*****************************************|
        /// </summary>
        public T Dequeue()
        {
            T returnData = default(T);

            Node<T> tempNode = new Node<T>();

            if (this.Tail != null)
            {
                returnData = this.Tail.Data;

                tempNode = Tail;

                this.Tail = this.Tail.Next;

                if (this.Tail != null)
                {
                    this.Tail.Next = null;
                }

                tempNode.Next = null;

                this.Length--;
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
            Node<T> current = Head;


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
