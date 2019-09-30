using System;
using System.Diagnostics;

namespace Assignment1_F19
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = -22, b = 22;
            printSelfDividingNumbers(a, b);

            int n2 = 8;
            printSeries(n2);

            int n3 = 5;
            printTriangle(n3);

            int[] J = new int[] { 1, 3 };
            int[] S = new int[] { 1, 3, 3, 2, 2, 2, 2, 2 };
            int r4 = numJewelsInStones(J, S);
            Console.WriteLine(r4);

            int[] arr1 = new int[] { 1, 2, 5, 6, 7, 8, 9 };
            int[] arr2 = new int[] { 1, 2, 3, 4, 5 };
            getLargestCommonSubArray(arr1, arr2);

            solvePuzzle();
        }

        public static void printSelfDividingNumbers(int x, int y)
        {
            try
            {
                Console.WriteLine("Self Dividing Numbers between " + x + " and " + y + " are: ");
                int num;
                // If x is greater than y then swap numbers (handles negative numbers as well)
                if (x > y)
                {
                    int temp = x;
                    x = y;
                    y = temp;
                }
                //For all the numbers between x and y
                for (num = x; num <= y; num++)
                {
                    //Check if the number is a self dividing or not, if yes then print that number
                    if (isSelfDividing(num))
                    {
                        Console.Write(num + ", ");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSelfDividingNumbers()");
            }
        }

        public static bool isSelfDividing(int num)
        {
            /*If the number is negative number then run the logic for absolute of the negative number.
            * ex: if number is -12 then run logic for 12 and check if self diving or not
            */
            if (num == 0) return false;
            if (num < 0) num = num * (-1);

            //Assign the value of number to a temporary variable
            int tempNum = num;
            int individualDigit;
            //Findout individual digits in the number
            while (tempNum > 0)
            {
                //Find the last digit in number
                individualDigit = tempNum % 10;

                if (individualDigit == 0)
                {
                    return false;
                }
                else if (num % individualDigit != 0)
                {
                    //If the number is not divisible by individual digit then return false
                    return false;
                }
                //remove the last digit of temporary number and check for remaining individual digits
                tempNum = tempNum / 10;
            }
            return true;
        }

        public static void printSeries(int n)
        {
            try
            {
                //if n is less than or equal to 0 then return
                if (n <= 0)
                    return;
                Console.WriteLine("");
                Console.WriteLine("The series of numbers till " + n + " are: ");
                int i, j, count = 0;
                //For 1 to n print the series of numbers
                for (i = 1; i <= n; i++)
                {
                    for (j = 1; j <= i; j++)
                    {
                        if (count == n)
                            return;
                        Console.Write(i + ", ");
                        count++;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSeries()");
            }
        }

        public static void printTriangle(int n)
        {
            try
            {
                //if n is less than or equal to 0 then return
                if (n <= 0)
                    return;
                Console.WriteLine(" \nThe inverted triangle with n = " + n + " is: ");
                int numOfRows, numOfSpaces, numOfStars;
                //Numbering the rows in descending order
                for (numOfRows = n; numOfRows > 0; numOfRows--)
                {
                    Console.WriteLine("");
                    //Each line has (n minus nth row) number of spaces in each row before the stars
                    for (numOfSpaces = 1; numOfSpaces <= n - numOfRows; numOfSpaces++)
                    {
                        Console.Write(" ");
                    }
                    //Each row has 2*number of rows - 1 stars
                    for (numOfStars = 1; numOfStars <= 2 * numOfRows - 1; numOfStars++)
                    {
                        Console.Write("*");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }

        public static int numJewelsInStones(int[] J, int[] S)
        {
            try
            {
                Console.WriteLine("\nNumber of Jewels are: ");
                int jewels, stones, numOfJewels = 0;
                //For all jewels
                for (jewels = 0; jewels < J.Length; jewels++)
                {
                    //For all stones
                    for (stones = 0; stones < S.Length; stones++)
                    {
                        //If any of the stone matches to the jewel then increase count of jewels

                        if (S[stones] == J[jewels])
                        {
                            numOfJewels++;
                        }
                    }
                }
                return numOfJewels;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing numJewelsInStones()");
            }

            return 0;
        }

        public static void getLargestCommonSubArray(int[] arr1, int[] arr2)
        {
            try
            {
                if (arr1.Length == 0 || arr2.Length == 0) return;
                int i = 0, j = 0, maxLen = 0, newLen = 0, start = 0, end = 0;
                while (i < arr1.Length && j < arr2.Length)
                {
                    //if arr1[i] == arr2[j] then increase the newlength and go for the next comparison 
                    if (arr1[i] == arr2[j])
                    {
                        newLen++;
                        i++;
                        j++;
                    }
                    else
                    {
                        if (newLen >= maxLen)
                        {
                            maxLen = newLen;
                            end = i - 1; //note down the end of longest common sub array
                        }
                        if (arr1[i] < arr2[j]) i++;
                        else j++;
                        //if new length is greater than or equals max length then update the max length

                        newLen = 0;
                    }
                    //If i or j reaches the length of arrays then check for max length
                    if (i >= arr1.Length || j >= arr2.Length)
                    {
                        if (newLen >= maxLen)
                        {
                            maxLen = newLen;
                            end = i - 1;
                        }
                    }

                }
                int[] result = new int[maxLen]; //create a new array to store the result
                start = end - maxLen + 1;//note down the start of the longest common sub array
                for (j = 0; j < maxLen; j++, start++)
                {
                    result[j] = arr1[start];//add elements to the result
                }

                Console.WriteLine("The longest common subarray is: ");
                displayArray(result);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getLargestCommonSubArray()");
            }
        }
        public static void displayArray(int[] res)
        {
            for (int i = 0; i < res.Length; i++)
            {
                Console.Write(res[i] + " ");
            }
        }
        //Structure to store the alphabet and the value of the alphabet
        public struct node
        {
            public int value;
            public char letter;
        };
        static int flag = -1; //Flag variable to check whether the soultioon is found or not
        public static void solvePuzzle()
        {
            try
            {
                Console.WriteLine("");
                String str1, str2, result;
                int i, j, count = 0;
                Console.WriteLine("Enter values of three Strings: ");
                str1 = Console.ReadLine();
                str2 = Console.ReadLine();
                result = Console.ReadLine();
                // if any of the entered alphabet in String is in Lower Case then converting the String to Upper Case
                str1 = str1.ToUpper();
                str2 = str2.ToUpper();
                result = result.ToUpper();

                int[] countAlphabets = new int[26];//Count the alphabets entered in the strings str1,str2,result
                for (i = 0; i < str1.Length; i++)
                    countAlphabets[str1[i] - 'A']++;
                for (i = 0; i < str2.Length; i++)
                    countAlphabets[str2[i] - 'A']++;
                for (i = 0; i < result.Length; i++)
                    countAlphabets[result[i] - 'A']++;

                for (i = 0; i < 26; i++)
                    if (countAlphabets[i] > 0)
                        count++;
                /*If the entered Strings has count of individual alphabets greater than 10 (0-9), 
                 *  then entered strings are invalid
                 * */
                if (count > 10)
                    Console.WriteLine("entered Strings are invalid");

                //create an array structure of the alphabets and their assigned values
                node[] LettersAndValues = new node[count];
                for (i = 0, j = 0; i < 26; i++)
                {
                    if (countAlphabets[i] > 0)
                    {
                        LettersAndValues[j].letter = (char)(i + 'A');
                        j++;
                    }
                }
                /*
                 * make use of an array of length 10 to check whether a number is assigned to an alphabet or not
                 * for ex: if 0 is assigned to an alphabet then mark used[0] = 1 (marking it as assigned)
                 * */
                int[] used = new int[10];
                Console.WriteLine("Possible Assignment of numbers to alphabets in entered Strings are: ");
                allPossibilities(LettersAndValues, count, 0, str1, str2, result, used);
                if (flag == -1)
                    Console.WriteLine("\n !!!  SORRY !!!\n  No possible combination of numbers to the alphabets is found, please try with another set of values");

            }
            catch
            {
                Console.WriteLine("Exception occured while computing solvePuzzle()");
            }
        }
        /*
         * This method checks for all the possibilities of assignments of integers 0-9 for all the alphabets (Brute Force)
         * */
        public static void allPossibilities(node[] LettersAndValues, int count, int n, String str1, String str2, String result, int[] used)
        {
            //if the n is the number of alphabets in the entered strings 
            if (n == count - 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (used[i] == 0)
                    {
                        LettersAndValues[n].value = i;
                        //For each possibility check whether that combination works or not
                        if (checkCombination(LettersAndValues, count, str1, str2, result))
                        {
                            flag = 1; //assign flag = 1 to note that solution to puzzle is found
                            Console.WriteLine("\n");
                            for (int j = 0; j < count; j++)
                                Console.Write(LettersAndValues[j].letter + " = " + LettersAndValues[j].value + ",  ");
                            return;
                        }
                    }
                }
                //If the combination didn't work then return
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                if (used[i] == 0)
                {
                    LettersAndValues[n].value = i;
                    //assigned value of i to an alphabet and marking it as assigned (used[i] = 1)
                    used[i] = 1;
                    //Check for other possibilities for the alphabets
                    allPossibilities(LettersAndValues, count, n + 1, str1, str2, result, used);
                    //if the possibility is not found then unmark the number.
                    used[i] = 0;
                }
            }
            return;
        }
        /*
         * This method checks whether the assigned combination works for Str1+Str2 = result or not
         * */
        public static bool checkCombination(node[] lettersAndValues, int count, String a, String b, String c)
        {
            int num1 = 0, num2 = 0, sum = 0, i, j, val = 1;
            char letter;
            //Obtain the value of String1 using assigned numbers for alphabets
            for (i = a.Length - 1; i >= 0; i--)
            {
                letter = a[i];
                for (j = 0; j < count; j++)
                {
                    if (lettersAndValues[j].letter == letter)
                        break;
                }
                num1 = num1 + val * lettersAndValues[j].value;
                val = val * 10;
            }
            val = 1;
            //Obtain the value of String2 using assigned numbers for alphabets
            for (i = b.Length - 1; i >= 0; i--)
            {
                letter = b[i];
                for (j = 0; j < count; j++)
                {
                    if (lettersAndValues[j].letter == letter)
                        break;
                }
                num2 = num2 + val * lettersAndValues[j].value;
                val = val * 10;
            }
            val = 1;
            //Obtain the value of result using assigned numbers for alphabets
            for (i = c.Length - 1; i >= 0; i--)
            {
                letter = c[i];
                for (j = 0; j < count; j++)
                {
                    if (lettersAndValues[j].letter == letter)
                        break;
                }
                sum = sum + val * lettersAndValues[j].value;
                val = val * 10;
            }

            //check whether sum = num1 + num2 or not if yes the return true, else return false
            if (sum == num1 + num2)
                return true;
            return false;
        }
    }
}

