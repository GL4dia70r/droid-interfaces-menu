using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    class ProtocolDroid : Droid
    {
        private int numberLanguages;

        const decimal costPerLanguage = 50m;

        public int NumberLanguages
        {
            get { return numberLanguages; }
            set { numberLanguages = value; }
        }

        public override string ToString()
        {
            return $"{base.ToString()} {numberLanguages.ToString()}";
        }

        public override void CalculateTotalCost()
        {
            this.TotalCost = NumberLanguages * costPerLanguage;
            base.TotalCost = this.TotalCost;
        }

        public ProtocolDroid(
            string Material,
            string Color,
            int NumberLanguages
        ) : base(Material, Color)
        {
            this.numberLanguages = NumberLanguages;
        }

        public ProtocolDroid()
        {
            // Do Nothing
        }
    }
}
