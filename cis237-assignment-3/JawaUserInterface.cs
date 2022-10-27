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
        // constant variables to hold integers as a counter.
        const int MAX_MENU_CHOICES = 3;
        const int MAX_DROIDMENU_CHOICES = 5;
        const int MAX_MATERIALMENU_CHOICES = 6;
        const int MAX_COLORMENU_CHOICES = 9;

        // Displays Greeting
        public void WelcomeGreeting()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome, to the Droid Upload System Program.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Displays main menu and gets user response
        public int DisplayMenuAndGetUserInput()
        {
            string selection;

            // Dispplay menu and prompt
            this.MenuOptions();
            this.PromptMenu();

            // Get the Selestion A user enters
            selection = this.GetUserOption();

            // While the response is not valid
            while (!this.ValidSelection(selection))
            {
                // Display an error message.
                this.ErrorMessage();

                // Display prompt again.
                this.PromptMenu();

                // retry user selection.
                selection = this.GetUserOption();
            }
             // Return user selection and cast into an integer via '.Parse()'.
            return int.Parse(selection);

            
        }

        // Displays Droid menu and gets user response
        public int DisplayDroidMenuAndGetUserInput()
        {
            string selection;

            // Dispplay menu and prompt
            this.MenuDroidOptions();
            this.PromptMenu();

            // Get the Selestion A user enters
            selection = this.GetUserOption();

            // While the response is not valid
            while (!this.ValidDroidSelection(selection))
            {
                // Display an error message.
                this.ErrorMessage();

                // Display prompt again.
                this.PromptMenu();

                // retry user selection.
                selection = this.GetUserOption();
            }
            // Return user selection and cast into an integer via '.Parse()'.
            return int.Parse(selection);

        }

        // Displays Material menu and gets user response
        public int DisplayMaterialMenuAndGetUserInput()
        {
            string selection;

            // Dispplay menu and prompt
            this.MenuMaterialOptions();
            this.PromptMenu();

            // Get the Selestion A user enters
            selection = this.GetUserOption();

            // While the response is not valid
            while (!this.ValidMaterialSelection(selection))
            {
                // Display an error message.
                this.ErrorMessage();

                // Display prompt again.
                this.PromptMenu();

                // retry user selection.
                selection = this.GetUserOption();
            }
            // Return user selection and cast into an integer via '.Parse()'.
            return int.Parse(selection);

        }

        // Displays Color menu and gets user response
        public int DisplayColorMenuAndGetUserInput()
        {
            string selection;

            // Dispplay menu and prompt
            this.MenuColorOptions();
            this.PromptMenu();

            // Get the Selestion A user enters
            selection = this.GetUserOption();

            // While the response is not valid
            while (!this.ValidColorSelection(selection))
            {
                // Display an error message.
                this.ErrorMessage();

                // Display prompt again.
                this.PromptMenu();

                // retry user selection.
                selection = this.GetUserOption();
            }
            // Return user selection and cast into an integer via '.Parse()'.
            return int.Parse(selection);

        }

        // Gets new protocol droid info
        public string[] GetNewProtocolDroidInformation()
        {
            string Model = null;
            string Material = this.GetMaterialFieldValueConversion(this.DisplayMaterialMenuAndGetUserInput().ToString());
            string Color = this.GetColorFieldValueConversion(this.DisplayColorMenuAndGetUserInput().ToString());
            string NumberLanguages = this.GetIntField("Languages");

            return new string[] { Model, Material, Color, NumberLanguages };
        }

        // Gets new utility droid info
        public string[] GetNewUtilityDroidInformation()
        {
            string Model = null;
            string Material = this.GetMaterialFieldValueConversion(this.DisplayMaterialMenuAndGetUserInput().ToString());
            string Color = this.GetColorFieldValueConversion(this.DisplayColorMenuAndGetUserInput().ToString());
            string ToolBox = this.GetBoolField("Tool Kit");
            string ComputerConnection = this.GetBoolField("Computer Connection");
            string Scanner = this.GetBoolField("Scanner");

            return new string[] { Model, Material, Color, ToolBox, ComputerConnection, Scanner };
        }

        // Gets new Janitor droid info
        public string[] GetNewJanitorDroidInformation()
        {
            string Model = null;
            string Material = this.GetMaterialFieldValueConversion(this.DisplayMaterialMenuAndGetUserInput().ToString());
            string Color = this.GetColorFieldValueConversion(this.DisplayColorMenuAndGetUserInput().ToString());
            string TrashCompactor = this.GetBoolField("Trash Compactor");
            string Vacuum = this.GetBoolField("Vacuum");
            string ToolBox = this.GetBoolField("Tool Kit");
            string ComputerConnection = this.GetBoolField("Computer Connection");
            string Scanner = this.GetBoolField("Scanner");

            return new string[] { Model, Material, Color, TrashCompactor, Vacuum, ToolBox, ComputerConnection, Scanner };
        }

        // Gets new astromech droid info
        public string[] GetNewAstromechDroidInformation()
        {
            string Model = null;
            string Material = this.GetMaterialFieldValueConversion(this.DisplayMaterialMenuAndGetUserInput().ToString());
            string Color = this.GetColorFieldValueConversion(this.DisplayColorMenuAndGetUserInput().ToString());
            string ToolBox = this.GetBoolField("Tool Kit");
            string ComputerConnection = this.GetBoolField("Computer Connection");
            string Scanner = this.GetBoolField("Scanner");
            string Navigation = this.GetBoolField("Navigation system");
            string NumberShips = this.GetIntField("Ships");

            return new string[] { Model, Material, Color, ToolBox, ComputerConnection, Scanner, Navigation, NumberShips };
        }

        // Displays droid was added to list successfully
        public void DisplayAddDroidSuccess()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("The entry was successfully added to the Droid List.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Displays droid list was not successfully printed
        public void DisplayAddDroidSuccessError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There was a problem attempting to save the Droid. Please try again...");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Displays droid list
        public void DisplayAllDroids(string allDroidsOutput)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Printing List");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(this.GetDroidHeader());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(allDroidsOutput);
        }

        // Displays droid list was not successfully printed
        public void DisplayAllDroidsError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There are no Droids in the list to print");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Displays main menu options
        private void MenuOptions()
        {
            Console.WriteLine();
            Console.WriteLine("What is your entry? (Choose below)");
            Console.WriteLine();
            Console.WriteLine("1. Add a Droid to list.");
            Console.WriteLine("2. Print current Droid list.");
            Console.WriteLine("3. Exit.");
        }

        // Displays droid menu options
        private void MenuDroidOptions()
        {
            
                Console.WriteLine();
                Console.WriteLine("What is your Droid model? (Choose below)");
                Console.WriteLine();
                Console.WriteLine("1. {0}.", "Protocol");
                Console.WriteLine("2. {0}.", "Utility");
                Console.WriteLine("3. {0}.", "Janitor");
                Console.WriteLine("4. {0}.", "Astromech");
                Console.WriteLine("5. Cancel.");
            
        }

        // Displays material menu options
        private void MenuMaterialOptions()
        {
            Console.WriteLine();
            Console.WriteLine("What material? (Choose below)");
            Console.WriteLine();
            Console.WriteLine("1. {0}", "Titanium Gold");
            Console.WriteLine("2. {0}", "Titanium");
            Console.WriteLine("3. {0}", "Gold");
            Console.WriteLine("4. {0}", "Silver");
            Console.WriteLine("5. {0}", "Brass");
            Console.WriteLine("6. None.");
        }


        // Displays color menu options
        private void MenuColorOptions()
        {
            Console.WriteLine();
            Console.WriteLine("What color? (Choose below)");
            Console.WriteLine();
            Console.WriteLine("1. {0}", "Red");
            Console.WriteLine("2. {0}", "Orange");
            Console.WriteLine("3. {0}", "Blue");
            Console.WriteLine("4. {0}", "Green");
            Console.WriteLine("5. {0}", "Yellow");
            Console.WriteLine("6. {0}", "White");
            Console.WriteLine("7. {0}", "Black");
            Console.WriteLine("8. {0}", "Purple");
            Console.WriteLine("9. None.");
        }

        // Displays prompt for input
        private void PromptMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Entry: ");
        }

        // Displays error if invalid entry
        private void ErrorMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("That is not a valid entry. Please make a valid entry...");
            Console.ForegroundColor= ConsoleColor.Gray;
        }

        // gets user input
        private string GetUserOption()
        {
            return Console.ReadLine();
        }

        // If valid selection, a value is returned
        private bool ValidSelection(string selection)
        {
            // Declare a return value and set it to false
            bool givenValue = false;

            try
            {
                // Parse the selection into a choice variable
                int choice = int.Parse(selection);

                // If the choice is between 0 and the max menu choices.
                if (choice > 0 && choice <= MAX_MENU_CHOICES)
                {
                    // set the return value to true
                    givenValue = true;
                }
            }
            // If the selection is not a valid entry, this exception will be thrown
            catch(Exception e)
            {
                givenValue = false;
            }
            // return the givenValue
            return givenValue;
        }

        // If valid selection, a value is returned
        private bool ValidDroidSelection(string selection)
        {
            // Declare a return value and set it to false
            bool givenValue = false;

            try
            {
                // Parse the selection into a choice variable
                int choice = int.Parse(selection);

                // If the choice is between 0 and the max menu choices.
                if (choice > 0 && choice <= MAX_DROIDMENU_CHOICES)
                {
                    // set the return value to true
                    givenValue = true;
                }
            }
            // If the selection is not a valid entry, this exception will be thrown
            catch (Exception e)
            {
                givenValue = false;
            }
            // return the givenValue
            return givenValue;
        }

        // If valid selection, a value is returned
        private bool ValidMaterialSelection(string selection)
        {
            // Declare a return value and set it to false
            bool givenValue = false;

            try
            {
                // Parse the selection into a choice variable
                int choice = int.Parse(selection);

                // If the choice is between 0 and the max menu choices.
                if (choice > 0 && choice <= MAX_MATERIALMENU_CHOICES)
                {
                    // set the return value to true
                    givenValue = true;
                }
            }
            // If the selection is not a valid entry, this exception will be thrown
            catch (Exception e)
            {
                givenValue = false;
            }
            // return the givenValue
            return givenValue;
        }

        // If valid selection, a value is returned
        private bool ValidColorSelection(string selection)
        {
            // Declare a return value and set it to false
            bool givenValue = false;

            try
            {
                // Parse the selection into a choice variable
                int choice = int.Parse(selection);

                // If the choice is between 0 and the max menu choices.
                if (choice > 0 && choice <= MAX_COLORMENU_CHOICES)
                {
                    // set the return value to true
                    givenValue = true;
                }
            }
            // If the selection is not a valid entry, this exception will be thrown
            catch (Exception e)
            {
                givenValue = false;
            }
            // return the givenValue
            return givenValue;
        }

        // Returns value if string parameter is a certian number value, then the name from the array of materials is returned in place of that value
        private string GetMaterialFieldValueConversion(string value)
        {
            string[] names = { "Titanium Gold", "Titanium", "Gold", "Silver", "Brass" };

            string field = null;
            bool valid = false;

            while (!valid)
            {
                if (value == "1")
                {
                    field = names[0];
                    valid = true;
                }
                else if (value == "2")
                {
                    field = names[1];
                    valid = true;
                }
                else if (value == "3")
                {
                    field = names[2];
                    valid = true;
                }
                else if (value == "4")
                {
                    field = names[3];
                    valid = true;
                }
                else if (value == "5")
                {
                    field = names[4];
                    valid = true;
                }
                else if (value == "6")
                {
                    field = "N/A";
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid entry. Please enter a valid entry.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                return field;
            }

            return field;
        }

        // Returns value if string parameter is a certian number value, then the name from the array of colors is returned in place of that value 
        private string GetColorFieldValueConversion(string value)
        {
            string[] names = { "Red", "Orange", "Blue", "Green", "Yellow", "White", "Black", "Purple" };

            string field = null;
            bool valid = false;

            while (!valid)
            {
                if (value == "1")
                {
                    field = names[0];
                    valid = true;
                }
                else if (value == "2")
                {
                    field = names[1];
                    valid = true;
                }
                else if (value == "3")
                {
                    field = names[2];
                    valid = true;
                }
                else if (value == "4")
                {
                    field = names[3];
                    valid = true;
                }
                else if (value == "5")
                {
                    field = names[4];
                    valid = true;
                }
                else if (value == "6")
                {
                    field = names[5];
                    valid = true;
                }
                else if (value == "7")
                {
                    field = names[6];
                    valid = true;
                }
                else if (value == "8")
                {
                    value = names[7];
                    valid = true;
                }
                else if (value == "9")
                {
                    field = "N/A";
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid entry. Please enter a valid entry.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                return field;
            }

            return field;
        }

        // Gets a string based on the parameter fieldName and returns an integer value then converts it to a string
        private string GetIntField(string fieldName)
        {
            Console.WriteLine("How many {0}", fieldName);

            int value = 0;
            bool valid = false;

            while (!valid)
            {
                try
                {
                    value = int.Parse(Console.ReadLine());

                    if (value >= 0)
                    {
                        valid = true;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid integer. Please enter a valid integer.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("How many {0}", fieldName);
                    Console.Write("> ");
                }
            }

            return value.ToString();
        }

        // Gets the string from fieldName parameter and returns a bool value and converts it into a string
        private string GetBoolField(string fieldName)
        {
            Console.WriteLine("Does the droid include a {0} (y/n)", fieldName);

            string input = null;
            bool value = false;
            bool valid = false;

            while (!valid)
            {
                input = Console.ReadLine();
                if (input.ToLower() == "y" || input.ToLower() == "n")
                {
                    valid = true;
                    value = (input.ToLower() == "y");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please respond accordingly to the information given.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("Does the droid include a {0} (y/n)", fieldName);
                    Console.Write("> ");
                }
            }

            return value.ToString();
        }

        // Diplays headers for each category
        private string GetDroidHeader()
        {
            return String.Format(
                "{0,-12} {1,-12} {2,-10} {3, -10} {4, -12} {5, -10} {6, -12} {7, -10} {8, -10} {9, -18} {10, -12} {11, -12} {12, -10} {13, 5}",
                "Model",
                "Material",
                "Color",
                "M&C Cost",
                "#Languages",
                "Tool Kit?",
                "Connection?",
                "Scanner?",
                "options Cost",
                "Trash Compactor?",
                "Vacuum?",
                "Navigation?",
                "#Ships",
                "Total Cost"
                ) +
            Environment.NewLine +
            String.Format(
                "{0,-12} {1,-12} {2,-10} {3, -9} {4, -12} {5, -10} {6, -12} {7, -9} {8, -12} {9, -16} {10, -10} {11, -14} {12, -10} {13, 5}",
                new String('-', 12),
                new String('-', 12),
                new String('-', 7),
                new String('-', 10),
                new String('-', 12),
                new String('-', 10),
                new String('-', 10),
                new String('-', 10),
                new String('-', 10),
                new String('-', 18),
                new String('-', 6),
                new String('-', 13),
                new String('-', 6),
                new String('-', 10)


            );
        }
    }
}
