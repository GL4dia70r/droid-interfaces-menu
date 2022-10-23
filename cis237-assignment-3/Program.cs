// David Allen
// 10/17/22 - 10//22
// CIS237 - Assignment - 3
using System;
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

            const int droidCollectionSize = 100;
            
            IDroid[] model = new Droid[droidCollectionSize];
            ProtocolDroid[] protocol = new ProtocolDroid[droidCollectionSize];
            UtilityDroid[] utility = new UtilityDroid[droidCollectionSize];
            JanitorDroid[] janitors = new JanitorDroid[droidCollectionSize];


            DroidCollection droidCollection = new DroidCollection(droidCollectionSize);

            ui.WelcomeGreeting();

            int choice = ui.DisplayMenuAndGetUserInput();

            while (choice != 5)
            {
                switch (choice)
                {
                    case 1:

                        int droidChoice = ui.DisplayDroidMenuAndGetUserInput();

                        while (droidChoice != 6)
                        {
                            switch (droidChoice)
                            {
                                case 1:
                                    string[] newDroidInformation = ui.GetNewProtocolDroidInformation();
                                    if (droidCollection.FindDroid(newDroidInformation[0]) == null)
                                    {
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
                                        ui.DisplayDroidAlreadyExistsError();
                                    }
                                    break;

                                case 2:
                                    string[] newDroidInformation1 = ui.GetNewUtilityDroidInformation();
                                    if (droidCollection.FindDroid(newDroidInformation1[0]) == null)
                                    {
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
                                        ui.DisplayDroidAlreadyExistsError();
                                    }
                                    break;

                                case 3:
                                    string[] newDroidInformation2 = ui.GetNewJanitorDroidInformation();
                                    if (droidCollection.FindDroid(newDroidInformation2[0]) == null)
                                    {
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
                                        ui.DisplayDroidAlreadyExistsError();
                                    }
                                    break;

                                case 4:
                                    string[] newDroidInformation3 = ui.GetNewAstromechDroidInformation();
                                    if (droidCollection.FindDroid(newDroidInformation3[0]) == null)
                                    {
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
                                    else
                                    {
                                        ui.DisplayDroidAlreadyExistsError();
                                    }
                                    break;

                            }
                        }
                        break;

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
            }    
        }
    }
}
