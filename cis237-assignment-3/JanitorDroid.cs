using System;
using System.Collections.Generic;
using System.Linq;
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
            this.TotalCost = base.CalculateBaseCost();
            if (!_vacuum)
            {
                this.TotalCost = 0;
            }
            else
            {
                this.TotalCost = 10m;
            }

            if (!_trashCompactor)
            {
                this.TotalCost = 0;
            }
            else
            {
                this.TotalCost = 15m;
            }
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
