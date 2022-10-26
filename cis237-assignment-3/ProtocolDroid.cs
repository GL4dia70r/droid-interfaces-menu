using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    class ProtocolDroid : Droid
    {
        //
        protected const decimal COST_PER_LANGUAGE = 50m;

        //
        private int _numberLanguages;

        //
        public int NumberLanguages
        {
            get { return _numberLanguages; }
            set { _numberLanguages = value; }
        }

        //
        public override string ToString()
        {  
            return $"{base.ToString()} {NumberLanguages} {this.CalculateBaseCost().ToString("C")}";
        }

        public override void CalculateTotalCost()
        {
           this.TotalCost = base.CalculateBaseCost() + this.CalculateBaseCost();
        }

        protected virtual new decimal CalculateBaseCost()
        {
            if (NumberLanguages >= 1)
            {
                this.BaseCost = NumberLanguages * COST_PER_LANGUAGE;
            }
            else
            {
                this.BaseCost = 0;
            }
            return this.BaseCost;   
        }

        //
        public ProtocolDroid(
            string Model,
            string Material,
            string Color,
            int NumberLanguages
        ) : base(Model, Material, Color)
        {
            this._numberLanguages = NumberLanguages;
        }

        public ProtocolDroid()
        {
            // Do Nothing
        }
    }
}
