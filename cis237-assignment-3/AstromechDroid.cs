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
        // constant variable for cost per ship
        protected const decimal COST_PER_SHIP = 5000m;

        // variables to hold values
        private bool _navigation;
        private int _numberShips;

        /// <summary>
        ///            - Properties
        /// </summary>
        public new string Model { get; set; }

        public bool Navigation
        {
            get { return _navigation; }
            set { _navigation = value; }
        }

        public int NumberShips
        {
            get { return _numberShips; }
            set { _numberShips = value; }
        }

        public new decimal BaseCost { get; set; }

        public new decimal TotalCost { get; set; }


        /// <summary>
        ///            - Methods
        /// </summary>
        /// <returns> ToString() and CalculateBaseCost()/ CalculateTotalCost() </returns>
        public override string ToString()
        {
            return $"{base.ToString()} {Navigation, 38} {NumberShips, 12} {this.CalculateBaseCost().ToString("C"), 15}";
        }

        // Have not been able to get to work, stores base cost and this base cost into TotalCost
        public override void CalculateTotalCost()
        {
            this.TotalCost = base.CalculateBaseCost() + this.CalculateBaseCost();
            return;
        }

        // gets the value for base total cost.
        protected virtual new decimal CalculateBaseCost()
        {
            this.BaseCost = base.CalculateBaseCost() +
            this.GetBoolCost(Navigation, COST_PER_OPTION) +
            this.GetNumberedCosts(NumberShips, COST_PER_SHIP);

            return this.BaseCost;
        }

        /// <summary>
        ///             - Constructors
        /// </summary>
        /// <param name="Model"> name of class is stored here </param>
        /// <param name="Material"> name of material is stored here </param>
        /// <param name="Color"> name of Color is stored here </param>
        /// <param name="ToolBox"> true/ false of variable is stored here </param>
        /// <param name="ComputerConnection"> true/ false of variable is stored here </param>
        /// <param name="Scanner"> true/ false of variable is stored here </param>
        /// <param name="Navigation"> true/ false of variable is stored here </param>
        /// <param name="NumberShips"> The number of ships is stored here </param>
        public AstromechDroid(
            string Model, 
            string Material, 
            string Color, 
            bool ToolBox, 
            bool ComputerConnection, 
            bool Scanner, 
            bool Navigation, 
            int NumberShips
        ) : base(Model, Material, Color, ToolBox, ComputerConnection, Scanner)
        {
            this._navigation = Navigation;
            this._numberShips = NumberShips;
        }

        public AstromechDroid() 
        { 
            // Do Nothing
        }
    }
}
