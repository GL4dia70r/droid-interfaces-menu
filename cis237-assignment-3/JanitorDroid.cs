using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    internal class JanitorDroid : UtilityDroid
    {
        // +----------------------------------------------------------------------+
        // | A few class level variables that can be accessed in derived classes. |
        // +----------------------------------------------------------------------+
        protected bool hasTrashCompactor;
        protected bool hasVacuum;


        protected override string GetModelName()
        {
            return "Janitor"; 
        }

        // +--------------------------------------------------------------------------------------------------+
        // | Overridden toString that uses the base toString method and appends the information of this class.|
        // +--------------------------------------------------------------------------------------------------+
        public override string ToString()
        {
            return
                base.ToString() +
                "Has a trash compactor: " + this.hasTrashCompactor +
                Environment.NewLine +
                "Has a vacuum: " + this.hasVacuum +
                Environment.NewLine;
        }


        // +--------------------------------------------------------------------------------------------------+
        // | Override the CalculateCostOfOptions method. Use the base class implementation of the method and  |
        // | tack on the cost of the new options.                                                             |  
        // +--------------------------------------------------------------------------------------------------+
        protected override decimal CalculateCostOfOptions()
        {
            decimal optionCost = 0;

            optionCost += base.CalculateCostOfOptions();

            if (hasTrashCompactor)
            {
                optionCost += COST_PER_OPTION;
            }

            if (hasVacuum)
            {
                optionCost += COST_PER_OPTION;
            }

            return optionCost;
        }

        // +--------------------------------------------------------------------+
        // |  A constructor that takes lots of parameters to create the droid.  |
        // |  The base constructor is called to do some of the work.            |
        // +--------------------------------------------------------------------+
        public JanitorDroid(
            string Material, 
            string Color, 
            bool TrashCompactor, 
            bool Vacuum, 
            bool ToolBox, 
            bool ComputerConnection, 
            bool Scanner

        ) : base(
            Material, 
            Color, 
            ToolBox, 
            ComputerConnection, 
            Scanner
        )
        {
            // Set Droid model cost
            COST_OF_MODEL = 175.00m - 50.00m + (150.00m * 1.50m);

            // Assign the values that the base constructor is not taking care of.
            this.hasTrashCompactor = TrashCompactor;
            this.hasVacuum = Vacuum;
        }

        public JanitorDroid()
        {
            // Do Nothing
        }
    }
}
