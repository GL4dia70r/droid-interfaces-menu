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
            set { this._totalCost = value; }
        }
        /// <summary>
        ///             -  Methods for droid properties.
        /// </summary>
        /// <returns>ToString of variables Material and Color</returns>
        public override string ToString()
        {
            return $"{Model} {Material} {Color, 12} {TotalCost.ToString("C")}";
        }

        public virtual void CalculateTotalCost()
        {
            this.TotalCost = this.CalculateBaseCost();
        }

        protected decimal CalculateBaseCost()
        {
            if (Material != null && Color != null)
            {
                this.BaseCost = COST_PER_MATERIAL * 1 + COST_PER_COLOR * 1;
            }
            else
            {
                this.BaseCost = 0;
            }
            return this.BaseCost;
        }

        //
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

        //
        protected decimal GetNumberedCosts(int value, decimal value2)
        {
            if (value >= 1)
            {
                this.BaseCost = value * value2;
            }
            else if (value == 0)
            {
                this.BaseCost = value * value2;
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
            string Color,
            decimal BaseCost,
            decimal TotalCost
        )
        {
            this._droidModel = Model;
            this._droidMaterial = Material;
            this._droidColor = Color;
            this._baseCost = BaseCost;
            this._totalCost = TotalCost;
        }

        public Droid() 
        { 
            // Do Nothing
        }
    }
}
