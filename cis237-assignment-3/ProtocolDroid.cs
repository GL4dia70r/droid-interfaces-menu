using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    class ProtocolDroid : Droid
    {
        // constant variable for language cost
        protected const decimal COST_PER_LANGUAGE = 5m;

        // variable to hold number of languages
        private int _numberLanguages;


        /// <summary>
        ///             - Properties
        /// </summary>
        public new string Model { get; set; }

        public int NumberLanguages
        {
            get { return _numberLanguages; }
            set { _numberLanguages = value; }
        }

        public new decimal BaseCost { get; set; }

        public new decimal TotalCost { get; set; }

        /// <summary>
        ///            - Methods
        /// </summary>
        /// <returns> ToString() and CalculateBaseCost()/ CalculateTotalCost() </returns>
        public override string ToString()
        {  
            return $"{base.ToString()} {NumberLanguages, -9} {this.CalculateBaseCost().ToString("C"), 115}";
        }

        // Have not been able to get to work, stores base cost and this base cost into TotalCost
        public override void CalculateTotalCost()
        {
           this.TotalCost = base.CalculateBaseCost() + this.CalculateBaseCost();
            return;
        }

        // gets the value for base total cost.
        public virtual new decimal CalculateBaseCost()
        {
            this.BaseCost = base.CalculateBaseCost() + this.GetNumberedCosts(NumberLanguages, COST_PER_LANGUAGE);

            return this.BaseCost;   
        }


        /// <summary>
        ///             - Constructor
        /// </summary>
        /// <param name="Model"> name of class is stored here </param>
        /// <param name="Material"> name of material is stored here </param>
        /// <param name="Color"> name of Color is stored here </param>
        /// <param name="NumberLanguages"> number of languages is stored here </param>
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
