// David Allen
// 10/17/22 - 10//22
// CIS237 - Assignment - 3
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    abstract class Droid : IDroid
    {
        /// <summary>
        ///             - Constant Variable for average droid quantity.
        /// </summary>
        protected const int droidQuantity = 100;
        protected const int droidType = 25000;

        /// <summary>
        ///             -  Varialbes to store the material, color, and total cost of Droids.
        /// </summary>
        private string droidMaterial;
        private string droidColor;
        private decimal totalCost = numberOfLanguages * droidType;

        public string Material
        {
            get { return droidMaterial; }
            set { droidMaterial = value; }
        }

        public string Color
        {
            get { return droidColor; }
            set { droidColor = value; }
        }

        public decimal TotalCost 
        { 
            get 
            { 
                return this.totalCost; 
            } 
            set
            {
                this.totalCost = value;
            }
        }

        /// <summary>
        ///             -  Methods for droid properties.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Material} {Color}";
        }

        public virtual void CalculateTotalCost()
        {
            this.totalCost = TotalCost;
        }

        /// <summary>
        ///             -  Droid Constructor with two parameters both string.
        /// </summary>
        /// <param name="Material">- variable that holds the Droid material. </param>
        /// <param name="Color">- varialbe that holds the Droid color. </param>
        public Droid(
            string Material,
            string Color
        )
        {
            this.droidMaterial = Material;
            this.droidColor = Color;
        }

        public Droid() { }
    }
}
