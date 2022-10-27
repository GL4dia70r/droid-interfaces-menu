using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    class UtilityDroid : Droid
    {
        protected const decimal COST_PER_OPTION = 6m;

        //
        private bool _toolBox;
        private bool _computerConnection;
        private bool _scanner;



        /// <summary>
        ///             - Properties
        /// </summary>
        public new string Model { get; set; }

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

        /// <summary>
        ///            - Methods
        /// </summary>
        /// <returns> ToString() and CalculateBaseCost()/ CalculateTotalCost() </returns>
        public override string ToString()
        {
            return $"{base.ToString()} {ToolBox, 18} {ComputerConnection,12} {Scanner, 12} {this.CalculateBaseCost().ToString("C"), 12}";
        }

        // Have not been able to get to work, stores base cost and this base cost into TotalCost
        public override void CalculateTotalCost()
        {
            this.TotalCost = base.CalculateBaseCost() + this.CalculateBaseCost();
            return;
        }

        // gets the value for base total cost.
        public virtual new decimal CalculateBaseCost()
        {
            this.BaseCost = base.CalculateBaseCost() + 
                this.GetBoolCost(ToolBox, COST_PER_OPTION) + 
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
