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
        // bool variables
        private bool _trashCompactor;
        private bool _vacuum;


        /// <summary>
        ///            - Properties
        /// </summary>
        public new string Model { get; set; }

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

        /// <summary>
        ///            - Methods
        /// </summary>
        /// <returns> ToString() and CalculateBaseCost()/ CalculateTotalCost() </returns>
        public override string ToString()
        {
            return $"{base.ToString()} {TrashCompactor, 8} {Vacuum, 18}" + $"{ this.CalculateBaseCost().ToString("C"), 38}";
        }

        // Have not been able to get to work, stores base cost and this base cost into TotalCost
        public virtual new void CalculateTotalCost()
        {
            this.TotalCost = base.CalculateBaseCost() + this.CalculateBaseCost();
            return;
        }

        // gets the value for base total cost.
        public virtual new decimal CalculateBaseCost()
        {
           this.BaseCost = base.CalculateBaseCost() +
            this.GetBoolCost(TrashCompactor, COST_PER_OPTION) +
            this.GetBoolCost(Vacuum, COST_PER_OPTION);

            return this.BaseCost;
        }

        /// <summary>
        ///            - Constructors
        /// </summary>
        /// <param name="Model"></param>
        /// <param name="Material"></param>
        /// <param name="Color"></param>
        /// <param name="TrashCompactor"></param>
        /// <param name="Vacuum"></param>
        /// <param name="ToolBox"></param>
        /// <param name="ComputerConnection"></param>
        /// <param name="Scanner"></param>
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
