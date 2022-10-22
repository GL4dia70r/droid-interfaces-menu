// David Allen
// 10/17/22 - 10//22
// CIS237 - Assignment - 3
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //
        public void AddNewProtocolDroid(
            string Material,
            string Color
        )
        {
            //
            droids[droidsLength] = new ProtocolDroid(
                Material, 
                Color, 
                NumberLanguages
            );

            droidsLength++;
        }

        //
        public void AddNewUtilityDroid(
            string Material,
            string Color,
            bool ToolBox,
            bool ComputerConnection,
            bool Scanner
        )
        {
            //
            droids[droidsLength] = new UtilityDroid(
                Material, 
                Color, 
                ToolBox, 
                ComputerConnection, 
                Scanner
            );


            droidsLength++;
        }

        //
        public void AddNewJanitorDroid(
            string Material,
            string Color,
            bool TrashCompactor,
            bool Vacuum,
            bool ToolBox,
            bool ComputerConnection,
            bool Scanner
        )
        {
            //
            droids[droidsLength] = new JanitorDroid(
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

        //
        public void AddNewAstromechDroid(
            string Material,
            string Color,
            bool ToolBox,
            bool ComputerConnection,
            bool Scanner,
            bool Navigation,
            int NumberShips
        )
        {
            //
            droids[droidsLength] = new AstromechDroid(
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

        //
        public override string ToString()
        {
            //
            string userReturnString = "";
            //
            foreach (Droid model in droids)
            {
                //
                if (model != null)
                {
                    userReturnString += model.ToString() +
                        Environment.NewLine;
                }
            }
            //
            return userReturnString;
        }

        public string FindDroid(string model)
        {
            string outputString = null;
            
            foreach (Droid droid in droids)
            {
                if (droid != null)
                {
                    if (droid.Model == model)
                    outputString = droid.ToString();
                }
            }
        }
    }
}
