using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    internal class JanitorDroid : UtilityDroid
    {
        //
        private bool _trashCompactor;
        private bool _vacuum;
        
        //
        public bool TrashCompactor
        {
            get { return _trashCompactor; }
            set { _trashCompactor = value; }
        }

        public bool Vacuum
        {
            get { return _vacuum; }
            set { _vacuum = value; }
        }

        //
        public override string ToString()
        {
            return $"{base.ToString()} {TrashCompactor} {Vacuum}";
        }

        public override void CalculateTotalCost()
        {
            decimal OptionCost = 0;

            if (TrashCompactor || Vacuum)
            {
                OptionCost = 1;
            }
            else if (TrashCompactor && Vacuum)
            {
                OptionCost = 2;
            }
            else
            {
                OptionCost = 0;
            }

            this.TotalCost = base.CalculateBaseCost() + OptionCost * COST_PER_OPTION;
        }

        //
        public JanitorDroid(
            string Material,
            string Color,
            bool TrashCompactor, 
            bool Vacuum,
            bool ToolBox,
            bool ComputerConnection,
            bool Scanner
        ) : base(Material, Color, ToolBox, ComputerConnection, Scanner)
        {
            this._trashCompactor = TrashCompactor;
            this._vacuum = Vacuum;
        }
    }
}
