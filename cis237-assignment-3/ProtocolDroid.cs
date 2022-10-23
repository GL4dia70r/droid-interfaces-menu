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

        public new string Model
        {
            get 
            { 
                return droidName[0]; 
            }
        }

        //
        public override string ToString()
        {
                
            return $"{base.ToString()}" + 
                Environment.NewLine + 
                $"{NumberLanguages}";
        }

        public override void CalculateTotalCost()
        {
            this.TotalCost = base.CalculateBaseCost() + NumberLanguages * COST_PER_LANGUAGE;
        }

        //
        public ProtocolDroid(
            string Material,
            string Color,
            int NumberLanguages
        ) : base(Material, Color)
        {
            this._numberLanguages = NumberLanguages;
        }

        public ProtocolDroid()
        {
            // Do Nothing
        }
    }
}
