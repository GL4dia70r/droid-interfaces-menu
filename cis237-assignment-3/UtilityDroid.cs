using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    class UtilityDroid : Droid
    {
        private bool toolBox;
        private bool computerConnection;
        private bool scanner;

        public override string ToString()
        {
            return $"{base.ToString()} {toolBox} {computerConnection} {scanner}";
        }

        public override void CalculateTotalCost()
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
            string Material,
            string Color,
            bool ToolBox,
            bool ComputerConnection,
            bool Scanner
        ) : base(Material, Color)
        {
            this.toolBox = ToolBox;
            this.computerConnection = ComputerConnection;
            this.scanner = Scanner;
        }

        public UtilityDroid()
        {
            // Do Nothing
        }
    }
}
