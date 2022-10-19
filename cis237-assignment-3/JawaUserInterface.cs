using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    internal class JawaUserInterface
    {
        const int MAX_MENU_CHOICES = 5;

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
            return Int32.Parse(selection);

            
        }

        private void MenuOptions()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Load Wine List From CSV");
            Console.WriteLine("2. Print The Entire List Of Items");
            Console.WriteLine("3. Search For An Item");
            Console.WriteLine("4. Add New Item To The List");
            Console.WriteLine("5. Exit Program");
        }
    }
}
