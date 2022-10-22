using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    class UtilityDroid : Droid
    {
        UtilityDroid[] janitorDroid = new JanitorDroid[100];
        UtilityDroid[] astromechDroid = new AstromechDroid[100];

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
            return $"{base.ToString()} {ToolBox} {ComputerConnection} {Scanner}";
        }

        public override void CalculateTotalCost()
        {
            decimal OptionCost = 0;

            if (ToolBox || ComputerConnection || Scanner)
            {
                OptionCost = 1;
            }
            else if (ToolBox && ComputerConnection || ToolBox && Scanner || ComputerConnection && Scanner)
            {
                OptionCost = 2;
            }
            else if (ToolBox && ComputerConnection && Scanner)
            {
                OptionCost = 3;
            }
            else
            {
                OptionCost = 0;
            }

            this.TotalCost = base.CalculateBaseCost() + OptionCost * COST_PER_OPTION;
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
            string Material,
            string Color,
            bool ToolBox,
            bool ComputerConnection,
            bool Scanner
        ) : base(Material, Color)
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
