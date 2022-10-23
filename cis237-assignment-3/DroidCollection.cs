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
        //private ProtocolDroid[] protocol;
        //private UtilityDroid[] utility;
        //private JanitorDroid[] janitor;
        //private AstromechDroid[] astromech;

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
            string Model,
            string Material,
            string Color,
            int NumberLanguages
        )
        {
            foreach (ProtocolDroid droid in droids)
            {
                if (droid.Model == Model)
                {
                    Model = droid.Model;

                    //
                    droids[droidsLength] = new ProtocolDroid(
                        Material,
                        Color,
                        NumberLanguages
                    );
                }
            }
            droidsLength++;
        }

        //
        public void AddNewUtilityDroid(
            string Model,
            string Material,
            string Color,
            bool ToolBox,
            bool ComputerConnection,
            bool Scanner
        )
        {
            foreach (UtilityDroid droid in droids)
            {
                if (droid.Model == Model)
                {
                    Model = droid.Model;

                    //
                    droids[droidsLength] = new UtilityDroid(
                        Material,
                        Color,
                        ToolBox,
                        ComputerConnection,
                        Scanner
                    );
                }
            }
            droidsLength++;
        }

        //
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
            foreach (JanitorDroid droid in droids)
            {
                if (droid.Model == Model)
                {
                    Model = droid.Model;

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
                }
            }
            droidsLength++;
        }

        //
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
            foreach (AstromechDroid droid in droids)
            {
                if (droid.Model == null)
                {
                    Model = droid.Model;

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
                }
            }
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
                if (model.Model != null)
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
                if (droids != null)
                {
                    if (
                        droid.Model[0] == model
                        || droid.Model[1] == model
                        || droid.Model[2] == model
                        || droid.Model[3] == model
                    )
                    {
                        outputString = droid.ToString();
                    }
                }
            }
            return outputString;
        }
    }
}
