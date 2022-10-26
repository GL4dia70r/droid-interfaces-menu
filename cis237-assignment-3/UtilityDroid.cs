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

        public new decimal BaseCost { get; set; }

        public new decimal TotalCost { get; set; }

        //
        public override string ToString()
        {
            return $"{base.ToString()} {ToolBox} {ComputerConnection} {Scanner}";
        }

        public override void CalculateTotalCost()
        {
            this.TotalCost = base.CalculateBaseCost() + this.CalculateBaseCost();
        }

        public virtual new decimal CalculateBaseCost()
        {
            BaseCost = this.GetBoolCost(ToolBox, COST_PER_OPTION) + 
                this.GetBoolCost(ComputerConnection, COST_PER_OPTION) + 
                this.GetBoolCost(Scanner, COST_PER_OPTION);
            return this.BaseCost;
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
            bool Scanner,
            decimal BaseCost,
            decimal TotalCost
        ) : base(Model, Material, Color, BaseCost, TotalCost )

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
