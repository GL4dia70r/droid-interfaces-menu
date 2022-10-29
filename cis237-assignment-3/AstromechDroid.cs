using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    internal class AstromechDroid : UtilityDroid
    {
        // +-------------------------------------------------------------------+
        // | A constant that can be used in this class or any derived classes. |
        // +-------------------------------------------------------------------+
        protected const decimal COST_PER_SHIP = (500.00m * 0.75m) + 500.00m;


        // +----------------------------------------------------------------------+
        // | A few class level variables that can be accessed in derived classes. |
        // +----------------------------------------------------------------------+
        protected bool hasNavigation;
        protected int numberShips;


        protected override string GetModelName()
        {
            return "Astromech";
        }


        // +--------------------------------------------------------------------------------------------------+
        // | Overridden toString that uses the base toString method and appends the information of this class.|
        // +--------------------------------------------------------------------------------------------------+
        public override string ToString()
        {
            return 
                base.ToString() + 
                "Has a Navigation system: " + this.hasNavigation + 
                Environment.NewLine +
                "Number of ships: " + this.numberShips +
                Environment.NewLine;
        }

        // +---------------------------------------------------------------------------------------------------+
        // | Overriden method to calculate the total cost. Uses work from the base class to achive the answer. |
        // +---------------------------------------------------------------------------------------------------+
        public override void CalculateTotalCost()
        {
            this.CalculateBaseCost();

            this.totalCost = this.baseCost + COST_OF_MODEL + this.CalculateCostOfOptions() + this.CalculateCostOfShips();
        }

        // +--------------------------------------------------------------------------------------------------+
        // | Override the CalculateCostOfOptions method. Use the base class implementation of the method and  |
        // | tack on the cost of the new options.                                                             |  
        // +--------------------------------------------------------------------------------------------------+
        protected override decimal CalculateCostOfOptions()
        {
            decimal optionCost = 0;

            optionCost += base.CalculateCostOfOptions();

            if (hasNavigation)
            {
                optionCost += COST_PER_OPTION;
            }

            return optionCost;
        }


        // +--------------------------------------------------------------------+
        // | Protected virtual method that can be overriden in derived classes. |
        // | Calculates the cost of ships.                                      |
        // +--------------------------------------------------------------------+
        protected virtual decimal CalculateCostOfShips()
        {
            return COST_PER_SHIP * numberShips;
        }

        // +--------------------------------------------------------------------+
        // |  A constructor that takes lots of parameters to create the droid.  |
        // |  The base constructor is called to do some of the work.            |
        // +--------------------------------------------------------------------+
        public AstromechDroid( 
            string Material, 
            string Color, 
            bool ToolBox, 
            bool ComputerConnection, 
            bool Scanner, 
            bool Navigation, 
            int NumberShips

        ) : base(
            Material, 
            Color, 
            ToolBox, 
            ComputerConnection, 
            Scanner
        )
        {
            // Set Droid model cost
            COST_OF_MODEL = 245.99m + 50.00m + (150.00m * 3.50m);

            // Assign the values that the base constructor is not taking care of.
            this.hasNavigation = Navigation;
            this.numberShips = NumberShips;
        }

        public AstromechDroid() 
        { 
            // Do Nothing
        }
    }
}
