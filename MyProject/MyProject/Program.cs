using System;

namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int arraySize = int.Parse(input);

            var array = new int[arraySize];

            GenerateValues(array);

            var firstArray = new int[arraySize];

            var secondArray = new int[arraySize];

            int firstArrayActualSize = 0;

            int secondArrayActualSize = 0;

            foreach (var integer in array)
            {
                if (integer % 2 == 0)
                {
                    firstArray[firstArrayActualSize] = integer;
                    firstArrayActualSize++;
                }
                else
                {
                    secondArray[secondArrayActualSize] = integer;
                    secondArrayActualSize++;
                }
            }

            var alphabet = CreateAlphabet();

            var firstArrayToString = string.Empty;

            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] == 0)
                {
                    continue;
                }

                firstArrayToString += alphabet[firstArray[i] - 1];
            }

            var secondArrayToString = string.Empty;

            for (int i = 0; i < secondArray.Length; i++)
            {
                if (secondArray[i] == 0)
                {
                    continue;
                }

                secondArrayToString += alphabet[secondArray[i] - 1];
            }

            string output;

            if (UpperCaseAmount(firstArrayToString) > UpperCaseAmount(secondArrayToString))
            {
                output = "First array has more upper case";
            }
            else if (UpperCaseAmount(firstArrayToString) < UpperCaseAmount(secondArrayToString))
            {
                output = "Second array has more upper case";
            }
            else
            {
                output = "Arrays have the same number of letters with upper case";
            }

            PrintArray(firstArrayToString);

            PrintArray(secondArrayToString);

            Console.WriteLine(output);
        }

        private static void GenerateValues(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Random().Next(0, 27);
            }
        }

        private static void PrintArray(string array)
        {
            foreach (var letter in array)
            {
                if (char.IsUpper(letter))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Write($"{letter} ");

                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.Write($"{letter} ");
                }
            }

            Console.WriteLine();
        }

        private static int UpperCaseAmount(string array)
        {
            int counter = 0;

            foreach (var letter in array)
            {
                if (char.IsUpper(letter))
                {
                    counter++;
                }
            }

            return counter;
        }

        private static string CreateAlphabet()
        {
            var alphabet = string.Empty;

            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                switch (letter)
                {
                    case 'a':
                        {
                            alphabet += char.ToUpper(letter);
                            break;
                        }

                    case 'e':
                        {
                            alphabet += char.ToUpper(letter);
                            break;
                        }

                    case 'i':
                        {
                            alphabet += char.ToUpper(letter);
                            break;
                        }

                    case 'd':
                        {
                            alphabet += char.ToUpper(letter);
                            break;
                        }

                    case 'h':
                        {
                            alphabet += char.ToUpper(letter);
                            break;
                        }

                    case 'j':
                        {
                            alphabet += char.ToUpper(letter);
                            break;
                        }

                    default:
                        {
                            alphabet += letter;
                            break;
                        }
                }
            }

            return alphabet;
        }
    }
}
