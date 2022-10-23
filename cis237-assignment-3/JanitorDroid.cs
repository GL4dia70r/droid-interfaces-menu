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

        public new string Model
        {
            get { return droidName[2]; }
            set { droidName[2] = value; }
        }

        //
        public override string ToString()
        {
            return $"{base.ToString()}" +
                Environment.NewLine + 
                $"{TrashCompactor}" +
                Environment.NewLine + 
                $"{Vacuum}";
        }

        public override void CalculateTotalCost()
        {
            this.TotalCost = base.CalculateBaseCost() + this.CalculateOptionCost();
        }

        protected new decimal CalculateOptionCost()
        {
            decimal OptionCost = 0m;

            bool[] options = { 
                TrashCompactor, 
                Vacuum 
            };

            if (
                options[0] 
                || 
                options[1]
            )
            {
                OptionCost = 1m;
            }
            else if (
                options[0] 
                && options[1]
            )
            {
                OptionCost = 2m;
            }
            else
            {
                OptionCost = 0m;
            }
            return OptionCost * COST_PER_OPTION;
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
