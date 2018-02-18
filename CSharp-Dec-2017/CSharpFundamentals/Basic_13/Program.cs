using System;
using System.Collections.Generic;

namespace Basic_13
{
    class Program
    {
        static void Main(string[] args){
            // Console.WriteLine("Hello World!");
            // SayHello();
            // Print1_255();
            // Print1_255_odds();
            // Print1_255_with_sum();
            int[] arr = {1,3,5,7,9,13};
            PrintArr(arr);
            int[] arrMax = {-1,3,5,-7,-9,-13}; 
            PrintMax(arrMax); // Max number is 5
            int[] arrAvg = {2, 10, 3, 1};
            PrintAvg(arrAvg); // Average number is 4.5
            int[] oddArray = OddArray1_255();
            int[] arrNums = {1, 3, 5, 7};
            int y = 3;
            GreaterThanCount(arrNums, y); // Sum of numbers greater than Y is 2
            int[] arrSquare = {1, 5, 10, -2};
            SquareNums(arrSquare); // [1, 25, 100, 4]
            int[] arrWithNegs = {1, 5, 10, -2};
            NegEqualsZero(arrWithNegs); // [1, 5, 10, 0]
            int[] arrMinMaxAvg = {1, 5, 10, -2};
            MinMaxAvg(arrMinMaxAvg);
            int[] arrShiftLeft = {1, 5, 10, 7, -2};
            ShiftLeft(arrShiftLeft); // [5, 10, 7, -2, 0];
            object[] arrNegToString = {-1, -3, 2};
            NegNumToString(arrNegToString); // ['Dojo', 'Dojo', 2]
        }
        public static void SayHello(){
            Console.WriteLine("Hello how are you doing today?");
        }

        // Write a program (sets of instructions) that would print all the numbers from 1 to 255.
        public static void Print1_255(){
            for(int num = 1; num <= 255; num++){
                Console.WriteLine(num); 
            }
        }

        // Write a program (sets of instructions) that would print all the odd numbers from 1 to 255.
        public static void Print1_255_odds(){
            for(int num = 1; num <= 255; num += 2){
                Console.WriteLine(num); 
            }       
        }

        // Write a program that would print the numbers from 0 to 255 but this time, it would also print the sum of the numbers that have been printed so far.
        public static void Print1_255_with_sum(){
            int sum = 0;
            for(int num = 1; num <= 255; num++){
                Console.WriteLine($"New Number: {num}, Sum: {sum += num}");
            }
        }

        // Given an array X, say [1,3,5,7,9,13], write a program that would iterate through each member of the array and print each value on the screen.
        public static void PrintArr(int[] arr){
            // for(int i = 0; i < arr.Length; i++)
            //     Console.WriteLine(arr[i]); 
                // Printing numbers inline instead - [1, 3, 5, 7, 9, 13]
                string output = "[";
                    for(int i = 0; i < arr.Length; i++){
                        if(i != arr.Length-1)
                            output += arr[i] + ", ";
                        else
                            output += arr[i];
                    }
                    output += "]";
                    Console.WriteLine(output); 
        }

        // Write a program (sets of instructions) that takes any array and prints the maximum value in the array. Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), or even a mix of positive numbers, negative numbers and zero.
        public static void PrintMax(int[] arr){
            int max = arr[0];
            // for(int num = 1; num < arr.Length; num++){
            //     if(arr[num] > max){
            //         max = arr[num];
            //     } 
            // }
            // Console.WriteLine(max); 

            // Alternative method below
            foreach(int num in arr){
                if(num > max){
                    max = num;
                }
            }
            Console.WriteLine($"Max number is {max}"); 
        }

        // Write a program that takes an array, and prints the AVERAGE of the values in the array. For example for an array [2, 10, 3], your program should print an average of 5. Again, make sure you come up with a simple base case and write instructions to solve that base case first, then test your instructions for other complicated cases. You can use a count function with this assignment.
        public static void PrintAvg(int[] arr){
            int sum = arr[0];
            foreach(int num in arr){
                sum += num;
            }
            double avg = (double)sum / (double)arr.Length; // To account for decimals.
            Console.WriteLine($"Average number is {avg}"); 
        }

        // Write a program that creates an array 'y' that contains all the odd numbers between 1 to 255. When the program is done, 'y' should have the value of [1, 3, 5, 7, ... 255].
        public static int[] OddArray1_255(){
            List<int> y = new List<int>();
            for(int num = 1; num <= 255; num += 2){
                y.Add(num); 
            }
            return y.ToArray();
        }

        // Write a program that takes an array and returns the number of values in that array whose value is greater than a given value y. For example, if array = [1, 3, 5, 7] and y = 3. After your program is run it will print 2 (since there are two values in the array that are greater than 3).
        public static int GreaterThanCount(int[] arr, int y){
            int count = 0;
            foreach(int num in arr){
                if(num > y){
                    count += 1;
                }
            }
            Console.WriteLine($"Count of numbers greater than Y is {count}"); 
            return count;
        }

        // Given any array x, say [1, 5, 10, -2], create an algorithm (sets of instructions) that multiplies each value in the array by itself. When the program is done, the array x should have values that have been squared, say [1, 25, 100, 4].
        public static void SquareNums(int[] arr){
            for(int i = 0; i < arr.Length; i++){
                arr[i] *= arr[i];
            }
        }
            
        // Given any array x, say [1, 5, 10, -2], create an algorithm that replaces any negative number with the value of 0. When the program is done, x should have no negative values, say [1, 5, 10, 0].
        public static void NegEqualsZero(int[] arr){
            for(int i = 0; i < arr.Length; i++){
                if(arr[i] < 0){
                    arr[i] = 0;
                }
            }
        }

        // Given any array x, say [1, 5, 10, -2], create an algorithm that prints the maximum number in the array, the minimum value in the array, and the average of the values in the array.
        public static void MinMaxAvg(int[] arr){
            int min = arr[0];
            int max = arr[0];
            int sum = arr[0];
            for(int i = 1; i < arr.Length; i++){
                sum += arr[i];
                if(arr[i] < min){
                    min = arr[i];
                }
                else if(arr[i] > max){
                    max = arr[i];
                }
            // double avg = (double)sum / (double)arr.Length;
            }
            Console.WriteLine($"Min: {min}, Max: {max}, Avg: {(double)sum / (double)arr.Length}");
        }

        // Given any array x, say [1, 5, 10, 7, -2], create an algorithm that shifts each number by one to the front and adds '0' to the end. For example, when the program is done,  if the array [1, 5, 10, 7, -2] is passed to the function, it should become [5, 10, 7, -2, 0].
        public static void ShiftLeft(int[] arr){
            for(int i = 0; i < arr.Length-1; i++){
                arr[i] = arr[i+1];
            }
            arr[arr.Length-1] = 0; // Last index = 0
        }

        // Write a program that takes an array of numbers and replaces any negative number with the string 'Dojo'. For example, if array x is initially [-1, -3, 2] your function should return an array with values ['Dojo', 'Dojo', 2].
        public static object[] NegNumToString(object[] arr){
            for(int idx = 0; idx < arr.Length; idx++){
                if((int)arr[idx] < 0){
                    arr[idx] = "dojo";
                }
            }
            return arr;
        }
    }
}
