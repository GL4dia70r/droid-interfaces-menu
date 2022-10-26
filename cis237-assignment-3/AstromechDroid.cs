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
            if (Navigation)
            {
                this.BaseCost = 1m * COST_PER_OPTION;
            }
            else
            {
                this.BaseCost = 0m * COST_PER_OPTION;
            }

            if (NumberShips >= 1)
            {
                this.NumberShips = (int)(NumberShips * COST_PER_SHIP);
            }
            else
            {
                this.NumberShips = (int)(0m * COST_PER_OPTION);
            }
            return this.BaseCost + this.NumberShips;
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
