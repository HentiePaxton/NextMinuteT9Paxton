
## Problem

The Latin alphabet contains 26 characters and telephones only have ten digits on the keypad. We would like to make it easier to write a message to your friend using a sequence of keypresses to indicate the desired characters. The letters are mapped onto the digits as shown below. To insert the character B for instance, the program would press 22. In order to insert two characters in sequence from the same key, the user must pause before pressing the key a second time. The space character ' ' should be printed to indicate a pause. For example, 2 2 indicates AA whereas 22 indicates B.

## Input

The first line of input gives the number of cases, N. N test cases follow. Each case is a line of text formatted as

`desired_message`

Each message will consist of only lowercase characters a-z and space characters ' '. Pressing zero emits a space.

## Output

For each test case, output one line containing "Case #x: " followed by the message translated into the sequence of keypresses.

## Limits

1 ≤ N ≤ 100.

### Small dataset

1 ≤ length of message in characters ≤ 15.

### Large dataset

1 ≤ length of message in characters ≤ 1000.

### Sample

| Input | Output | 
| ----- | ------ |
| 4 | |
| hi | Case #1: 44 444 |
| yes | Case #2: 999337777 |
| foo  bar | Case #3: 333666 6660 022 2777 |
| hello world | Case #4: 4433555 555666096667775553 |

## Solution

For this exercise I used a very basic Windows Forms Applicaiton as the UI to quickly allow test inputs and demontrate T9 translation.

The solution includes 2 projects 
* **NextMinuteT9Paxton** - The Windows Forms application & the T9Translator class

Windows forms event & IO
```
private void btnTranslate_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (string line in txtInput.Lines)
                {
                    int index = txtInput.Lines.ToList().IndexOf(line);

                    if (index > 0)
                        txtOutput.Text += "Case#" + (index).ToString() + ": " + T9Translator.TranslateLine(line) + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
```
Translator Class
```
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
```

* **NextMinuteT9Paxton_UnitTest**  -The Unit Test project, which contains a single unit test verifying results against the translator for "hello world"

```
namespace NextMinuteT9Paxton_UnitTest
{
    [TestClass]
    public class TranslatorTest
    {
        [TestMethod]
        public void TestTranslation()
        {
            // arrange
            string input = "hello world";
            string expected = "4433555 555666096667775553";

            // act
            string actual = T9Translator.TranslateLine(input);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
```

#### Requirements
* Visual Studio 2019 or later

#### Steps
* Pull from Git (master)
* Build Solution
* Set **NextMinuteT9Paxton** as Startup application
* Run the application


