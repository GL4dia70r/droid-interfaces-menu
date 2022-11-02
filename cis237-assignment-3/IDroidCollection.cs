using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    interface IDroidCollection
    {
        // +-----------------------------------------------------------------------+
        // | Various overloaded Add methods to add a new droid to the collection.  |
        // +-----------------------------------------------------------------------+
        bool AddNewProtocolDroid(
            string Material, 
            string Color, 
            int NumberOfLanguages
        );

        bool AddNewUtilityDroid(
            string Material, 
            string Color, 
            bool HasToolBox, 
            bool HasComputerConnection, 
            bool HasArm
        );

        bool AddNewJanitorDroid(
            string Material, 
            string Color, 
            bool HasToolBox, 
            bool HasComputerConnection, 
            bool HasArm, 
            bool HasTrashCompactor, 
            bool HasVaccum
        );

        bool AddNewAstromechDroid(
            string Material, 
            string Color, 
            bool HasToolBox, 
            bool HasComputerConnection, 
            bool HasArm, 
            bool HasFireExtinguisher, 
            int NumberOfShips
        );

        // +---------------------------------------------------------------------------------------+
        // | Method to get the data for a droid into a nicely formatted string that can be output. |
        // +---------------------------------------------------------------------------------------+
        string GetPrintString();
    }
}
