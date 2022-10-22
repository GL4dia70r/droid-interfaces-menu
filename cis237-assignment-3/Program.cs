// David Allen
// 10/17/22 - 10//22
// CIS237 - Assignment - 3
using System;

namespace cis237_assignment_3
{
    class Program
    {
        static void Main(string[] args)
        {
            JawaUserInterface ui = new JawaUserInterface();

            const int droidCollectionSize = 1000;

            Droid[] model = new Droid[4];

            Droid[] protocolDroid = new ProtocolDroid[100];

            Droid[] utilityDroid = new UtilityDroid[100];

            UtilityDroid[] janitorDroid = new JanitorDroid[100];

            UtilityDroid[] AstromechDroid = new AstromechDroid[100];

            DroidCollection droidCollection = new DroidCollection(droidCollectionSize);
        }
    }
}
