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

            // List<char> charArray = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToChar(arrTemp)).ToList();
            // Accept 
            // List<int> intArray = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(item => Convert.ToInt32(item)).ToList();


            string value = Console.ReadLine().Trim();

            // Result.printLargestPalindrome(value);

            //Result.printSecondMinimum(intArray);

            //Result.printDuplicates(charArray);

            // Result.printDuplicate(value.ToList());

            Result.reverseString(value);

        }
    }

    class Result
    {
        public static void printDuplicates(List<char> charArray)
        {
            // Loop through the array
            // for each character, check if the specified char exists in rest of the collection
            // if yes, insert into a new array
            // Print new array

            //var stack = new System.Collections.Stack();
            List<char> newArray = new List<char>();

            for (int i = 0; i < charArray.Count - 1; i++)
            {
                //stack.Push(charArray[i]);

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
            // abfjgerccdeedccjfgfer , ccdeedcc
            // Find the palindromes
            // Check length and store in array
            // Print with max length palindrome

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

        public static void printDuplicate(List<char> array)
        {
            array.Sort();
            for (int i = 0; i < array.Count - 1; i++)
            {
                Console.WriteLine($"iteration: {i}");
                if (array[i] == array[i + 1])
                {
                    Console.WriteLine(array[i]);
                    break;
                }
            }
        }

        public static void reverseString(string str)
        {
            // convert to Array
            // Reverse array
            // generate string

            char[] charArray = str.ToCharArray();
            for (int i = 0, j = str.Length - 1; i < charArray.Length / 2; i++, j--)
            {
                var temp = charArray[i];
                charArray[i] = charArray[j];
                charArray[j] = temp;
            }

            string reversedString = new string(charArray);

            Console.WriteLine(reversedString);

        }
        
        public static int CalculateDiagonalDifference(List<List<int>> arr)
        {
            //1 8 5
            //1 6 7
            //1 4 -2  
            // Result = (1+6-2) - (5+6+1) = -7 = 7
            var n = arr.Count;
            int lRSum = 0, rLSum = 0;      
            for(int i=0,j=n-1;i<=n-1;i++,j--)
            {                
                lRSum += arr[i][i];
                rLSum += arr[i][j]; 
            }
            return lRSum>rLSum?lRSum-rLSum:rLSum-lRSum;
        }
        
        public static void PrintRightAlignedStairCase()
        {
             // n=3
            
            // #
           // ##
          // ###
            
            // Print n-index spaces and then print rest #        
            for(int i=1;i<=n;i++)
            {
                for(int j=0;j<n-i;j++)
                {
                    Console.Write(' ');
                }
                for(int k=n-i;k<n;k++)
                {
                    Console.Write('#');
                }           
                // Go to new line
                Console.WriteLine();
            }
        }


    }
}
