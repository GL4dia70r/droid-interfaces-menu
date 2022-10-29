// David Allen
// 10/17/22 - 10//22
// CIS237 - Assignment - 3
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Xml.Serialization;
using cis237_assignment_3;

namespace cis237_assignment_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // +--------------------------------------------------------------+
            // | Create a new droid collection and set the size of it to 100. |
            // +--------------------------------------------------------------+
            IDroidCollection droidCollection = new DroidCollection(100);

            // +-------------------------------------------------------------------------------+
            // | Create a user interface and pass the droidCollection into it as a dependency. |
            // +-------------------------------------------------------------------------------+
            JawaUserInterface uI = new JawaUserInterface(droidCollection);

            // +--------------------+
            // | Displays greeting. |
            // +--------------------+
            uI.WelcomeGreeting();

            // +-----------------------------+
            // | Displays main menu options. |
            // +-----------------------------+
            uI.MenuOptions();

            // +------------------------+
            // | Retrieves user choice. |
            // +------------------------+
            int choice = uI.GetMenuChoice();

            // +-------------------------------------------------------+
            // | While the choice is not equal to 3, continue program. |
            // +-------------------------------------------------------+
            while (choice != 3)
            {

                switch (choice)
                {
                    case 1:
                        uI.CreateDroid();
                        break;

                    case 2:
                        uI.PrintDroidList();
                        break;
                }

                // Re-display the menu and reprompt the user.
                uI.MenuOptions();
                choice = uI.GetMenuChoice();
            }
        }

    }

}
