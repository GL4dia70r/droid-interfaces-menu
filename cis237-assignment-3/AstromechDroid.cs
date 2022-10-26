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
        //
        protected const decimal COST_PER_SHIP = 5000m;

        //
        private bool _navigation;
        private int _numberShips;

        //
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


        //
        public override string ToString()
        {
            return $"{base.ToString()} {Navigation} {NumberShips}";
        }
        
        public override void CalculateTotalCost()
        {
            this.TotalCost = base.CalculateBaseCost() + this.CalculateBaseCost();
        }

        protected virtual new decimal CalculateBaseCost()
        {
            this.BaseCost = this.GetBoolCost(ToolBox, COST_PER_OPTION) +
            this.GetBoolCost(ComputerConnection, COST_PER_OPTION) +
            this.GetBoolCost(Scanner, COST_PER_OPTION) +
            this.GetBoolCost(Navigation, COST_PER_OPTION);

            this.GetNumberedCosts(NumberShips, COST_PER_SHIP);

            return this.BaseCost;
        }

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
