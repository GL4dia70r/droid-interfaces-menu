using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    class ProtocolDroid : Droid
    {
        // constant variable for language cost
        protected const decimal COST_PER_LANGUAGE = (15.99m * 0.13m) + 15.99m;

        // private variable unique to this class
        protected int numberLanguages;

        // Override the toString method to use the base toString method and append new information to it.
        public override string ToString()
        {
            return
                "Model: Protocol" +
                base.ToString() +
                "Number Of Languages: " +
                Environment.NewLine;
        }

        // Overriden abstract method from the droid class.
        // This calculates the total coast using the baseCost method.
        public override void CalculateTotalCost()
        {
            this.CalculateBaseCost();

            this.totalCost = this.baseCost + COST_OF_MODEL + (numberLanguages * COST_PER_LANGUAGE);
        }

        // A constructor that takes in the standard parameterrs, and the number of languages it knows. 
        // The base constructor is called to do the work of assigning the standard parameters in the base Droid class.
        public ProtocolDroid(
            string Material,
            string Color,
            int NumberLanguages
        ) : base(Material, Color)
        {
            // Set Droid model cost
            COST_OF_MODEL = 150.00m + (150.00m * 0.50m);

            // Assign the values that the base constructor is not taking care of.
            this.numberLanguages = NumberLanguages;
        }

        public ProtocolDroid()
        {
            // Do Nothing
        }
    }
}
