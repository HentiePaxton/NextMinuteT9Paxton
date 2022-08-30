using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextMinuteT9Paxton
{
    public class T9Translator
    {
        public static string TranslateLine(string input)
        {
            input = input.ToUpper();
            // storing the sequence in array
            string[] arr = { "2", "22", "222", "3", "33", "333", "4", "44", "444", "5", "55", "555", "6", "66", "666", "7", "77", "777", "7777", "8", "88", "888", "9", "99", "999", "9999" };

            string output = "";

            //Record the previous key to add space for Pause
            string previousKey = "";

            // length of input string
            int n = input.Length;
            for (int i = 0; i < n; i++)
            {
                //This will get the Alphabetic index of the character( "A" will be 0, "B" will be 1, etc )
                int position = input[i] - 'A';

                // Checking for space
                if (input[i] == ' ')
                {
                    if (previousKey == "0")
                        output += " ";

                    output = output + "0";

                    //Record the previous key to add space for Pause
                    previousKey = "0";
                }
                else
                {
                    if (previousKey == arr[position].First().ToString())
                        output += " ";

                    // Calculating index for each
                    // character
                    output += arr[position];

                    //Record the previous key to add space for Pause
                    previousKey = arr[position].First().ToString();
                }
            }

            // Output sequence
            return output;
        }
    }
}
