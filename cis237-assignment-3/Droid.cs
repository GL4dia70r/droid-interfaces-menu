// David Allen
// 10/17/22 - 10//22
// CIS237 - Assignment - 3
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace cis237_assignment_3
{
    abstract class Droid : IDroid
    {
        /// <summary>
        ///             -  Varialbes to store the material, color, and total cost of Droids.
        /// </summary>
        protected const decimal COST_PER_MATERIAL = 500m;
        protected const decimal COST_PER_COLOR = 10m;

        private string _droidModel;
        private string _droidMaterial;
        private string _droidColor;
        private decimal _baseCost;
        private decimal _totalCost;

        /// <summary>
        ///             - Properties
        /// </summary>
        public string Model
        {
            get { return _droidModel; }
            set { _droidModel = value; }
        }

        public string Material
        {
            get { return _droidMaterial; }
            set { _droidMaterial = value; }
        }

        public string Color
        {
            get { return _droidColor; }
            set { _droidColor = value; }
        }

        public decimal BaseCost
        {
            get { return _baseCost; }
            set { _baseCost = value; }
        }

        public virtual decimal TotalCost
        {
            get { return this._totalCost; }
            set { _totalCost = value; }
        }

        /// <summary>
        ///            - Methods
        /// </summary>
        /// <returns> ToString() and CalculateBaseCost()/ CalculateTotalCost() </returns>
        public override string ToString()
        {
            return $"{Model,-12} {Material, -12} {Color, -10} {this.CalculateBaseCost().ToString("C"), -10}";
        }

        // Can't get to print
        public virtual void CalculateTotalCost()
        {
            this.TotalCost = this.CalculateBaseCost();
        }

        // gets Base cost of class.
        protected decimal CalculateBaseCost()
        {
            this.BaseCost = GetStringCosts(Material, COST_PER_MATERIAL) +
            GetStringCosts(Color, COST_PER_COLOR);

            return this.BaseCost;
        }

        // gets the bool of field and multiplies the value by 1 or 0.
        protected decimal GetBoolCost(bool field, decimal value)
        {
            if (field == true)
            {
                this.BaseCost = 1 * value;
            }
            else if (field == false)
            {
                this.BaseCost = 0 * value;

            }
            return this.BaseCost;
        }

        // Gets cost for Material and Color
        protected decimal GetStringCosts(string field, decimal value2)
        {
            if (field != null)
            {
                this.BaseCost = 1 * value2;
            }
            else if (field == null)
            {
                this.BaseCost = 0 * value2;
            }
            return this.BaseCost;
        }

        // Gets cost of parameters that return an int value and decimal value
        protected decimal GetNumberedCosts(int value, decimal value2)
        {
            if (value >= 1)
            {
                this.BaseCost = value * value2;
            }
            else if (value == 0)
            {
                this.BaseCost = 0 * value2;
            }
            return this.BaseCost;
        }

        /// <summary>
        ///             -  Droid Constructor with two parameters both string.
        /// </summary>
        /// <param name="Material">- variable that holds the Droid material. </param>
        /// <param name="Color">- varialbe that holds the Droid color. </param>
        public Droid(
            string Model,
            string Material,
            string Color
        )
        {
            this._droidModel = Model;
            this._droidMaterial = Material;
            this._droidColor = Color;
        }

        public Droid() 
        { 
            // Do Nothing
        }
    }
}
