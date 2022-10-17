using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    class Protocol : Droid
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
            return $"{numberLanguages} {costPerLanguage}";
        }

        public override void CalculateTotalCost()
        {
            this.TotalCost = NumberLanguages * droidType;
        }

        public Protocol(
            string Material,
            string Color,
            int NumberLanguages
        ) : base(Material, Color)
        {
            this.numberLanguages = NumberLanguages;
        }
    }
}
