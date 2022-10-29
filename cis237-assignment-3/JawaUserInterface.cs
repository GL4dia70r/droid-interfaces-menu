using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace cis237_assignment_3
{
    internal class JawaUserInterface
    {
        // +----------------------------------------------------------+
        // |  Create a class level variable for the droid collection. |
        // +----------------------------------------------------------+
        IDroidCollection droidCollection;


        // +----------------------------------------------------------+
        // | Constructor that will take in a droid Collection to use. |
        // +----------------------------------------------------------+
        public JawaUserInterface(IDroidCollection DroidCollection)
        {
            this.droidCollection = DroidCollection;
        }


        // +--------------------+
        // | Displays Greeting. |
        // +--------------------+
        public void WelcomeGreeting()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to the Droid System.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }


        // +-----------------------------+
        // | Displays main menu options. |
        // +-----------------------------+
        public void MenuOptions()
        {
            Console.WriteLine();
            Console.WriteLine("What is your entry? (Choose below)");
            Console.WriteLine();
            Console.WriteLine("1. Add a Droid to list.");
            Console.WriteLine("2. Print current Droid list.");
            Console.WriteLine("3. Exit.");
            Console.Write("|------> ");
        }


        // +--------------------------------------------+
        // | Displays main menu and gets user response. |
        // +--------------------------------------------+
        public int GetMenuChoice()
        {
            string choice = Console.ReadLine();

            // Set variable for the menu choice to 0. Try to parse the input, if successful, return the menu choice.
            int menuChoice = 0;

            try
            {
                menuChoice = Int32.Parse(choice);
            }
            catch (Exception e)
            {
                menuChoice = 0;
            }

            return menuChoice;
        }


        // +------------------------------------------------+
        // | Method to do the work of creating a new droid. |
        // +------------------------------------------------+
        public void CreateDroid()
        {
            // Prompt for color selection
            this.displayColorSelection();
            // Get the choice that the user makes
            int choice = this.GetMenuChoice();

            // If the choice is not valid, loop until it is valid, or the user cancels the operation
            while (choice < 1 || choice > 8)
            {
                // Prompt for a valid choice
                this.displayColorSelection();
                choice = this.GetMenuChoice();
            }

            // Check the choice against the possibilities
            // If there is one found, work on getting the next piece of information.
            switch (choice)
            {
                case 1:
                    this.chooseMaterial(Droid.Color.Pearl_White);
                    break;

                case 2:
                    this.chooseMaterial(Droid.Color.Jet_Black);
                    break;

                case 3:
                    this.chooseMaterial(Droid.Color.Blue);
                    break;

                case 4:
                    this.chooseMaterial(Droid.Color.Gold);
                    break;

                case 5:
                    this.chooseMaterial(Droid.Color.Green);
                    break;

                case 6:
                    this.chooseMaterial(Droid.Color.Red);
                    break;

                case 7:
                    this.chooseMaterial(Droid.Color.Orange);
                    break;
            }
        }


        // +-------------------------------------+
        // | Method to print out the droid list. |
        // +-------------------------------------+
        public void PrintDroidList()
        {
            Console.WriteLine();
            Console.WriteLine(this.droidCollection.GetPrintString());
        }


        // +------------------------------+
        // | Display the Model Selection. |
        // +------------------------------+
        private void displayModelSelection()
        {
            Console.WriteLine();
            Console.WriteLine("What type of droid is it?");
            Console.WriteLine("1. Protocol");
            Console.WriteLine("2. Utility");
            Console.WriteLine("3. Janitorial");
            Console.WriteLine("4. Astromech");
            Console.WriteLine("5. Cancel This Operation");
            Console.Write("|------> ");
        }


        // +----------------------------------------------------------+
        // | Display the Material Selection. |
        // +----------------------------------------------------------+
        // 
        private void displayMaterialSelection()
        {
            Console.WriteLine();
            Console.WriteLine("What material is the droid made out of?");
            Console.WriteLine("1. " + Droid.Material.Carbon);
            Console.WriteLine("2. " + Droid.Material.Titanium);
            Console.WriteLine("3. " + Droid.Material.Gold);
            Console.WriteLine("4. " + Droid.Material.Black_Steel);
            Console.WriteLine("5. " + Droid.Material.Trooper_Armor);
            Console.WriteLine("6. Cancel This Operation");
            Console.Write("|------> ");
        }


        // +----------------------------------------------------------+
        // | Display the Color Selection. |
        // +----------------------------------------------------------+
        // 
        private void displayColorSelection()
        {
            Console.WriteLine();
            Console.WriteLine("What color is the droid?");
            Console.WriteLine("1. " + Droid.Color.Pearl_White);
            Console.WriteLine("2. " + Droid.Color.Jet_Black);
            Console.WriteLine("3. " + Droid.Color.Blue);
            Console.WriteLine("4. " + Droid.Color.Gold);
            Console.WriteLine("5. " + Droid.Color.Green);
            Console.WriteLine("6. " + Droid.Color.Red);
            Console.WriteLine("7. " + Droid.Color.Orange);
            Console.WriteLine("8. Cancel This Operation");
            Console.Write("|------> ");
        }


        // +--------------------------------------------+
        // | Display the Number of Languages Selection. |
        // +--------------------------------------------+
        private void displayNumberOfLanguageSelection()
        {
            Console.WriteLine();
            Console.WriteLine("How many languages does the droid know?");
        }


        // +--------------------------------------+
        // | Display and get the utility options. |
        // +--------------------------------------+
        private bool[] displayAndGetUtilityOptions()
        {
            Console.WriteLine();
            bool option1 = this.displayAndGetOption("Does the droid have a toolbox?");
            Console.WriteLine();
            bool option2 = this.displayAndGetOption("Does the droid have a computer connection?");
            Console.WriteLine();
            bool option3 = this.displayAndGetOption("Does the droid have an scanner?");

            bool[] returnArray = { option1, option2, option3 };
            return returnArray;
        }


        // +-----------------------------------------+
        // | Display and get the Janatorial options. |
        // +-----------------------------------------+
        private bool[] displayAndGetJanatorialOptions()
        {
            Console.WriteLine();
            bool option1 = this.displayAndGetOption("Does the droid have a trash compactor?");
            Console.WriteLine();
            bool option2 = this.displayAndGetOption("Does the droid have a vaccum?");

            bool[] returnArray = { option1, option2 };
            return returnArray;
        }


        // +----------------------------------------+
        // | Display and get the astromech options. |
        // +----------------------------------------+
        private bool displayAndGetAstromechOption()
        {
            Console.WriteLine();
            return this.displayAndGetOption("Does the droid have a navigation system?");
        }


        // +--------------------------------------+
        // | Display and get the number of ships. |
        // +--------------------------------------+
        private int displayAndGetAstromechNumberOfShips()
        {
            Console.WriteLine();
            Console.WriteLine("How many ships has the droid worked on?");
            int choice = this.GetMenuChoice();

            while (choice <= 0)
            {
                Console.WriteLine("Not a valid number of ships");
                Console.WriteLine("How many ships as the droid worked on?");
                choice = this.GetMenuChoice();
            }
            return choice;
        }


        // +----------------------------------------------------------+
        // | Method to display and get a general option, it ensures   |
        // | that Y or N is the typed response.                       |
        // +----------------------------------------------------------+
        private bool displayAndGetOption(string optionString)
        {
            Console.WriteLine(optionString + " (y/n)");
            Console.Write("|------> ");

            string choice = Console.ReadLine();
            while (choice.ToUpper() != "Y" && choice.ToUpper() != "N")
            {
                Console.WriteLine(optionString);
                Console.Write("|------> ");

                choice = Console.ReadLine();
            }
            if (choice.ToUpper() == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // +---------------------------------------------------------------------------------+
        // | Method to choose the Material for the droid. It accepts Color as the parameter. |
        // +---------------------------------------------------------------------------------+
        private void chooseMaterial(string Color)
        {
            // Display the material selection
            this.displayMaterialSelection();
            // Get the users choice
            int choice = this.GetMenuChoice();

            // While the chioce is not valid, wait until there is a valid one
            while (choice < 0 || choice > 6)
            {
                this.displayMaterialSelection();
                choice = this.GetMenuChoice();
            }

            // Check to see which choice was chosen. Call choose model and pass the color an material over
            // to the method to get the model
            switch (choice)
            {
                case 1:
                    this.chooseModel(Color, Droid.Material.Carbon);
                    break;

                case 2:
                    this.chooseModel(Color, Droid.Material.Titanium);
                    break;

                case 3:
                    this.chooseModel(Color, Droid.Material.Gold);
                    break;

                case 4:
                    this.chooseModel(Color, Droid.Material.Black_Steel);
                    break;

                case 5:
                    this.chooseModel(Color, Droid.Material.Trooper_Armor);
                    break;

            }
        }


        // +---------------------------------------------------------------------------------------------+
        // | Method to choose a model and decide what other input is needed based on the selected model. |
        // +---------------------------------------------------------------------------------------------+
        private void chooseModel(
            string Color,
            string Material
        )
        {
            // Display the menu to choose which model
            this.displayModelSelection();
            // Get the model choice
            int choice = this.GetMenuChoice();

            // While the choice is not valid, keep prompting for a choice
            while (choice < 0 || choice > 5)
            {
                // Display the menu again, and ask for the option again.
                this.displayModelSelection();
                choice = this.GetMenuChoice();
            }

            // Based on the choice, call the next set of crieteria that needs to be determined
            switch (choice)
            {
                case 1:
                    this.chooseNumberOfLanguages(
                        Color,
                        Material,
                        "Protocol"
                        );
                    break;

                case 2:
                    this.chooseOptions(
                        Color,
                        Material,
                        "Utility"
                        );
                    break;

                case 3:
                    this.chooseOptions(
                        Color,
                        Material,
                        "Janatorial"
                        );
                    break;

                case 4:
                    this.chooseOptions(
                        Color,
                        Material,
                        "Astromech"
                        );
                    break;
            }
        }


        // +--------------------------------------------------------------+
        // | Method to choose the number of langages that a droid knows.  |
        // | It accepts the values that were determined in the past       |
        // | methods. This method will also add a droid based on the      |
        // | collected information.                                       |
        // +--------------------------------------------------------------+
        private void chooseNumberOfLanguages(
            string Color,
            string Material,
            string Model
        )
        {
            // Display the number of languages selection
            this.displayNumberOfLanguageSelection();
            // Get the users choice
            int choice = this.GetMenuChoice();

            // While the choice is not valid, keep prompting for a valid one.
            while (choice < 0)
            {
                Console.WriteLine("Not a valid number of languages");
                this.displayNumberOfLanguageSelection();
                choice = this.GetMenuChoice();
            }

            // The only droid that we can add with this criteria is a protocol droid, so add it to the droid collection
            this.droidCollection.AddNewProtocolDroid(
                Material,
                Color,
                choice
            );

        }


        // +----------------------------------------------------------+
        // | Method to figure out which of the utility droids the     |
        // | user is creating, and then work on collecting the rest   |
        // | of the needed information to create the droid.           |
        // +----------------------------------------------------------+
        private void chooseOptions(
            string Color,
            string Material,
            string Model
        )
        {
            // Display and get the utility options.
            bool[] standardOptions = this.displayAndGetUtilityOptions();

            // Based on the model chosen, figure out the remaining information needed.
            switch (Model)
            {
                // If it is a utility
                case "Utility":
                    this.droidCollection.AddNewUtilityDroid(
                        Material,
                        Color,
                        standardOptions[0],
                        standardOptions[1],
                        standardOptions[2]
                        );
                    break;

                // If it is a Janatorial
                case "Janatorial":
                    // Get the rest of the options for a Janatorial droid.
                    bool[] janatorialOptions = this.displayAndGetJanatorialOptions();
                    // Add it to the collection
                    this.droidCollection.AddNewJanitorDroid(
                        Material,
                        Color,
                        standardOptions[0],
                        standardOptions[1],
                        standardOptions[2],
                        janatorialOptions[0],
                        janatorialOptions[1]
                        );
                    break;

                // If it is a Astromech
                case "Astromech":
                    // Get the rest of the options for an astromech
                    bool astromechOption = this.displayAndGetAstromechOption();
                    int astromechNumberOfShips = this.displayAndGetAstromechNumberOfShips();
                    // Add it to the collection
                    this.droidCollection.AddNewAstromechDroid(
                        Material,
                        Color,
                        standardOptions[0],
                        standardOptions[1],
                        standardOptions[2],
                        astromechOption,
                        astromechNumberOfShips
                        );
                    break;
            }

        }
    }
}
