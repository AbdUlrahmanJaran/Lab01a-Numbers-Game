using System;

namespace Numbers_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // I used try and catch to catch any error cold happened runnig
            try
            {
                StartSequence();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Program is complete");
            }
        }

        //This method call the other methods and give insructions to the user
        static void StartSequence()
        {
            Console.WriteLine("Welcome to Numpers Game");
            Console.WriteLine("Enter a number greater than zero");

            //this sentence put the Users input in a String to convert it later
            String arraySizeString = Console.ReadLine();

            //this sentence convert the String that comes from reading User's input into the console to an integer
            int arraySizeInt = Convert.ToInt32(arraySizeString);
            Console.WriteLine("You entered " + arraySizeInt);

            //create an array with size from User
            int[] array = new int[arraySizeInt];

            //here I put try and catch to catch errors while groping our data
            try
            {
                int [] arr = Populate(array);
                int sum = GetSum(arr);
                int product = GetProduct(arr, sum);
                decimal quotient = GetQuotient(product);
                Console.WriteLine("Your array size is: " + arraySizeInt);
                Console.Write("The Numbers in the array are: ");
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i]);
                    if (i != arr.Length-1) { Console.Write(","); }
                }
                Console.WriteLine();
                Console.WriteLine("The sum of the array is: " + sum);
                Console.WriteLine("The product is: " + product);
                Console.WriteLine("The quotient is: " + quotient);
            }
            catch(FormatException e) 
            { //this block catch any Format error
                Console.WriteLine("There's a Format error: " + e.Message); 
            }catch(Exception e)
            { //this block catch any error
                Console.WriteLine("Something unexpected happened: " + e.Message);
            }
            
        }

        //This method fill our array by reciving Users Input
        static int[] Populate(int [] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int a = i + 1;
                Console.WriteLine("Please enter a number: " + a + " of " + arr.Length);
                String stringInputA = Console.ReadLine();
                int intInputA = Convert.ToInt32(stringInputA);
                arr[i] = intInputA;
            }
            return arr;
        }

        //This method return the sum of all the elemnts in the array
        static int GetSum(int [] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            if(sum < 20)
            {
                throw new Exception("Value of " + sum + " is too low");
            }
            return sum;
        }

        //This method return the product of sum and the value of a selected element by User
        static int GetProduct(int[] arr, int sum)
        {
            int product;
            try
            {
                Console.WriteLine("Please enter a number between 1 and " + arr.Length);
                String stringInputB = Console.ReadLine();
                int intInputB = Convert.ToInt32(stringInputB) -1;
                product = sum * arr[intInputB];
            }

            //this catch if the user put a number greater than array size
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine("IndexOutOfRange error: " + e.Message);
                throw;
            }

            return product;
        }


        //This method return quotient of devide product by any number from User
        static decimal GetQuotient(int product)
        {
            decimal quotient;
            try
            {
                Console.WriteLine("Please enter a number to devide your product "+ product +" by");
                String stringInputC = Console.ReadLine();
                decimal decimalInputC = Convert.ToDecimal(stringInputC);
                quotient = decimal.Divide(product, decimalInputC);
            }
            //This catch if the User try to divide by 0
            catch (DivideByZeroException e)
            {
                Console.WriteLine("You can't divide by zero: "+ e.Message);
                return 0;
            }
            return quotient;
        }
    }
}
