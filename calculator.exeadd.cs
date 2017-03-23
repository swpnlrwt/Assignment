using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Functions
{
    public static string negativevalues = "";
    public static int doSum(string[] numArray)
    {
        int total = 0;
        for (int i = 0; i < numArray.Length; i++)
        {
            if (!String.IsNullOrWhiteSpace(numArray[i]))
            {
                if (Convert.ToInt32(numArray[i]) < 1000)
                {
                    int check = checkforNumericValue(numArray[i]);
                    // Test for invalid input
                    if (check == 1)
                    {
                        return -1;
                    }
                    //check if the the number is negative
                    bool check2 = checkfornegatives(numArray[i]);

                    if (!check2)
                    {
                        // Add the numbers
                        total = total + Convert.ToInt32(numArray[i]);
                    }
                }
            }
        }
        return total;
    }


    /// <summary>
    /// Checks for negative number
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool checkfornegatives(string s)
    {
        if (Convert.ToInt32(s) < 0)
        {
            negativevalues = negativevalues + s + ",";
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Checks whether the provided value is a number or not.
    /// </summary>
    /// <param name="testValue"></param>
    /// <returns>true or false</returns>
    public static int checkforNumericValue(string testValue)
    {
        int num;
        bool test = int.TryParse(testValue, out num);
        if (test == false)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }


    /// <summary>
    /// Converts the string to an array using the separator
    /// </summary>
    /// <param name="userInput"></param>
    /// <returns>Array of number in string form</returns>
    public static string[] ConvertToArray(string userInput)
    {
        string ConvertedString = userInput;

        // remove/replace new line and other special characters from the provided string.
        System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex("[;\\\\/:*?\"<>|&']");
        ConvertedString = ConvertedString.Replace("n", ",");
        ConvertedString = re.Replace(ConvertedString, ",");

        // Split the string into an array using "," separator
        string[] ConvertedArray = ConvertedString.Split(',').Select(sValue => sValue.Trim()).ToArray();

        return ConvertedArray;
    }


    /// <summary>
    /// Prints final output
    /// </summary>
    /// <param name="result"></param>
    public static void printOutput(int result)
    {
        if (result == -1)
        {
            System.Console.WriteLine("Please enter numbers only.");
        }
        else if (!String.IsNullOrWhiteSpace(Functions.negativevalues))
        {
            string negativevalues = Functions.negativevalues;
            negativevalues = negativevalues.Remove(negativevalues.Length - 1);
            Console.WriteLine("Error: Negative numbers (" + negativevalues + ") not allowed.");
        }
        else
        {
            System.Console.WriteLine(result);
        }
    }
}

class MainClass
{
    static int Main(string[] args)
    {
        // Test if input arguments were supplied:
        if (args.Length == 0)
        {
            System.Console.WriteLine("0");
            return 1;
        }
        // Convert the input string to Array
        string[] ConvertedArray = Functions.ConvertToArray(args[0]);

        // Calculate Sum
        int result = Functions.doSum(ConvertedArray);

        // Print result.
        Functions.printOutput(result);

        return 0;
    }
}