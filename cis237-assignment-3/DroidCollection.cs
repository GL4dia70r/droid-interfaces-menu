// David Allen
// 10/17/22 - 10//22
// CIS237 - Assignment - 3
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace cis237_assignment_3
{
    class DroidCollection : IDroidCollection 
    {
        // +----------------------------------------------------+
        // | Private variable to hold the collection of droids. |
        // +----------------------------------------------------+
        private IDroid[] droidSectors;


        // +----------------------------------------------------+
        // | Private variable to hold the collection of droids. |
        // +----------------------------------------------------+
        private int collectionLength;

        // +---------------------------------------------------------+
        // | A constructor that takes in the size of the collection. |
        // | It sets the size of the internal array that will be     |
        // | used. It also sets the length of the collection to      |
        // | zero since nothing is added yet.                        |
        // +---------------------------------------------------------+
        public DroidCollection(int collectionSize)
        {
            this.droidSectors = new Droid[collectionSize];
            this.collectionLength = 0;
        }

        

        // +---------------------------------------------------------------------------------------+
        // | Adds new protocol droid information gathered by the parameters passed passed through. |
        // +---------------------------------------------------------------------------------------+
        public bool AddNewProtocolDroid(
            string Material,
            string Color,
            int NumberLanguages
        )
        {
            // If space is available to add the new droid
            if (collectionLength < (droidSectors.Length -1))
            {
                // Add the new droid. Note: the droidCollection is of type 'IDroid', but the droid being stored is 
                // of type Protocol Droid. This is okay because of 'Polymorphism'.
                droidSectors[collectionLength++] = new ProtocolDroid(
                        Material, 
                        Color, 
                        NumberLanguages
            );
                // Increases the length of the collection.
                collectionLength++;

                // Returns successful
                return true;
            }
            // Else, there is no room for the droid.
            else
            {
                // Returns unsuccessful
                return false;
            }
        }

        // +---------------------------------------------------------------------------------------+
        // | Adds new utility droid information gathered by the parameters passed passed through.  |
        // +---------------------------------------------------------------------------------------+
        public bool AddNewUtilityDroid(
            string Material,
            string Color,
            bool HasToolBox,
            bool HasComputerConnection,
            bool HasScanner
        )
        {

            if (collectionLength < (droidSectors.Length - 1))
            {
                droidSectors[collectionLength++] = new UtilityDroid(
                        Material,
                        Color,
                        HasToolBox,
                        HasComputerConnection,
                        HasScanner
            );
                collectionLength++;

                return true;
            }
            else
            {
                return false;
            }
        }

        // +---------------------------------------------------------------------------------------+
        // | Adds new janitor droid information gathered by the parameters passed passed through.  |
        // +---------------------------------------------------------------------------------------+
        public bool AddNewJanitorDroid(
            string Material,
            string Color,
            bool HasTrashCompactor,
            bool HasVacuume,
            bool HasToolBox,
            bool HasComputerConnection,
            bool HasScanner
        )
        {

            if (collectionLength < (droidSectors.Length - 1))
            {
                droidSectors[collectionLength++] = new JanitorDroid(
                        Material,
                        Color,
                        HasTrashCompactor,
                        HasVacuume,
                        HasToolBox,
                        HasComputerConnection,
                        HasScanner
            );
                collectionLength++;

                return true;
            }
            else
            {
                return false;
            }
        }

        // +----------------------------------------------------------------------------------------+
        // | Adds new Astromech droid information gathered by the parameters passed passed through. |
        // +----------------------------------------------------------------------------------------+
        public bool AddNewAstromechDroid(
          string Material,
          string Color,
          bool HasToolBox,
          bool HasComputerConnection,
          bool HasScanner,
          bool HasNavigation,
          int NumberOfShips
      )
        {

            if (collectionLength < (droidSectors.Length - 1))
            {
                droidSectors[collectionLength++] = new AstromechDroid(
                        Material,
                        Color,
                        HasToolBox,
                        HasComputerConnection,
                        HasScanner,
                        HasNavigation,
                        NumberOfShips
            );
                collectionLength++;

                return true;
            }
            else
            {
                return false;
            }
        }

        // +-----------------------------------------------------------------------------+
        // | The last method that must be implemented due to implementing the interface. |
        // | This method iterates through the list of droids and creates a printable     |
        // | string that could be either printed to the screen, or sent to a file.       |
        // +-----------------------------------------------------------------------------+
        public string GetPrintString()
        {
            // Declare the return string
            string returnedString = null;

            // For each droid in the droidCollection
            foreach (IDroid droid in droidSectors)
            {
                // If the droid is not null (It might be since the array may not be full.)
                if (droid != null)
                {
                    // Calculate the total cost of the droid. Since we are are using inheritance and Polymorphism
                    // the program will automatically know which version of CalculateTotalCost it needs to call based
                    // on which particular type it is looking at during the foreach loop.
                    droid.CalculateTotalCost();
                    // Create the string now that the total cost has been calculated
                    returnedString += "-----------------------------------------------------------+" + Environment.NewLine;
                    returnedString += droid.ToString() + Environment.NewLine + Environment.NewLine;
                    returnedString += "Total Cost: " + droid.TotalCost.ToString("C") + Environment.NewLine;
                    returnedString += "-----------------------------------------------------------+" + Environment.NewLine;
                    returnedString += Environment.NewLine;
                }
            }

            // return the completed string
            return returnedString;
        }

        /// <summary>
        ///          |*****************************************|
        ///          |          This is not working            |      
        ///          |*****************************************|
        /// </summary>
        public bool SortByModel()
        {
            IGenericStack<AstromechDroid> astromechStack = new GenericStack<AstromechDroid>();
            IGenericStack<JanitorDroid> janitorStack = new GenericStack<JanitorDroid>();
            IGenericStack<UtilityDroid> utilityStack = new GenericStack<UtilityDroid>();
            IGenericStack<ProtocolDroid> protocolStack = new GenericStack<ProtocolDroid>();

            IGenericQueue<IDroid> droidQueue = new GenericQueue<IDroid>();

            //Add droids to appropriate stack types
            for (int i = 0; i < collectionLength; i++)
            {
                try
                {
                    astromechStack.Add((AstromechDroid)droidSectors[i]);
                }
                catch
                {
                    try
                    {
                        janitorStack.Add((JanitorDroid)droidSectors[i]);
                    }
                    catch
                    {
                        try
                        {
                            utilityStack.Add((UtilityDroid)droidSectors[i]);
                        }
                        catch
                        {
                            try
                            {
                                protocolStack.Add((ProtocolDroid)droidSectors[i]);
                            }
                            catch
                            {
                                return false;
                            }
                        }
                    }
                }
                i++;
            }
            //Add droids in order to the queue
            while (astromechStack != null)
            {
                droidQueue.Add(astromechStack.Pop());
            }
            while (janitorStack != null)
            {
                droidQueue.Add(janitorStack.Pop());
            }
            while (utilityStack != null)
            {
                droidQueue.Add(utilityStack.Pop());
            }
            while (protocolStack != null)
            {
                droidQueue.Add(protocolStack.Pop());
            }

            //Dequeue droids back into the array
            for (int i = 0; droidQueue != null; i++)
            {
                    droidSectors[i] = droidQueue.Dequeue();
            }
            return true;
        }

        /// <summary>
        ///          |*****************************************|
        ///          |          This is not working            |      
        ///          |*****************************************|
        /// </summary>
        public bool SortByTotalCost()
        {
            if (droidSectors != null)
            {
                
                MergeSort mergeSort = new MergeSort(droidSectors, collectionLength);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
