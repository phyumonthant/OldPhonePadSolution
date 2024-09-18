using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePadNamespace
{
    public class OldPhonePadSolution
    {
        public static string OldPhonePad(string input)
        {
            // Define the mapping of keypad digits to letters
            var phoneKeypad = new Dictionary<char, string>
            {
                { '2', "ABC" },
                { '3', "DEF" },
                { '4', "GHI" },
                { '5', "JKL" },
                { '6', "MNO" },
                { '7', "PQRS" },
                { '8', "TUV" },
                { '9', "WXYZ" }
            };

            // StringBuilder to build the final result
            var result = new StringBuilder();
            var currentSequence = new StringBuilder();

            // Variables to keep track of the current sequence of digits being pressed
            char currentDigit = '\0'; // Stores the current digit being processed
            char? lastDigit = null; // Count how many times the current digits is pressed
            int currentCount = 0;

            foreach (var ch in input) // Iterate over each character in the input string
            {
                if (ch == ' ')
                {
                    // Handle the space as a pause, process the last digit
                    if (currentDigit != '\0')
                    {
                        var characters = phoneKeypad[currentDigit];
                        result.Append(characters[(currentCount - 1) % characters.Length]);
                        currentDigit = '\0'; // Reset after processing
                        currentCount = 0; // Reset the count
                    }
                }
                else if (ch == '*')
                {
                    // Handle backspace delete the last character if already added to result
                    if (currentDigit != '\0' && currentCount > 0) // If there is an ongoing sequence
                    {
                        // Reset the current sequence
                        currentDigit = '\0';
                        currentCount = 0;
                    }
                    else if (result.Length > 0)
                    {
                        // Remove the last added character if result has characters
                        result.Length--;
                    }
                }
                else if (ch == '#')
                {
                    // Handle end of input, process any remaining digits
                    if (currentDigit != '\0')
                    {
                        var characters = phoneKeypad[currentDigit];
                        result.Append(characters[(currentCount - 1) % characters.Length]); // Append last letter
                        currentDigit = '\0';
                    }
                    break; // Stop processing further input
                }
                else if (phoneKeypad.ContainsKey(ch))
                {
                    // Handle keypad digits
                    if (ch == currentDigit)
                    {
                        // If the same digit is pressed again, increase count
                        currentCount++;
                    }
                    else
                    {
                        // Process the previous digit sequence
                        if (currentDigit != '\0')
                        {
                            var characters = phoneKeypad[currentDigit];
                            result.Append(characters[(currentCount - 1) % characters.Length]); // Append corresponding letter
                        }
                        // Start a new sequence for the current digit
                        currentDigit = ch;
                        currentCount = 1; // Start counting for the new digit
                    }
                }
            }

            return result.ToString(); // Return the final result string
        }

        public static void Main(string[] args)
        {
            // Test cases
            Console.WriteLine(OldPhonePad("33#"));            // Expected output: E
            Console.WriteLine(OldPhonePad("227*#"));          // Expected output: B
            Console.WriteLine(OldPhonePad("4433555 555666#")); // Expected output: HELLO
            Console.WriteLine(OldPhonePad("8 88777444666*664#")); // Expected output: TURING
        }
    }
}