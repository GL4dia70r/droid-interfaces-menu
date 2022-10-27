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
            JawaUserInterface ui = new JawaUserInterface();

            ProtocolDroid pD = new ProtocolDroid();

            UtilityDroid uD = new UtilityDroid();

            JanitorDroid jD = new JanitorDroid();

            AstromechDroid aD = new AstromechDroid();

            const int droidCollectionSize = 100;

            IDroid[] droids = new Droid[droidCollectionSize];

            DroidCollection droidCollection = new DroidCollection(droidCollectionSize);

            ui.WelcomeGreeting();

            
            int choice = ui.DisplayMenuAndGetUserInput();
            
            // While not choice 3, loop.
            while (choice != 3)
            {   // switches choice selection base on case options below
                switch (choice)
                {
                    case 1:
                        // Displays a Droid menu to choose which droid class you wish to store your droid into
                        int droidChoice = ui.DisplayDroidMenuAndGetUserInput();

                        while (droidChoice != 5)
                        {
                            switch (droidChoice)
                            {
                                case 1:
                                    // Displays add protocol droid menu and adds to Droid list

                                    if (droidChoice == 1)
                                    {
                                        string[] newDroidInformation = ui.GetNewProtocolDroidInformation();

                                            droidCollection.AddNewProtocolDroid(
                                                    newDroidInformation[0] = "Protocol",
                                                    newDroidInformation[1],
                                                    newDroidInformation[2],
                                                    int.Parse(newDroidInformation[3])

                                        );

                                        ui.DisplayAddDroidSuccess();
                                        
                                    }
                                    else
                                    {
                                        ui.DisplayAddDroidSuccessError();
                                    }
                                    pD.CalculateTotalCost();
                                    break;

                                case 2:
                                    // Displays add utility droid menu and adds to Droid list

                                    if (droidChoice == 2)
                                    {
                                        string[] newDroidInformation1 = ui.GetNewUtilityDroidInformation();

                                        droidCollection.AddNewUtilityDroid(
                                                newDroidInformation1[0] = "Utility",
                                                newDroidInformation1[1],
                                                newDroidInformation1[2],
                                                bool.Parse(newDroidInformation1[3]),
                                                bool.Parse(newDroidInformation1[4]),
                                                bool.Parse(newDroidInformation1[5])
                                        );

                                        ui.DisplayAddDroidSuccess();
                                        
                                    }
                                    else
                                    {
                                        ui.DisplayAddDroidSuccessError();
                                    }
                                    uD.CalculateTotalCost();
                                    break;

                                case 3:
                                    // Displays add janitor droid menu and adds to Droid list

                                    if (droidChoice == 3)
                                    {
                                        string[] newDroidInformation2 = ui.GetNewJanitorDroidInformation();

                                        
                                            droidCollection.AddNewJanitorDroid(
                                                       newDroidInformation2[0] = "Janitor",
                                                       newDroidInformation2[1],
                                                       newDroidInformation2[2],
                                                       bool.Parse(newDroidInformation2[3]),
                                                       bool.Parse(newDroidInformation2[4]),
                                                       bool.Parse(newDroidInformation2[5]),
                                                       bool.Parse(newDroidInformation2[6]),
                                                       bool.Parse(newDroidInformation2[7])
                                        );

                                        ui.DisplayAddDroidSuccess();
                                        
                                    }
                                    else
                                    {
                                        ui.DisplayAddDroidSuccessError();
                                    }
                                    jD.CalculateTotalCost();
                                    break;

                                case 4:
                                    // Displays add astromech droid menu and adds to Droid list
                                    if (droidChoice == 4)
                                    {
                                        string[] newDroidInformation3 = ui.GetNewAstromechDroidInformation();

                                        droidCollection.AddNewAstromechDroid(
                                                newDroidInformation3[0] = "Astromech",
                                                newDroidInformation3[1],
                                                newDroidInformation3[2],
                                                bool.Parse(newDroidInformation3[3]),
                                                bool.Parse(newDroidInformation3[4]),
                                                bool.Parse(newDroidInformation3[5]),
                                                bool.Parse(newDroidInformation3[6]),
                                                int.Parse(newDroidInformation3[7])
                                        );
                                        
                                     

                                        ui.DisplayAddDroidSuccess();
                                        
                                    }
                                    aD.CalculateTotalCost();
                                    break;
                            }
                            // recall Droid menu
                            droidChoice = ui.DisplayDroidMenuAndGetUserInput();
                        }
                        break;
                        
                        // Print List of droids
                    case 2:
                        string allDroidString = droidCollection.ToString();
                        if (!String.IsNullOrWhiteSpace(allDroidString))
                        {

                            ui.DisplayAllDroids(allDroidString);
                        }
                        else
                        {
                            ui.DisplayAllDroidsError();

                        }
                        break;
                }

                // recalls Main Menu 
                choice = ui.DisplayMenuAndGetUserInput();
            }    
        }

    }

}
