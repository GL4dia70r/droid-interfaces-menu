using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    class UtilityDroid : Droid
    {
        // +-----------------------------------------------------------------+
        // | A constant that can be used in this class or any child classes. |
        // +-----------------------------------------------------------------+
        protected const decimal COST_PER_OPTION = 25.99m + (25.99m * 0.15m) / 0.25m;

        // +--------------------------------------------------------------------------------------------------+
        // | A few class level variables that can be used in this class or any derived classes of this class. |
        // +--------------------------------------------------------------------------------------------------+
        protected bool hasToolBox;
        protected bool hasComputerConnection;
        protected bool hasScanner;
        
        
        protected virtual string GetModelName()
        {
            return "Utility";
        }


        // +-------------------------------------------------------------------------+
        // |  A overridden toString method to output the information for this droid. |
        // |  uses the base toString method and appends more information to it.      |
        // +-------------------------------------------------------------------------+
        public override string ToString()
        {
            return
                "Model: " + GetModelName() +
                Environment.NewLine +
                base.ToString() +
                Environment.NewLine +
                "Has a tool box: " + this.hasToolBox +
                Environment.NewLine +
                "Has a computer connection: " + this.hasComputerConnection +
                "Has a scanner: " + this.hasScanner +
                Environment.NewLine;
        }

        // +--------------------------------------------------------------------------------------------------+
        // | A overriden method to calculate the total cost. This method uses the base cost from the parent   |
        // | droid class and the cost of the options of this class to vreate the total cost.                  |
        // +--------------------------------------------------------------------------------------------------+
        public override void CalculateTotalCost()
        {
            this.CalculateBaseCost();

            this.totalCost = this.baseCost + COST_OF_MODEL + this.CalculateCostOfOptions();
        }

        // +--------------------------------------------------------------------------------------------------+
        // | A virtual method to calculate the cost of the bool variables. This method can be overriden in    |
        // | child classes to calculate cost of options.                                                      |  
        // +--------------------------------------------------------------------------------------------------+
        protected virtual decimal CalculateCostOfOptions()
        {
            decimal optionCost = 0;

            if (hasToolBox)
            {
                optionCost += COST_PER_OPTION;
            }

            if (hasComputerConnection)
            {
                optionCost += COST_PER_OPTION;
            }

            if (hasScanner)
            {
                optionCost += COST_PER_OPTION;
            }

            return optionCost;
        }



        // +--------------------------------------------------------------------+
        // |  A constructor that takes standard parameters to create the droid. |
        // |  The base constructor is called to do some of the work.            |
        // +--------------------------------------------------------------------+
        public UtilityDroid(
            string Material,
            string Color,
            bool ToolBox,
            bool ComputerConnection,
            bool Scanner

        ) : base(Material, Color)

        {
            // Set Droid model cost
            COST_OF_MODEL = 150.00m + (150.00m * 0.50m);

            // Assign the values that the base constructor is not taking care of.
            this.hasToolBox = ToolBox;
            this.hasComputerConnection = ComputerConnection;
            this.hasScanner = Scanner;
        }

        public UtilityDroid()
        {
            // Do Nothing
        }
    }
}
