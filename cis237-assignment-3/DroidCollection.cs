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
        public void AddNewDroid(
            string Material,
            string Color
        )
        {
            base.Material = Material;
            base.Color = Color;

            //
            droids[droidsLength] = new Droid(Material, Color);
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
    }
}
