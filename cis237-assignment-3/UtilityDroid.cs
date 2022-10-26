using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    class UtilityDroid : Droid
    {
        protected const decimal COST_PER_OPTION = 60m;

        //
        private bool _toolBox;
        private bool _computerConnection;
        private bool _scanner;

        //
        public bool ToolBox
        {
            get { return _toolBox; }
            set { _toolBox = value; }
        }

        public bool ComputerConnection
        {
            get { return _computerConnection; }
            set { _computerConnection = value; }
        }

        public bool Scanner
        {
            get { return _scanner; }
            set { _scanner = value; }
        }

        //
        public override string ToString()
        {
            return $"{base.ToString()} {ToolBox} {ComputerConnection} {Scanner} {this.CalculateBaseCost().ToString("C")}";
        }

        public override void CalculateTotalCost()
        {
            this.TotalCost = base.CalculateBaseCost() + this.CalculateBaseCost();
        }

        public virtual new decimal CalculateBaseCost()
        {
            if (ToolBox || ComputerConnection || Scanner)
            {
                this.BaseCost = 1m * COST_PER_OPTION;
            }
            else if (ToolBox && ComputerConnection || Scanner && ToolBox || ComputerConnection && Scanner)
            {
                this.BaseCost = 2m * COST_PER_OPTION;
            }
            else if (ToolBox && ComputerConnection && Scanner)
            {
                this.BaseCost = 3m * COST_PER_OPTION;
            }
            else
            {
                this.BaseCost = 0m * COST_PER_OPTION;
            }
            return this.BaseCost;
        }

        protected bool GetBoolCost(string field)
        {

        }

        /// <summary>
        ///             -   Constructor for Utility droids
        /// </summary>
        /// <param name="Material"></param>
        /// <param name="Color"></param>
        /// <param name="ToolBox"></param>
        /// <param name="ComputerConnection"></param>
        /// <param name="Scanner"></param>
        public UtilityDroid(
            string Model,
            string Material,
            string Color,
            bool ToolBox,
            bool ComputerConnection,
            bool Scanner
        ) : base(Model, Material, Color)

        {
            this._toolBox = ToolBox;
            this._computerConnection = ComputerConnection;
            this._scanner = Scanner;
        }

        public UtilityDroid()
        {
            // Do Nothing
        }
    }
}
