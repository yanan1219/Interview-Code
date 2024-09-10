/*
 * File: SimplifiedMasterMind.cs
 * Author: Yanan (Jessica) Liu
 * Date: 09/09/24
 * 
 * Description: 
 * This program implements a simplified version of the Mastermind game. The objective is for the user
 * to guess a randomly generated 4-digit number where each digit is between 1 and 6. After each guess, 
 * the program provides result: 
 *   - A '+' is displayed for each correct digit in the correct position.
 *   - A '-' is displayed for each correct digit in the wrong position.
 *   - Nothing is shown for incorrect digits.
 * The player has 10 attempts to guess the number correctly before the game ends.
 *

 */


using System;

public class SimplifiedMasterMind
{
    public static void Main(string[] args)
    {
        //Set a random value with 4 digits
        var rand = new Random();
        int len = 4;
        int[] numbers = new int[4];
        for (int i = 0; i < 4; i++)
            numbers[i] = rand.Next(1, 6);
        //int[] numbers={5,5,3,5};
        //initiate values
        int times = 10;
        bool success = false;

        Console.WriteLine("Game starts! Please input a 4-digit combination, and each digit is between 1 and 6.");
        //attemp time is less than 10 and have not got the number
        while (times > 0 && !success)
        {
            Console.WriteLine("");
            Console.WriteLine("You still have {0} times left, keep trying!", times);
            Console.WriteLine("Please enter your guess...");
            string inputStr = Console.ReadLine();
            //Validate input first
            if (!isValid(inputStr))
            {
                Console.WriteLine("Invalid input.The input should be 4 digits, and each digit is between 1 and 6.");
                continue;
            }
            else
            {
                string resultShown = "";
                char[] charArray = inputStr.ToCharArray();
                bool[] usedNumber = new bool[4];
                bool[] checkedInput = new bool[4];
                //Get all the matches first;
                for (int j = 0; j < 4; j++)
                {
                    int checkedNum = Convert.ToInt32(charArray[j].ToString());
                    if (checkedNum == numbers[j])
                    {
                        usedNumber[j] = true;
                        checkedInput[j] = true;
                        resultShown += "+";
                    }

                }
                //Check if there is right number but in a wrong position;
                for (int t = 0; t < 4; t++)
                {
                    int checkedNum2 = Convert.ToInt32(charArray[t].ToString());
                    if (!checkedInput[t])
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (!usedNumber[j] && numbers[j] == checkedNum2)
                            {
                                usedNumber[j] = true;
                                checkedInput[t] = true;
                                resultShown += "-";
                                break;
                            }
                        }

                    }

                }




                times--;

                if (resultShown == "++++")
                {
                    Console.WriteLine("Congratulations! You've got the number!");
                    success = true;
                }
                else
                {
                    Console.WriteLine("the result is " + resultShown);

                }
                if (times == 0)
                {
                    Console.WriteLine("The combination is {0}", String.Concat(numbers));
                    Console.WriteLine("Thank you for participating...");
                }

            }
        }
    }
    static bool isValid(string input)
    {
        if (input.Length != 4)
            return false;
        foreach (char c in input)
        {
            if (c < '1' || c > '6')
                return false;
        }
        return true;
    }
}

