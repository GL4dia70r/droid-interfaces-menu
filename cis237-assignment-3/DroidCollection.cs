// David Allen
// 10/17/22 - 10//22
// CIS237 - Assignment - 3
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace cis237_assignment_3
{
    class DroidCollection : ProtocolDroid
    {
        //
        private Droid[] droids;

        private int droidsLength;
        
        //
        public DroidCollection(int size)
        {
            this.droids = new Droid[size];
            this.droidsLength = 0;
        }

        public DroidCollection() { }

        // Adds new droid
        public void AddNewProtocolDroid(
            string Model,
            string Material,
            string Color,
            int NumberLanguages
        )
        {
            // adds Protocol Droid
            droids[droidsLength] = new ProtocolDroid(
                Model,
                Material,
                Color,
                NumberLanguages
            );


            droidsLength++;
        }

        // Adds new droid
        public void AddNewUtilityDroid(
            string Model,
            string Material,
            string Color,
            bool ToolBox,
            bool ComputerConnection,
            bool Scanner
        )
        {
            // adds Utility Droid
            droids[droidsLength] = new UtilityDroid(
                Model,
                Material,
                Color,
                ToolBox,
                ComputerConnection,
                Scanner
            );

            droidsLength++;
        }

        // Adds new droid
        public void AddNewJanitorDroid(
            string Model,
            string Material,
            string Color,
            bool TrashCompactor,
            bool Vacuum,
            bool ToolBox,
            bool ComputerConnection,
            bool Scanner
        )
        {
            // Adds Janitor Droid
            droids[droidsLength] = new JanitorDroid(
                Model,
                Material,
                Color,
                TrashCompactor,
                Vacuum,
                ToolBox,
                ComputerConnection,
                Scanner
            );

            droidsLength++;
        }

        // Adds new droid
        public void AddNewAstromechDroid(
            string Model,
            string Material,
            string Color,
            bool ToolBox,
            bool ComputerConnection,
            bool Scanner,
            bool Navigation,
            int NumberShips
        )
        {
            // gets new Astromech droid information
            droids[droidsLength] = new AstromechDroid(
                Model,
                Material,
                Color,
                ToolBox,
                ComputerConnection,
                Scanner,
                Navigation,
                NumberShips
            );

            droidsLength++;
        }

        // returns array into a String
        public override string ToString()
        {
            // null string
            string userReturnString = "";

            // for each Droid model in the array
            foreach (Droid model in droids)
            {
                // if model != null
                if (model != null)
                {
                    userReturnString += model.ToString() +
                        Environment.NewLine;
                }
            }
            //
            return userReturnString;
        }

        //public string FindDroid(string model)
        //{
        //    string outputString = null;
            
        //    foreach (Droid droid in droids)
        //    {
        //        if (droids.Model != null)
        //        {
        //            if (droid.Model[0] != model)
        //            {
        //                outputString = droid.ToString();
        //            }
        //            else if (droid.Model[1] != model)
        //            {
        //                outputString = droid.ToString();
        //            }
        //            else if (droid.Model[2] != model)
        //            {
        //                outputString = droid.ToString();
        //            }
        //            else if (droid.Model[3] != model)
        //            {
        //                outputString = droid.ToString();
        //            }
        //        }
        //    }
        //    return outputString;
        //}
    }
}
