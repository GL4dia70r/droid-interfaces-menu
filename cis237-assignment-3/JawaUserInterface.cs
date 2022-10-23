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
        Droid[] droids;
        
        const int MAX_MENU_CHOICES = 3;
        const int MAX_DROIDMENU_CHOICES = 5;
        const int MAX_MATERIALMENU_CHOICES = 6;
        const int MAX_COLORMENU_CHOICES = 9;
        
        public void WelcomeGreeting()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome, to the Droid Upload System Program.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        //
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

        //
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

        //
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
            return int.Parse(selection) + 1;

        }

        //
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
            return int.Parse(selection) + 1;

        }

        //
        public string[] GetNewProtocolDroidInformation()
        {
            string Model = null;
            string Material = this.DisplayMaterialMenuAndGetUserInput().ToString();
            string Color = this.DisplayColorMenuAndGetUserInput().ToString();
            string NumberLanguages = this.GetIntField("Number Of Languages");

            return new string[] { Model, Material, Color, NumberLanguages };
        }

        //
        public string[] GetNewUtilityDroidInformation()
        {
            string Model = null;
            string Material = this.DisplayMaterialMenuAndGetUserInput().ToString();
            string Color = this.DisplayColorMenuAndGetUserInput().ToString();
            string ToolBox = this.GetBoolField("ToolBox");
            string ComputerConnection = this.GetBoolField("Computer Connection");
            string Scanner = this.GetBoolField("Scanner");

            return new string[] { Model, Material, Color, ToolBox, ComputerConnection, Scanner };
        }

        //
        public string[] GetNewJanitorDroidInformation()
        {
            string Model = null;
            string Material = this.DisplayMaterialMenuAndGetUserInput().ToString();
            string Color = this.DisplayColorMenuAndGetUserInput().ToString();
            string TrashCompactor = this.GetBoolField("Trash Compactor");
            string Vacuum = this.GetBoolField("Vacuum");
            string ToolBox = this.GetBoolField("ToolBox");
            string ComputerConnection = this.GetBoolField("Computer Connection");
            string Scanner = this.GetBoolField("Scanner");



            return new string[] { Model, Material, Color, TrashCompactor, Vacuum, ToolBox, ComputerConnection, Scanner };
        }

        //
        public string[] GetNewAstromechDroidInformation()
        {
            string Model = null;
            string Material = this.DisplayMaterialMenuAndGetUserInput().ToString();
            string Color = this.DisplayColorMenuAndGetUserInput().ToString();
            string ToolBox = this.GetBoolField("ToolBox");
            string ComputerConnection = this.GetBoolField("Computer Connection");
            string Scanner = this.GetBoolField("Scanner");
            string Navigation = this.GetBoolField("Navigation");
            string NumberShips = this.GetIntField("Number Of Ships");

            return new string[] { Model, Material, Color, ToolBox, ComputerConnection, Scanner, Navigation, NumberShips };
        }

        //
        public void DisplayAddDroidSuccess()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("The entry was successfully added to the Droid List.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        //
        public void DisplayDroidAlreadyExistsError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A Droid With That model Already Exists");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        //
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

        //
        public void DisplayAllDroidsError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There are no Droids in the list to print");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        //
        private void MenuOptions()
        {
            Console.WriteLine();
            Console.WriteLine("What is your entry? (Choose below)");
            Console.WriteLine();
            Console.WriteLine("1. Add a Droid to list.");
            Console.WriteLine("2. Print current Droid list.");
            Console.WriteLine("3. Exit.");
        }

        //
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

        //
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


        //
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
            Console.WriteLine("6. {0}", "WHite");
            Console.WriteLine("7. {0}", "Black");
            Console.WriteLine("8. {0}", "Purple");
            Console.WriteLine("9. None.");
        }

        private void PromptMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Entry: ");
        }

        //
        private void ErrorMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("That is not a valid entry. Please make a valid entry...");
            Console.ForegroundColor= ConsoleColor.Gray;
        }

        //
        private string GetUserOption()
        {
            return Console.ReadLine();
        }

        //
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

        //
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

        //
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

        //
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

        //
        private string GetStringField(string fieldName)
        {
            Console.WriteLine("What is the new Droid's {0}", fieldName);
            string value = null;
            bool valid = false;
            while(!valid)
            {
                value = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(value))
                {
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must provide an entry.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("What is the new Droid's {0}", fieldName);
                    Console.Write("> ");
                }
            }
            return value;
        }

        //
        //private string GetStringModelField(string fieldName)
        //{
        //    string value = null;
        //    bool valid = false;
        //    while (!valid)
        //    {
        //        value = this.DisplayDroidMenuAndGetUserInput().ToString();

        //        if (!!String.IsNullOrEmpty(value))
        //        {
        //            valid = true;
        //        }
        //        else
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("You must provide an entry.");
        //            Console.ForegroundColor = ConsoleColor.Gray;
        //            Console.WriteLine();
        //            Console.WriteLine("What is the new Droid's {0}", fieldName);
        //            Console.Write("> ");
        //        }
        //    }
        //    return value;
        //}

        //
        private string GetStringMaterialField(string fieldName)
        {
            string value = null;
            bool valid = false;
            while (!valid)
            {
                value = this.DisplayMaterialMenuAndGetUserInput().ToString();

                if (!String.IsNullOrEmpty(value))
                {
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must provide an entry.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("What is the new Droid's {0}", fieldName);
                    Console.Write("> ");
                }
            }
            return value.ToString();
        }

        private string GetStringColorField(string fieldName)
        {
            string value = null;
            bool valid = false;
            while (!valid)
            {
                value = DisplayColorMenuAndGetUserInput().ToString();

                if (!String.IsNullOrWhiteSpace(value))
                {
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must provide an entry.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("What is the new Droid's {0}", fieldName);
                    Console.Write("> ");
                }
            }
            return value;
        }

        //
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
                    valid = true;
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

        //
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

        //
        private string GetDroidHeader()
        {
            return String.Format(
                "{0,-12} {1,-6} {2,20}",
                "Material",
                "Color", 
                "Number Of Languages",
                "ToolBox",
                "Computer Connection",
                "Scanner",
                "Trash Compactor",
                "Vacuum",
                "Navigation",
                "Number Of Ships",
                "Total Cost"
                ) +
            Environment.NewLine +
            String.Format(
                "{0,-12} {1,-6} {2,20}",
                new String('-', 12),
                new String('-', 7),
                new String('-', 26),
                new String('-', 10),
                new String('-', 26),
                new String('-', 6),
                new String('-', 6),
                new String('-', 6),
                new String('-', 6),
                new String('-', 15),
                new String('_', 18)


            );
        }
    }
}
