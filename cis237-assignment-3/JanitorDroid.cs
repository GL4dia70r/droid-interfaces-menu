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

        public new string Model { get; set; }

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

        public new decimal BaseCost { get; set; }

        public new decimal TotalCost { get; set; }

        //
        public override string ToString()
        {
            return $"{base.ToString()} {TrashCompactor} {Vacuum}";
        }

        public virtual new void CalculateTotalCost()
        {
            this.TotalCost = base.CalculateBaseCost() + this.CalculateBaseCost();
        }

        public virtual new decimal CalculateBaseCost()
        {
           BaseCost =  this.GetBoolCost(ToolBox, COST_PER_OPTION) +
            this.GetBoolCost(ComputerConnection, COST_PER_OPTION) + 
            this.GetBoolCost(Scanner, COST_PER_OPTION) +
            this.GetBoolCost(TrashCompactor, COST_PER_OPTION) +
            this.GetBoolCost(Vacuum, COST_PER_OPTION);

            return this.BaseCost;
        }

        //
        public JanitorDroid(
            string Model,
            string Material, 
            string Color, 
            bool TrashCompactor, 
            bool Vacuum, 
            bool ToolBox, 
            bool ComputerConnection, 
            bool Scanner
        ) : base(Model, Material, Color, ToolBox, ComputerConnection, Scanner)
        {
            this._trashCompactor = TrashCompactor;
            this._vacuum = Vacuum;
        }

        public JanitorDroid()
        {
            // Do Nothing
        }
    }
}
