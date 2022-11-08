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
        // +--------------------------------------------+
        // |  Constant for Droid Cost. Must be static   |
        // |  variable vs const, so it can be assigned  |
        // |  to in the constructor of derived classes. |
        // +--------------------------------------------+
        protected static decimal COST_OF_MODEL; 
        


        // +------------------------------------------+
        // | Some protected variables for this class. |
        // +------------------------------------------+
        protected string droidMaterial;  
        protected string droidColor;    
                                       
        protected decimal baseCost;  
        protected decimal totalCost;
        


        // +-------------------------------------------------------------------------------------+
        // | Create a inner class for the sole purpose of acting like a collection of constants. |
        // +-------------------------------------------------------------------------------------+
        public sealed class Material
        {
            private Material() { }
            public const string Carbon = "Carbonite";
            public const string Titanium = "Titanium";
            public const string Gold = "Gold";
            public const string Black_Steel = "Black Steel";
            public const string Trooper_Armor = "Blaster Practice";
        }

        // +-------------------------------------------------------------------------------------+
        // | Create a inner class for the sole purpose of acting like a collection of constants. |
        // +-------------------------------------------------------------------------------------+
        public sealed class Color
        {
            private Color() { }
            public const string Pearl_White = "Pearl White";
            public const string Jet_Black = "Jet Black";
            public const string Blue = "Blue";
            public const string Gold = "Gold";
            public const string Green = "Green";
            public const string Red = "Red";
            public const string Orange = "Orange";

        }

        // +------------------------------------------+
        // |    The public property for TotalCost     |
        // +------------------------------------------+
        public virtual decimal TotalCost
        {
            get { return this.totalCost; }
            set { totalCost = value; }
        }

        // +--------------------------------------------------------------------------------------------+
        // |    Overriden toString method that will return a string of basic information for any droid. |
        // +--------------------------------------------------------------------------------------------+
        public override string ToString()
        {
            return
                "Material: " + this.droidMaterial + 
                Environment.NewLine +
                   "Color: " + this.droidColor + 
                Environment.NewLine;
        }

        // +----------------------------------------------------------------------+
        // |    A method that will compare to other droid objects in each class.  |
        // +----------------------------------------------------------------------+
        public int CompareTo(Object obj)
        {
            Droid otherDroid = obj as Droid;

            if (otherDroid != null)
            {
                return this.TotalCost.CompareTo(otherDroid.TotalCost);
            }
            else
            {
                throw new ArgumentException("These are not the droids we are looking for...");
            }
        }

        // +----------------------------------------------------------------------------------------------+
        // |    Abstract method that MUST be overriden in the derived class to calculate the total cost.  |
        // +----------------------------------------------------------------------------------------------+
        public abstract void CalculateTotalCost();

        protected abstract string GetModelName();

        // +------------------------------------------------------------------------------------------+
        // |    A virtual method that can be overriden if needed, in derived classes.                 |
        // |------------------------------------------------------------------------------------------|    
        // |    A method that calculates the cost based on the material user for the select droid.    |
        // +------------------------------------------------------------------------------------------+
        protected virtual void CalculateBaseCost()
        {
            baseCost = this.GetMaterialCost() + this.GetColorCost();
        }

        // +---------------------------------------------------+
        // |    Method to get the cost of a certain material.  |
        // +---------------------------------------------------+
        protected decimal GetMaterialCost()
        {
            decimal materialCost;

            switch (this.droidMaterial)
            {
                case Material.Carbon:
                    materialCost = 50.00m;
                    break;
                case Material.Titanium:
                    materialCost = 150.00m;
                    break;
                case Material.Gold:
                    materialCost = 500.00m;
                    break;
                case Material.Black_Steel:
                    materialCost = 300.50m;
                    break;
                case Material.Trooper_Armor:
                    materialCost = 15.99m;
                    break;
                default:
                    materialCost = 75.50m;
                    break;
            }
            return materialCost;
        }

        // +---------------------------------------------------+
        // |    Method to get the cost of a certain color.     |
        // +---------------------------------------------------+
        protected decimal GetColorCost()
        {
            decimal colorCost;

            switch (this.droidColor)
            {
                case Color.Pearl_White:
                    colorCost = 150.00m;
                    break;
                case Color.Jet_Black:
                    colorCost = 200.00m;
                    break;
                case Color.Blue:
                    colorCost = 130.00m;
                    break;
                case Color.Gold:
                    colorCost = 300.50m;
                    break;
                case Color.Green:
                    colorCost = 150.80m;
                    break;
                case Color.Red:
                    colorCost = 174.99m;
                    break;
                case Color.Orange:
                    colorCost = 205.99m;
                    break;
                default:
                    colorCost = 115.95m;
                    break;
            }
            return colorCost;
        }

        // +---------------------------------------------------------------------------------------------------------------+
        // |    Constructor that stores the two main parameters and shares amongst all four instanceble types of a droid.  |
        // +---------------------------------------------------------------------------------------------------------------+
        public Droid(
            string Material,
            string Color
        )
        {
            this.droidMaterial = Material;
            this.droidColor = Color;
        }

        public Droid() 
        { 
            // Do Nothing
        }
    }
}
