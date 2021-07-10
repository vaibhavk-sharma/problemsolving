using System;
using System.Collections.Generic;
using System.Linq;

namespace problemsolving
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //int n = Convert.ToInt32(Console.ReadLine().Trim());

            // List<char> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToChar(arrTemp)).ToList();

            // List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(item=>Convert.ToInt32(item)).ToList();

            string value = Console.ReadLine().Trim();

            Result.printLargestPalindrome(value);
            //Result.printSecondMinimum(arr);

            //Result.printDuplicates(arr);
        }
    }

    class Result
    {

        /*
         * Complete the 'plusMinus' function below.
         *
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static void printDuplicates(List<char> charArray)
        {
            var stack = new System.Collections.Stack();
            List<char> newArray = new List<char>();

            for (int i = 0; i < charArray.Count - 1; i++)
            {

                stack.Push(charArray[i]);

                if (charArray.FindIndex(i + 1, charArray.Count - (i + 1), c => c.Equals(charArray[i])) > -1)
                {
                    if (!newArray.Exists(c => c.Equals(charArray[i])))
                        newArray.Add(charArray[i]);
                }
            }
            // foreach(var item in stack)
            // {
            // Console.WriteLine(item);
            // }
            newArray.ForEach(item => Console.WriteLine(item));
        }

        public static void printSecondMinimum(List<int> array)
        {
            // 1 8 4 9        
            //array.Sort((a,b)=>b-a);   // Descending
            array.Sort();
            Console.WriteLine(array[1]);
        }

        public static void printLargestPalindrome(string value)
        {
            // abfgerccdedccfgfer , ccdedcc
            // Find the palindrome
            // Check length

            List<char> stringArray = value.ToList();

            List<string> palindromes = new List<string>();

            string largestPalindrome = "";

            List<int> palindromesLengths = new List<int>();

            for (int i = 0; i < stringArray.Count - 1; i++)
            {
                int secondIndex = stringArray.FindIndex(i + 1, stringArray.Count - (i + 2), c => c.Equals(stringArray[i]));

                int nextIndex = secondIndex; // abfgerccdedccfgfer ..  //ccdedcc
                                             // Count = 18, i=6, 7..10
                while (nextIndex != -1)
                {
                    var subString = value.Substring(i, nextIndex - i + 1);
                    var subStringArray = subString.ToCharArray();
                    Array.Reverse(subStringArray);
                    var reversedSubString = new string(subStringArray);


                    if (subString.Equals(reversedSubString))
                    {
                        palindromes.Add(subString);
                        palindromesLengths.Add(subString.Length);
                        //palindromesLengths.Add(nextIndex - i);

                    }
                    nextIndex = stringArray.FindIndex(nextIndex + 1, stringArray.Count - (nextIndex + 2), c => c.Equals(stringArray[i]));

                }
            }

            palindromesLengths.Sort();
            largestPalindrome = palindromes.Find(item => item.Length == palindromesLengths[palindromesLengths.Count - 1]);

            Console.WriteLine(largestPalindrome);

        }
    }
}
