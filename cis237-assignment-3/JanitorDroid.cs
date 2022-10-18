using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    internal class JanitorDroid : UtilityDroid
    {
        private bool _trashCompactor;
        private bool _vacuum;
        
        public void CalculateTotalCost()
        {
            base.TotalCost = 
        }
        
        public JanitorDroid(
            string Material,
            string Color,
            bool TrashCompactor, 
            bool Vacuum,
            bool ToolBox,
            bool ComputerConnection,
            bool Scanner
        ) : base(Material, Color, ToolBox, ComputerConnection, Scanner)
        {
            this._trashCompactor = TrashCompactor;
            this._vacuum = Vacuum;
        }
    }
}
