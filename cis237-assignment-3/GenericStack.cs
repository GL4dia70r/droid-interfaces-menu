using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    internal class GenericStack<Model> : IGenericStack<Model>
    {
        /// <summary>
        ///          |***********************************|
        ///          | Make node class as an inner class |      
        ///          |***********************************|
        /// </summary>
        protected class Node
        {
            public Model Data { get; set; }

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
        public void AddToFront(Model Data)
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
        public void AddToBack(Model Data)
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
        public Model RemoveFromFront()
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
            Model returnData = _head.Data;


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
        ///          |-----------------------------------------|
        ///          |  Removing from back is not as easy as   |
        ///          |  front. It requires more work due to    |
        ///          |  looping.                               |      
        ///          |*****************************************|
        /// </summary>
        public Model RemoveFromBack()
        {
            /// <summary>
            ///          |*******************************************|
            ///          |  Check if empty, throw exception if it is |      
            ///          |*******************************************|
            /// </summary>
            if (IsEmpty)
            {
                throw new Exception("List is empty...");
            }


            /// <summary>
            ///          |***********************************************|
            ///          |    Get the data to return right off the bat   |      
            ///          |***********************************************|
            /// </summary>
            Model returnData = _tail.Data;


            /// <summary>
            ///          |********************************************************************|
            ///          |  Check to see if we are on the last node. If so, we can just set   |
            ///          |  the head and tail to null since we want to remove the only node   |
            ///          |   remaining in the list.                                           |      
            ///          |********************************************************************|
            /// </summary>
            if (_head == _tail)
            {
                _head = null;
                _tail = null;
            }
            //  |*************************************************************|
            //  |  Else, we need to traverse the list and stop right before   |
            //  |  we reach the tail.                                         |      
            //  |*************************************************************|
            else
            {
                /// <summary>
                ///          |*************************************************************|
                ///          |  Create a temporary node to use to 'walk' down the list.    |      
                ///          |*************************************************************|
                /// </summary>
                Node current = _head;


                /// <summary>
                ///          |********************************************************************|
                ///          |  Keep moving forward until the current.Next is equal to the tail.  |
                ///          |  Keep looping while current.Next does not equal (!=) '_tail'       |      
                ///          |********************************************************************|
                /// </summary>
                while (current.Next != _tail)
                {

                    // |*************************************************************|
                    // |  Set the current pointer to the current pointers next node. |      
                    // |*************************************************************| 
                    current = current.Next;
                }


                /// <summary>
                ///          |****************************************************************|
                ///          |  I am now in position to do some work. Set the tail to the     |
                ///          |  current position.                                             |      
                ///          |****************************************************************|
                /// </summary>
                _tail = current;
                // |*************************************************************|
                // |  Make the last node that we are removing go away by setting |
                // |  tail's next property to null.                              |      
                // |*************************************************************|
                _tail.Next = null;
            }


            /// <summary>
            ///          |***************************|
            ///          |   Return the returnData   |      
            ///          |***************************|
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
