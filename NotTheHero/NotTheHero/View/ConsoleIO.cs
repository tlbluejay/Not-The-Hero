using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTheHero.View
{
    class ConsoleIO
    {

        public static int PromptForMenuSelection(String[] options, bool withQuit)
        {
            bool isInvalid = true;
            if(options.Length == 0)
            {
                return 0;
            } else
            {
                int input = -1;
                do
                {
                    for (int i = 0; i < options.Length; i++)
                    {
                        Console.WriteLine((i + 1) + ") " + options[i]);
                    }
                    if (withQuit)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("0) Quit Menu");
                    }
                    try
                    {
                        input = Int32.Parse(promptForInput("Select one of the menu options: ", false));
                    }
                    catch (FormatException nfe)
                    {
                        Console.WriteLine("entry has to be a number");
                    }
                } while (isInvalid);
                return input;
            }
        }

        private static string promptForInput(string prompt, bool allowEmpty)
        {
            String input = " ";
            bool isInvalid = true;
            if (prompt == null)
            {
                throw new ArgumentException("You cannot have a null prompt");
            }
            do
            {
                Console.WriteLine(prompt);
                try
                {
                    input = Console.ReadLine();

                }
                catch (IOException ioe)
                {
                    Console.WriteLine("Bork'd");

                }

                if (input.Equals(""))
                {
                    if (!allowEmpty)
                    {
                        Console.WriteLine("cant be empty");
                    }
                    else if (allowEmpty)
                    {
                        Console.WriteLine("wow you like empty inputs..");
                        isInvalid = false;
                    }

                }
                else
                {
                    isInvalid = false;
                }
            } while (isInvalid);

            return input;
        }

        public static bool promptForBool(String prompt, String trueString, String falseString)
        {
            bool isInvalid = true;
            bool result = true;
            do
            {
                String input = promptForInput(prompt, false);
                if (input.Equals(trueString, StringComparison.OrdinalIgnoreCase))
                {
                    result = true;
                    isInvalid = false;
                }
                else if (input.Equals(falseString, StringComparison.OrdinalIgnoreCase))
                {
                    result = false;
                    isInvalid = false;
                }
                else if (!input.Equals(trueString, StringComparison.OrdinalIgnoreCase) 
                    || !input.Equals(falseString, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("input must match the one of the given options");
                }

            } while (isInvalid);
            return result;
        }
        public static byte promptForByte(String prompt, byte min, byte max)
        {
            byte num = 0;

            bool isInvalid = true;
            do
            {
                try
                {
                    String input = promptForInput(prompt, false);

                    num = Byte.Parse(input);
                }
                catch (FormatException nfe)
                {
                    Console.WriteLine("entry has to be a number");
                }
                if (num > max || num < min)
                {
                    Console.WriteLine("enter a number within the range");

                }
                else
                {
                    isInvalid = false;
                }

            } while (isInvalid);

            return num;
        }

        public static int promptForInt(String prompt, int min, int max)
        {
            int num = -1;

            bool isInvalid = true;
            do
            {
                try
                {
                    String input = promptForInput(prompt, false);

                    num = Int32.Parse(input);
                }
                catch (FormatException nfe)
                {
                    Console.WriteLine("entry has to be a number");
                }
                if (num > max || num < min)
                {
                    Console.WriteLine("enter a number within the range");

                }
                else
                {
                    isInvalid = false;
                }

            } while (isInvalid);

            return num;
        }
    }
}
